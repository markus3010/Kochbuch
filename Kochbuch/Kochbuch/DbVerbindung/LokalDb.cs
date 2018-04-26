using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Kochbuch
{
    class LokalDb : IRezeptDb
    {
        private string connectionString;
        SQLiteAsyncConnection connection;

        public LokalDb()
        {
            connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "kochbuch.db");
            SQLiteAsyncConnection connection = Connect();
            CreateTables(connection);
        }

        public async Task<RezeptModel> GetRezeptAsync(int ID)
        {
            try
            {
                RezeptModel rezept = new RezeptModel();
                var rezeptSuche = connection.Table<RezeptModel>().Where(v => v.ID.Equals(ID));
                var rezeptErgebnis = await rezeptSuche.ToListAsync();
                foreach(var suchergebnis in rezeptErgebnis)
                {
                    rezept = suchergebnis;
                }
                if(rezeptErgebnis.Count == 0)
                {
                    return null;
                }
                int rezeptID = rezept.ID;
                List<int> zutatIDs = new List<int>();
                var verbindungSuche = connection.Table<RezeptZutatVerbindung>().Where(v => v.RezeptID.Equals(rezeptID));
                var verbindungErgebnis = await verbindungSuche.ToListAsync();
                foreach(var suchergebnis in verbindungErgebnis)
                {
                    zutatIDs.Add(suchergebnis.ZutatID);
                }
                foreach (int rezeptIDErgebnis in zutatIDs) {
                    var zutatSuche = connection.Table<ZutatModel>().Where(v => v.ID.Equals(rezeptIDErgebnis));
                    var zutatErgebnis = await zutatSuche.ToListAsync();
                    foreach(var zutat in zutatErgebnis)
                    {
                        rezept.Zutaten.Add(zutat);
                    }
                }
                return rezept;
            }
            catch(Exception e)
            {
                return new RezeptModel
                {
                    Titel = "Fehler: " + e.Message
                };
            }
            
        }

        public async Task<RezeptModel> GetRezeptAsync(string Titel)
        {
            try
            {
                RezeptModel rezept = new RezeptModel();
                var rezeptSuche = connection.Table<RezeptModel>().Where(v => v.Titel.Contains(Titel));
                var rezeptErgebnis = await rezeptSuche.ToListAsync();
                foreach (var suchergebnis in rezeptErgebnis)
                {
                    rezept = suchergebnis;
                }
                if (rezeptErgebnis.Count == 0)
                {
                    return null;
                }
                int rezeptID = rezept.ID;
                List<int> zutatIDs = new List<int>();
                var verbindungSuche = connection.Table<RezeptZutatVerbindung>().Where(v => v.RezeptID.Equals(rezeptID));
                var verbindungErgebnis = await verbindungSuche.ToListAsync();
                foreach (var suchergebnis in verbindungErgebnis)
                {
                    zutatIDs.Add(suchergebnis.ZutatID);
                }
                foreach (int rezeptIDErgebnis in zutatIDs)
                {
                    var zutatSuche = connection.Table<ZutatModel>().Where(v => v.ID.Equals(rezeptIDErgebnis));
                    var zutatErgebnis = await zutatSuche.ToListAsync();
                    foreach (var zutat in zutatErgebnis)
                    {
                        rezept.Zutaten.Add(zutat);
                    }
                }
                return rezept;
            }
            catch (Exception e)
            {
                return new RezeptModel
                {
                    Titel = "Fehler: " + e.Message
                };
            }
        }

        public async Task<List<RezeptModel>> GetRezeptModelsAsync()
        {
            List<RezeptModel> rezepte = new List<RezeptModel>();
            List<int> IDList = new List<int>();
            try
            {
                var rezeptSuche = connection.Table<RezeptModel>();
                var rezeptErgebnis = await rezeptSuche.ToListAsync();
                foreach (RezeptModel rezept in rezeptErgebnis)
                {
                    rezepte.Add(await GetRezeptAsync(rezept.ID));
                }
            }catch (Exception e)
            {
                rezepte.Add(new RezeptModel
                {
                    Titel = "Fehler: " + e.Message
                });
            }
            return rezepte;
        }

        public async Task<bool> SaveRezeptAsync(RezeptModel rezept)
        {
            try
            {
                await connection.InsertAsync(rezept);
                int rezeptID = rezept.ID;
                List<int> zutatIDs = new List<int>();
                foreach (ZutatModel zutat in rezept.Zutaten)
                {
                    await connection.InsertAsync(zutat);
                    zutatIDs.Add(zutat.ID);
                }
                foreach (int zuatatID in zutatIDs)
                {
                    RezeptZutatVerbindung rezeptZutatVerbindung = new RezeptZutatVerbindung
                    {
                        RezeptID = rezeptID,
                        ZutatID = zuatatID
                    };
                    await connection.InsertAsync(rezeptZutatVerbindung);
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> SaveRezepteAsync(List<RezeptModel> rezepte)
        {
            List<bool> ergebnisse = new List<bool>();
            foreach(RezeptModel rezept in rezepte)
            {
                bool ergebnis = await SaveRezeptAsync(rezept);
                ergebnisse.Add(ergebnis);
            }
            return true;
        }

        private SQLiteAsyncConnection Connect()
        {
            var db = new SQLiteAsyncConnection(connectionString);
            return db;
        }
        private async void CreateTables(SQLiteAsyncConnection connection)
        {
            await connection.CreateTableAsync<RezeptModel>();
            await connection.CreateTableAsync<ZutatModel>();
            await connection.CreateTableAsync<RezeptZutatVerbindung>();
        }
    }
}

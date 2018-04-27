using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Kochbuch
{
    class LokalDb : IRezeptDb
    {
        private string filePath;
        SQLiteAsyncConnection connection;
        private static LokalDb database;

        private LokalDb()
        {

            connection = Connect();
            CreateTables(connection);
            
        }


        public async Task<RezeptModel> GetRezeptAsync(int ID)
        {
            try
            {
                RezeptModel rezeptErgebnis = new RezeptModel();
                rezeptErgebnis = await connection.Table<RezeptModel>().Where(v => v.ID == ID).FirstOrDefaultAsync();
                
                rezeptErgebnis.Zutaten = new List<ZutatModel>();
                int rezeptID = rezeptErgebnis.ID;
                List<int> zutatIDs = new List<int>();
                var verbindungErgebnis = await connection.Table<RezeptZutatVerbindung>().Where(v => v.RezeptID  == rezeptID).ToListAsync();
                foreach(var suchergebnis in verbindungErgebnis)
                {
                    zutatIDs.Add(suchergebnis.ZutatID);
                }
                foreach (int zutatIDErgebnis in zutatIDs) {
                    var zutatErgebnis = await connection.Table<ZutatModel>().Where(v => v.ID == zutatIDErgebnis).ToListAsync();
                    foreach (var zutat in zutatErgebnis)
                    {
                        rezeptErgebnis.Zutaten.Add(zutat);
                    }
                }
            return rezeptErgebnis;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                ÜbersichtPage.ShowAlert(e.Source, e.Message);
                return null;
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
                System.Diagnostics.Debug.Write(e.Message);
                return null;
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
                System.Diagnostics.Debug.Write(e.Message);
                return null;
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
                    RezeptZutatVerbindung rezeptZutatVerbindung = new RezeptZutatVerbindung();
                    rezeptZutatVerbindung.RezeptID = rezept.ID;
                    rezeptZutatVerbindung.ZutatID = zuatatID;
                    await connection.InsertAsync(rezeptZutatVerbindung);
                }
                return true;

            }
            catch(Exception e) 
            {
                ÜbersichtPage.ShowAlert("ERROR", e.Message);
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
            filePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("KochbuchDb.db3");
            var db = new SQLiteAsyncConnection(filePath);
            return db;
        }
        private async void CreateTables(SQLiteAsyncConnection connection)
        {
            await connection.CreateTableAsync<RezeptModel>();
            await connection.CreateTableAsync<ZutatModel>();
            await connection.CreateTableAsync<RezeptZutatVerbindung>();
            //await connection.ExecuteAsync("Delete From RezeptModel");
            //await connection.ExecuteAsync("Delete From ZutatModel");
            //await connection.ExecuteAsync("Delete From RezeptZutatVerbindung");
            
        }
        public static LokalDb GetInstance()
        {
            if (database == null)
            {
                database = new LokalDb();
            }
            return database;
        }
    }
}

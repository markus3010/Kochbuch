using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Kochbuch
{
    class LokalDb : IRezeptDb
    {
        public Task<RezeptModel> GetRezeptAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<RezeptModel> GetRezeptAsync(string Titel)
        {
            throw new NotImplementedException();
        }

        public Task<List<RezeptModel>> GetRezeptModelsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveRezeptAsync(RezeptModel rezept)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveRezepteAsync(List<RezeptModel> rezepte)
        {
            throw new NotImplementedException();
        }

        private void Connect()
        {
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"kochbuch.db3");
            //var db = new Sql
        }
    }
}

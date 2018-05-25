using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class OnlineDb : IRezeptDb
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
    }
}

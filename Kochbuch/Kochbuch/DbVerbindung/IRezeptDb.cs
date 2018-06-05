using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    interface IRezeptDb
    {
        Task<List<RezeptModel>> GetRezeptModelsAsync();
        Task<bool> SaveRezeptAsync(RezeptModel rezept);
        Task<bool> SaveRezepteAsync(List<RezeptModel> rezepte);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class EigeneRezepteController
    {
        private static EigeneRezepteController instance;
        private EigeneRezepteController()
        {

        }
        public static EigeneRezepteController getInstance()
        {
            if(instance == null)
            {
                instance = new EigeneRezepteController();
            }
            return instance;
        }
        public async Task SetRezepte()
        {
            var db = LokalDb.GetInstance();
            List<RezeptModel> rezepte = new List<RezeptModel>();
            rezepte = await db.GetRezeptModelsAsync();
            EigeneRezepteView.getInstance().SetRezepte(rezepte);
        }
    }
}

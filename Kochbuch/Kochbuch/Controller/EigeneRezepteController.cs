using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class EigeneRezepteController
    {
        private static EigeneRezepteController instance;
        private List<RezeptModel> rezepte;
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
            rezepte = new List<RezeptModel>();
            rezepte = await db.GetRezeptModelsAsync();
            EigeneRezepteView.getInstance().SetRezepte(rezepte);
        }

        public async Task Refresh()
        {
            EigeneRezepteView.getInstance().RezepteLoeschen();
            await SetRezepte();
        }

        public void RezeptAusgewählt(int ID)
        {
            RezeptModel rezept = GetRezeptFromList(ID);
            if (rezept != null)
            {

                ÜbersichtController.getInstance().SetzeInhaltRezept(rezept,false);
            }
        }
        public RezeptModel GetRezeptFromList(int ID)
        {
            if (rezepte == null)
            {
                return null;
            }
            RezeptModel rezept = rezepte.Find(x => x.ID == ID);
            return rezept;
        }
    }
}

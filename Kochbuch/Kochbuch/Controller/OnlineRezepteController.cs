using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class OnlineRezepteController
    {
        private static OnlineRezepteController instance;
        List<RezeptModel> rezepte;

        public static OnlineRezepteController getInstance()
        {
            if (instance == null)
            {
                instance = new OnlineRezepteController();
            }
            return instance;
        }
        public async Task SetRezepte()
        {
            Load(true);
            var db = OnlineDb.getInstance();
            rezepte = new List<RezeptModel>();
            rezepte = await db.GetRezeptModelsAsync();
            Load(false);
            OnlineRezepteView.getInstance().SetRezepte(rezepte);
            
        }
        public void Load(bool show)
        {
            OnlineRezepteView.getInstance().ShowLoadingIcon(show);
        }
        public RezeptModel GetRezeptFromList(int ID)
        {
            if(rezepte == null)
            {
                return null;
            }
            RezeptModel rezept = rezepte.Find(x => x.ID == ID);
            return rezept;
        }

        public async Task Refresh()
        {
            OnlineRezepteView.getInstance().RezepteLoeschen();
            await SetRezepte();
        }

        public static bool HasInstance()
        {
            if(instance == null)
            {
                return false;
            }
            return true;
        }

        public void RezeptAusgewählt(int ID)
        {
            RezeptModel rezept = GetRezeptFromList(ID);
            if(rezept != null)
            {

                ÜbersichtController.getInstance().SetzeInhaltRezept(rezept, true);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class OnlineRezepteController
    {
        private static OnlineRezepteController instance;
        private OnlineRezepteController()
        {

        }
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
            var db = OnlineDb.getInstance();
            List<RezeptModel> rezepte = new List<RezeptModel>();
            rezepte = await db.GetRezeptModelsAsync();
            OnlineRezepteView.getInstance().SetRezepte(rezepte);
        }
        public void Load(bool show)
        {
            OnlineRezepteView.getInstance().ShowLoadingIcon(show);
        }
    }
}

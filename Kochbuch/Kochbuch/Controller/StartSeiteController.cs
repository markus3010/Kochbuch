using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Kochbuch
{
    class StartSeiteController
    {
        private static StartSeiteController instance;
        private StartSeiteController()
        {

        }
        public static StartSeiteController getInstance()
        {
            if(instance == null)
            {
                instance = new StartSeiteController();
            }
            return instance;
        }

        public async Task SetRezeptAsync()
        {
            List<RezeptModel> rezepte = new List<RezeptModel>();
            var db = LokalDb.GetInstance();
            rezepte = await db.GetRezeptModelsAsync();
            if(rezepte.Count != 0)
            {
                int anzahl = rezepte.Count;
                Random random = new Random();
                int auswahl = random.Next(anzahl);
                StartSeiteView startSeite = StartSeiteView.getInstance();
                startSeite.SetzeRezeptView(RezeptController.getInstance().GetRezeptView(rezepte[auswahl],false));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kochbuch
{
    class ÜbersichtController
    {
        private ÜbersichtPage page;
        private static ÜbersichtController instance;
        public static ÜbersichtController getInstance()
        {
            if(instance == null)
            {
                instance = new ÜbersichtController();
            }
            return instance;
        }
        private ÜbersichtController()
        {
            page = ÜbersichtPage.getInstance();
        }
        public async System.Threading.Tasks.Task SetzeInhaltStartSeite()
        {
            ÜbersichtPage.getInstance().SetContent(StartSeiteView.getInstance());
            await StartSeiteController.getInstance().SetRezeptAsync();
        }

        public async  Task SetzeInhaltEigeneRezepte()
        {
            ÜbersichtPage.getInstance().SetContent(EigeneRezepteView.getInstance());
            await EigeneRezepteController.getInstance().SetRezepte();
        }
    }
}

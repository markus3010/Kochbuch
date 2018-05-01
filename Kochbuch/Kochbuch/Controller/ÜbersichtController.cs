using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kochbuch
{
    class ÜbersichtController
    {
        private ÜbersichtPage page;
        private View lastView;
        private View currentView;
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
        public async Task SetzeInhaltStartSeite()
        {
            lastView = currentView;
            page.SetContent(StartSeiteView.getInstance());
            await StartSeiteController.getInstance().SetRezeptAsync();
            currentView = StartSeiteView.getInstance();
        }

        public async  Task SetzeInhaltEigeneRezepte()
        {
            lastView = currentView;
            page.SetContent(EigeneRezepteView.getInstance());
            await EigeneRezepteController.getInstance().SetRezepte();
            currentView = EigeneRezepteView.getInstance();
        }
        public async Task SetzeInhaltRezept(int rezeptID)
        {
            lastView = currentView;
            RezeptModel rezept = await LokalDb.GetInstance().GetRezeptAsync(rezeptID);
            RezeptView rezeptView = new RezeptView(rezept);
            rezeptView.ZeigeZurückButton(true);
            page.SetContent(rezeptView);
            currentView = rezeptView;
        }
        public void SetzeInhaltLezter()
        {
            if(lastView != null)
            {
                currentView = lastView;
                page.SetContent(currentView);
                lastView = null;
            }
        }

        public  void SetzeInhaltRezeptErstellen()
        {
            lastView = currentView;
            var view = RezeptErstellenView.getInstance();
            page.SetContent(view);
            currentView = view;
        }
    }
}

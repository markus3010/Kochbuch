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
            await StartSeiteController.getInstance().SetRezeptAsync();
            SetzeInhalt(StartSeiteView.getInstance());
        }

        public async  Task SetzeInhaltEigeneRezepte()
        {
            await EigeneRezepteController.getInstance().SetRezepte();
            SetzeInhalt(EigeneRezepteView.getInstance());
        }
        public async Task SetzeInhaltRezept(int rezeptID)
        {
            RezeptModel rezept = await LokalDb.GetInstance().GetRezeptAsync(rezeptID);
            RezeptView rezeptView = new RezeptView(rezept);
            rezeptView.ZeigeZurückButton(true);
            SetzeInhalt(rezeptView);
        }
        public void SetzeInhaltLezter()
        {
            SetzeInhalt(lastView);
        }
        public  void SetzeInhaltRezeptErstellen()
        {
            SetzeInhalt(RezeptErstellenView.getInstance());
        }
        private void SetzeInhalt(View view)
        {
            if(view != null)
            {
                lastView = currentView;
                page.SetContent(view);
                currentView = view;
            }
        }
    }
}

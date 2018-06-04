using System.Threading.Tasks;

namespace Kochbuch
{
    class RezeptController
    {
        private static RezeptController instance;
        private RezeptModel letztesRezept;
        public static RezeptController getInstance()
        {
            if(instance == null)
            {
                instance = new RezeptController();
            }
            return instance;
        }
        public RezeptView GetRezeptView(RezeptModel rezept, bool showDelete)
        {
            letztesRezept = rezept;
            RezeptView view = new RezeptView();
            view.SetTitel(rezept.Titel);
            view.SetAutor(rezept.Autor);
            view.SetSchwierigkeit(rezept.Schwierigkeit);
            foreach(ZutatModel zutat in rezept.Zutaten)
            {
                ZutatView zutatView = new ZutatView(zutat);
                view.AddRezept(zutatView);
            }
            view.SetBeschreibung(rezept.Beschreibung);
            if (showDelete)
            {
                view.LöschenHinzufuegen();
            }
            return view;
        }

        public async Task LetztesRezeptLöschen()
        {
            var db = LokalDb.GetInstance();
            db.DeleteRezept(letztesRezept.ID);
            await OnlineDb.getInstance().DeleteRezeptAsync(letztesRezept.Titel);
            await OnlineRezepteController.getInstance().Refresh();
            await EigeneRezepteController.getInstance().Refresh();
            ÜbersichtController.getInstance().SetzeInhaltLezter();
        }
    }
}

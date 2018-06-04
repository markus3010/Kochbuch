using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class RezeptErstellenView : ContentView
	{
        private StackLayout layout;
        private ScrollView scroll;
        private static RezeptErstellenView instance;

        Entry entryTitel;
        Picker pickerSchwierigkeit;
        Editor editorBeschreibung;
		private RezeptErstellenView ()
		{
            scroll = new ScrollView();
            Content = scroll;
            layout = new StackLayout();
            scroll.Content = layout;
            layout.Margin = new Thickness(20, 20);
            scroll.HorizontalOptions = LayoutOptions.StartAndExpand;
            layout.HorizontalOptions = LayoutOptions.StartAndExpand;

            Label labelTitel = new Label();
            labelTitel.Text = "Titel";
            layout.Children.Add(labelTitel);
            labelTitel.HorizontalOptions = LayoutOptions.FillAndExpand;

            entryTitel = new Entry();
            entryTitel.Placeholder = "Titel";
            entryTitel.PlaceholderColor = Color.LightGray;
            layout.Children.Add(entryTitel);

            if (Device.RuntimePlatform == Device.Android)
            {
                Label labelSchwierigkeit = new Label();
                labelSchwierigkeit.Text = "Schwierigkeit";
                layout.Children.Add(labelSchwierigkeit);
            }

            pickerSchwierigkeit = new Picker();
            pickerSchwierigkeit.Title = "Schwierigkeit";
            pickerSchwierigkeit.Items.Add("Leicht");
            pickerSchwierigkeit.Items.Add("Mittel");
            pickerSchwierigkeit.Items.Add("Schwer");
            layout.Children.Add(pickerSchwierigkeit);

            Label labelZutaten = new Label();
            labelZutaten.Text = "Zutaten";
            layout.Children.Add(labelZutaten);

            Button btnZutatHinzufuegen = new Button();
            btnZutatHinzufuegen.BorderColor = Color.Gray;
            btnZutatHinzufuegen.Text = "Zutat hinzufügen";
            btnZutatHinzufuegen.Clicked += BtnZutatHinzufuegen_Clicked;
            layout.Children.Add(btnZutatHinzufuegen);

            layout.Children.Add(new ZutatErstellenView());


            Label labelBeschreibung = new Label();
            labelBeschreibung.Text = "Beschreibung";
            layout.Children.Add(labelBeschreibung);

            editorBeschreibung = new Editor();
            editorBeschreibung.VerticalOptions = LayoutOptions.CenterAndExpand;
            editorBeschreibung.HeightRequest = 500;
            editorBeschreibung.WidthRequest = 5000;
            layout.Children.Add(editorBeschreibung);

            Button btnSpeichern = new Button();
            btnSpeichern.Text = "Speichern";
            layout.Children.Add(btnSpeichern);
            btnSpeichern.Clicked += BtnSpeichern_Clicked;
        }

        internal void DatenLöschen()
        {
            instance = new RezeptErstellenView();
        }

        private async void BtnSpeichern_Clicked(object sender, EventArgs e)
        {
            await RezeptErstellenController.getInstance().Speichern(instance);
        }

        private void BtnZutatHinzufuegen_Clicked(object sender, EventArgs e)
        {
            layout.Children.Insert(layout.Children.Count-3, new ZutatErstellenView());

        }
        public ZutatErstellenView ZutatBearbeitenHinzufuegen()
        {
            ZutatErstellenView erstellen = new ZutatErstellenView();
            layout.Children.Insert(layout.Children.Count - 3, erstellen);
            return erstellen;
        }
        public ZutatErstelltView ZutatHinzufuegen()
        {
            ZutatErstelltView erstellt = new ZutatErstelltView();
            layout.Children.Insert(layout.Children.Count - 3, erstellt);
            return erstellt;
        }
        public static RezeptErstellenView getInstance()
        {
            if(instance == null)
            {
                instance = new RezeptErstellenView();
            }
            return instance;
        }
        public void ViewEntfernen (View view)
        {
            layout.Children.Remove(view);
        }
        public string GetTitel()
        {
            return entryTitel.Text;
        }
        public RezeptModel.schwierigkeit GetSchwierigkeit()
        {
            int index = pickerSchwierigkeit.SelectedIndex;
            switch (index)
            {
                case 0:
                    return RezeptModel.schwierigkeit.Leicht;
                    break;
                case 1:
                    return RezeptModel.schwierigkeit.Mittel;
                    break;
                case 2:
                    return RezeptModel.schwierigkeit.Schwer;
                default:
                    return RezeptModel.schwierigkeit.Schwer;
            }
        }
        public string GetBeschreibung()
        {
            return editorBeschreibung.Text;
        }
        public List<ZutatErstellenView> GetZutatErstellenViews()
        {
            List<ZutatErstellenView> zutaten = new List<ZutatErstellenView>();
            foreach(var element in layout.Children)
            {
                if(element.GetType() == typeof(ZutatErstellenView))
                {
                    zutaten.Add(element as ZutatErstellenView);
                }
            }
            return zutaten;
        }
        public List<ZutatErstelltView> GetZutatErstelltViews()
        {
            List<ZutatErstelltView> zutaten = new List<ZutatErstelltView>();
            foreach (var element in layout.Children)
            {
                if (element.GetType() == typeof(ZutatErstelltView))
                {
                    ZutatErstelltView view = element as ZutatErstelltView;
                    string art = view.GetArt();
                    if(art != "")
                    {
                        zutaten.Add(view);
                    }
                }
            }
            return zutaten;
        }
    }
}
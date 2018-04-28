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
		public RezeptErstellenView ()
		{
            scroll = new ScrollView();
            Content = scroll;
            layout = new StackLayout();
            scroll.Content = layout;
            layout.Margin = new Thickness(20, 20);
            

            Label labelTitel = new Label();
            labelTitel.Text = "Titel";
            layout.Children.Add(labelTitel);

            Entry entryTitel = new Entry();
            entryTitel.Placeholder = "Titel";
            entryTitel.PlaceholderColor = Color.LightGray;
            layout.Children.Add(entryTitel);

            if (Device.RuntimePlatform == Device.Android)
            {
                Label labelSchwierigkeit = new Label();
                labelSchwierigkeit.Text = "Schwierigkeit";
                layout.Children.Add(labelSchwierigkeit);
            }

            Picker pickerSchwierigkeit = new Picker();
            pickerSchwierigkeit.Title = "Schwierigkeit";
            pickerSchwierigkeit.Items.Add("Leicht");
            pickerSchwierigkeit.Items.Add("Mittel");
            pickerSchwierigkeit.Items.Add("Schwer");
            layout.Children.Add(pickerSchwierigkeit);

            Label labelZutaten = new Label();
            labelZutaten.Text = "Zutaten";
            layout.Children.Add(labelZutaten);

            Button btnZutatHinzufuegen = new Button();
            btnZutatHinzufuegen.Text = "Zutat hinzufügen";
            btnZutatHinzufuegen.Clicked += BtnZutatHinzufuegen_Clicked;
            layout.Children.Add(btnZutatHinzufuegen);

            layout.Children.Add(new ZutatErstellenView());


            Label labelBeschreibung = new Label();
            labelBeschreibung.Text = "Beschreibung";
            layout.Children.Add(labelBeschreibung);
            /*
            Entry entryBeschreibung = new Entry();
            entryBeschreibung.Placeholder = "Beschreibung";
            entryBeschreibung.PlaceholderColor = Color.LightGray;
            entryBeschreibung.HeightRequest = 500;
            layout.Children.Add(entryBeschreibung);
            */
            Editor editorBeschreibung = new Editor();
            editorBeschreibung.HeightRequest = 500;
            layout.Children.Add(editorBeschreibung);

            Button btnSpeichern = new Button();
            btnSpeichern.Text = "Speichern";
            layout.Children.Add(btnSpeichern);
        }

        private void BtnZutatHinzufuegen_Clicked(object sender, EventArgs e)
        {
            layout.Children.Insert(layout.Children.Count-3, new ZutatErstellenView());

        }
    }
}
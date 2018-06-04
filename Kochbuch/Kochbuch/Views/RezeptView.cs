using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class RezeptView : ContentView
	{
        StackLayout layout;
        ScrollView scroll;

        Label labelTitel;
        Label labelAutor;
        Label labelSchwierigkeit;
        Label labelBeschreibung;
        public RezeptView()
        {
            scroll = new ScrollView();
            scroll.HorizontalOptions = LayoutOptions.CenterAndExpand;
            scroll.VerticalOptions = LayoutOptions.StartAndExpand;
            Content = scroll;

            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.StartAndExpand;
            layout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            layout.Padding = new Thickness(10, 10);
            scroll.Content = layout;
            
            labelTitel = new Label();
            labelTitel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            labelTitel.FontAttributes = FontAttributes.Bold;
            labelTitel.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelTitel.WidthRequest = 5000;
            layout.Children.Add(labelTitel);

            labelAutor = new Label();
            labelAutor.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            labelAutor.FontAttributes = FontAttributes.Italic;
            labelAutor.HorizontalOptions = LayoutOptions.StartAndExpand;
            layout.Children.Add(labelAutor);

            Label labelZutaten = new Label();
            labelZutaten.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            labelZutaten.Text = "Zutaten";
            labelZutaten.FontAttributes = FontAttributes.Bold;
            labelZutaten.HorizontalOptions = LayoutOptions.StartAndExpand;
            layout.Children.Add(labelZutaten);

            labelSchwierigkeit = new Label();
            labelSchwierigkeit.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelSchwierigkeit.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            labelSchwierigkeit.FontAttributes = FontAttributes.Bold;
            layout.Children.Add(labelSchwierigkeit);

            Label labelZubereitung = new Label();
            labelZubereitung.Text = "Zubereitung";
            labelZubereitung.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelZubereitung.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            labelZubereitung.FontAttributes = FontAttributes.Bold;
            layout.Children.Add(labelZubereitung);

            labelBeschreibung = new Label();
            labelBeschreibung.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelBeschreibung.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
            layout.Children.Add(labelBeschreibung);
        }

        public void SetBeschreibung(string beschreibung)
        {
            labelBeschreibung.Text = beschreibung;
        }

        public void AddRezept(ZutatView zutatView)
        {
            layout.Children.Insert(4, zutatView);
        }

        public void SetSchwierigkeit(RezeptModel.schwierigkeit schwierigkeit)
        {
            string grad;
            switch (schwierigkeit)
            {
                case RezeptModel.schwierigkeit.Leicht:
                    grad = "Leicht";
                    break;
                case RezeptModel.schwierigkeit.Mittel:
                    grad = "Mittel";
                    break;
                case RezeptModel.schwierigkeit.Schwer:
                    grad = "Schwer";
                    break;
                default:
                    grad = "NotDefined";
                    break;
            }
            labelSchwierigkeit.Text = "Schwierigkeit: " + grad;
        }

        public void SetAutor(string autor)
        {
            labelAutor.Text = "von " + autor;
        }

        public void SetTitel(string titel)
        {
            labelTitel.Text = titel;
        }

        private async void ImageLöschenRecognizer_Tapped(object sender, EventArgs e)
        {
            await RezeptController.getInstance().LetztesRezeptLöschen();
        }

        private void BtnZurück_Clicked(object sender, EventArgs e)
        {
            ÜbersichtController.getInstance().SetzeInhaltLezter();
        }
        public void LöschenHinzufuegen()
        {
            Image imageLöschen = new Image();
            imageLöschen.Source = (FileImageSource)ImageSource.FromFile("Loeschen.png");
            imageLöschen.HeightRequest = 35;
            imageLöschen.WidthRequest = 35;
            imageLöschen.HorizontalOptions = LayoutOptions.End;
            layout.Children.Insert(0,imageLöschen);
            TapGestureRecognizer imageLöschenRecognizer = new TapGestureRecognizer();
            imageLöschen.GestureRecognizers.Add(imageLöschenRecognizer);
            imageLöschenRecognizer.Tapped += ImageLöschenRecognizer_Tapped;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class RezeptView : ContentView
	{
        RezeptModel rezept;
        StackLayout layout;
        public RezeptView(RezeptModel rezept)
        {
            this.rezept = rezept;
            ScrollView scroll = new ScrollView();
            scroll.HorizontalOptions = LayoutOptions.CenterAndExpand;
            scroll.VerticalOptions = LayoutOptions.StartAndExpand;
            Content = scroll;
            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.StartAndExpand;
            layout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            layout.Padding = new Thickness(10, 10);
            scroll.Content = layout;

            Image imageLöschen = new Image
            {
                Source = (FileImageSource)ImageSource.FromFile("Loeschen.png"),
                HeightRequest = 35,
                WidthRequest = 35,
                HorizontalOptions = LayoutOptions.End,

            };
            layout.Children.Add(imageLöschen);
            TapGestureRecognizer imageLöschenRecognizer = new TapGestureRecognizer();
            imageLöschen.GestureRecognizers.Add(imageLöschenRecognizer);
            imageLöschenRecognizer.Tapped += ImageLöschenRecognizer_Tapped;

            layout.Children.Add(new Label
            {
                Text = rezept.Titel,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = 5000
            });
            layout.Children.Add(
                new Label
                {
                    Text = "von " + rezept.Autor,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                });
            layout.Children.Add(new Label
            {
                Text = "Zutaten",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            });
            foreach (ZutatModel zutat in rezept.Zutaten)
            {
                layout.Children.Add(new ZutatView(zutat));
            }
            layout.Children.Add(new Label
            {
                Text = "Schwierigkeit: " + rezept.Schwierigkeit,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            });
            layout.Children.Add(new Label
            {
                Text = "Zubereitung",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            });
            layout.Children.Add(new Label
            {
                Text = rezept.Beschreibung,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
            });
        }

        private void ImageLöschenRecognizer_Tapped(object sender, EventArgs e)
        {
            LokalDb.GetInstance().DeleteRezept(rezept.ID);
            ÜbersichtController.getInstance().SetzeInhaltLezter();
        }

        private void BtnZurück_Clicked(object sender, EventArgs e)
        {
            ÜbersichtController.getInstance().SetzeInhaltLezter();
        }

        public void ZeigeZurückButton(bool zeigeButton)
        {
            if(zeigeButton == true)
            {

                Button btnZurück = new Button();
                btnZurück.Text = "Zurück";
                btnZurück.Clicked += BtnZurück_Clicked;
                layout.Children.Insert(0,btnZurück);
            }
        }
    }
}
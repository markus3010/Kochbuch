using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class RezeptListView : ContentView
	{
        RezeptModel rezept;
        StackLayout layout;
        public RezeptListView(RezeptModel rezept)
        {
            this.rezept = rezept;
            
            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Start;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Orientation = StackOrientation.Horizontal;

            Content = layout;
            layout.Children.Add(new Label
            {
                Text = rezept.Titel,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            });
            layout.Children.Add(
                new Label
                {
                    Text = "von " + rezept.Autor,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                });
            int anzahlKochloeffel = (int) rezept.Schwierigkeit;
            do
            {
                layout.Children.Add(new Image
                {
                    HeightRequest = 50,
                    WidthRequest = 50,
                    Source = ImageSource.FromFile("Kochloeffel.png"),
                    HorizontalOptions = LayoutOptions.End,
                });
                anzahlKochloeffel--;
            }
            while (anzahlKochloeffel > -1);
            TapGestureRecognizer layoutTapRecognizer = new TapGestureRecognizer();
            layout.GestureRecognizers.Add(layoutTapRecognizer);
            layoutTapRecognizer.Tapped += LayoutTapRecognizer_Tapped;
        }

        private async void LayoutTapRecognizer_Tapped(object sender, EventArgs e)
        {
            Type currentType = ÜbersichtController.getInstance().GetCurrentContentType();
            if(typeof(EigeneRezepteView) == currentType)
            {
                await ÜbersichtController.getInstance().SetzeInhaltEigenesRezept(rezept.ID);
            }else if(typeof(OnlineRezepteView) == currentType)
            {
                ÜbersichtController.getInstance().SetzeInhaltOnlineRezept(rezept.ID);
            }
        }
    }
}
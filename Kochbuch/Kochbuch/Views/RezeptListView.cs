using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class RezeptListView : ContentView
	{
        StackLayout layout;
        ScrollView scroll;

        StackLayout layoutTitel;
        StackLayout layoutAutor;
        StackLayout layoutSchwierigkeit;

        public RezeptListView()
        {
            scroll = new ScrollView();
            scroll.VerticalOptions = LayoutOptions.Start;
            scroll.HorizontalOptions = LayoutOptions.FillAndExpand;
            scroll.Orientation = ScrollOrientation.Vertical;

            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Start;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Orientation = StackOrientation.Horizontal;

            this.Content = scroll;
            scroll.Content = layout;

            layoutTitel = new StackLayout();
            layoutAutor = new StackLayout();
            layoutSchwierigkeit = new StackLayout();

            layoutTitel.HorizontalOptions = LayoutOptions.StartAndExpand;
            layoutAutor.HorizontalOptions = LayoutOptions.StartAndExpand;
            layoutSchwierigkeit.HorizontalOptions = LayoutOptions.StartAndExpand;

            layout.Children.Add(layoutTitel);
            layout.Children.Add(layoutAutor);
            layout.Children.Add(layoutSchwierigkeit);
        }

        public void RezeptHinzufuegen(int ID, string titel, string autor, int schwierigkeit)
        {
            TapGestureRecognizer rezeptGestureRecoginizer = new TapGestureRecognizer();
            rezeptGestureRecoginizer.Tapped += (sender, EventArgs) =>
            {
                if(ÜbersichtController.getInstance().GetCurrentContentType() == typeof(OnlineRezepteView))
                {
                    OnlineRezepteController.getInstance().RezeptAusgewählt(ID);
                }
                else if(ÜbersichtController.getInstance().GetCurrentContentType() == typeof(EigeneRezepteView))
                {
                    EigeneRezepteController.getInstance().RezeptAusgewählt(ID);
                }
            };

            Label labelTitel = new Label();
            labelTitel.Text = titel;
            labelTitel.FontAttributes = FontAttributes.Bold;
            labelTitel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            labelTitel.HeightRequest = 50;
            labelTitel.HorizontalOptions = LayoutOptions.Center;
            labelTitel.GestureRecognizers.Add(rezeptGestureRecoginizer);
            layoutTitel.Children.Add(labelTitel);

            Label labelAutor = new Label();
            labelAutor.Text = "von " + autor;
            labelAutor.HeightRequest = 50;
            labelAutor.HorizontalOptions = LayoutOptions.Center;
            labelAutor.GestureRecognizers.Add(rezeptGestureRecoginizer);
            layoutAutor.Children.Add(labelAutor);

            StackLayout layoutLoeffel = new StackLayout();
            layoutLoeffel.Orientation = StackOrientation.Horizontal;
            layoutLoeffel.GestureRecognizers.Add(rezeptGestureRecoginizer);
            while (schwierigkeit > -1)
            {
                Image imageLoeffel = new Image();
                imageLoeffel.Source = ImageSource.FromFile("Kochloeffel.png");
                imageLoeffel.HeightRequest = 50;
                layoutLoeffel.Children.Add(imageLoeffel);
                schwierigkeit--;
            }
            layoutSchwierigkeit.Children.Add(layoutLoeffel);
        }
        public void RezepteLoeschen()
        {
            layoutTitel.Children.Clear();
            layoutAutor.Children.Clear();
            layoutSchwierigkeit.Children.Clear();
        }
    }
}
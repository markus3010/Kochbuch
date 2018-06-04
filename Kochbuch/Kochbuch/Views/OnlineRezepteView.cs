using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
    public class OnlineRezepteView : ContentView
    {
        private static OnlineRezepteView instance;
        private StackLayout layout;
        private StackLayout layoutLeiste;
        private RezeptListView rezeptListView;
        ActivityIndicator loadIcon;
        private OnlineRezepteView()
        {
            layout = new StackLayout();
            layout.Padding = new Thickness(10, 10);
            rezeptListView = new RezeptListView();

            this.Content = layout;

            layoutLeiste = new StackLayout();
            layoutLeiste.Orientation = StackOrientation.Horizontal;
            layoutLeiste.WidthRequest = 5000;

            Label labelÜberschrift = new Label();
            labelÜberschrift.Text = "Online Rezepte";
            labelÜberschrift.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            labelÜberschrift.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelÜberschrift.VerticalOptions = LayoutOptions.Center;
            layoutLeiste.Children.Add(labelÜberschrift);

            Image imageRefresh = new Image();
            imageRefresh.Source = ImageSource.FromFile("refresh.png");
            imageRefresh.HorizontalOptions = LayoutOptions.EndAndExpand;
            imageRefresh.HeightRequest = 50;
            TapGestureRecognizer refreshTapGestureRecognizer = new TapGestureRecognizer();
            imageRefresh.GestureRecognizers.Add(refreshTapGestureRecognizer);
            refreshTapGestureRecognizer.Tapped += RefreshTapGestureRecognizer_Tapped;
            layoutLeiste.Children.Add(imageRefresh);

            
            layout.Children.Add(layoutLeiste);
            layout.Children.Add(rezeptListView);
        }

        private async void RefreshTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await OnlineRezepteController.getInstance().Refresh();
        }

        public static OnlineRezepteView getInstance()
        {
            if (instance == null)
            {
                instance = new OnlineRezepteView();
            }
            return instance;
        }
        public void SetRezepte(List<RezeptModel> rezepte)
        {
            foreach (RezeptModel rezept in rezepte)
            {
                rezeptListView.RezeptHinzufuegen(rezept.ID, rezept.Titel, rezept.Autor, (int)rezept.Schwierigkeit);
            }
        }
        public void ShowLoadingIcon(bool show)
        {
            if(show == true)
            {
                loadIcon = new ActivityIndicator
                {
                    IsRunning = true

                };
                layout.Children.Add(loadIcon);
            }
            else
            {
                layout.Children.Remove(loadIcon);
            }
        }
        public void RezepteLoeschen()
        {
            rezeptListView.RezepteLoeschen();
        }
    }
}
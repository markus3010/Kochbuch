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
        private ScrollView scroll;
        private StackLayout layout;
        private StackLayout rezepteLayout;
        ActivityIndicator loadIcon;
        private OnlineRezepteView()
        {
            scroll = new ScrollView();
            layout = new StackLayout();
            rezepteLayout = new StackLayout();

            this.Content = layout;

            Label labelÜberschrift = new Label();
            labelÜberschrift.Text = "Online Rezepte";
            labelÜberschrift.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            labelÜberschrift.WidthRequest = 5000;
            layout.Children.Add(labelÜberschrift);

            layout.Children.Add(scroll);
            scroll.Content = rezepteLayout;
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
            rezepteLayout.Children.Clear();
            foreach (RezeptModel rezept in rezepte)
            {
                rezepteLayout.Children.Add(new RezeptListView(rezept));
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
    }
}
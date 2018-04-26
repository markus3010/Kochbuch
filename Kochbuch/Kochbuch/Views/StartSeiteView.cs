using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class StartSeiteView : ContentView
	{
        private ScrollView scroll;
        private StackLayout layout;
        private RezeptModel rezept;
        public StartSeiteView(RezeptModel rezept)
        {
            this.rezept = rezept;
            scroll = new ScrollView();
            this.Content = scroll;
            layout = new StackLayout();

            scroll.Content = layout;


            Image logo = new Image();
            logo.Source = ImageSource.FromFile("Mensch.png");

            Label willkommenLabel = new Label();
            willkommenLabel.Text = "MeiKochbuch! - Ihr Onlinekochbuch!";
            willkommenLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            willkommenLabel.FontAttributes = FontAttributes.Bold;
            willkommenLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Label tagLabel = new Label();
            tagLabel.Text = "Rezedesages";
            tagLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //tagLabel.FontAttributes = FontAttributes.Bold;
            tagLabel.HorizontalOptions = LayoutOptions.Start;



            RezeptView rezeptView = new RezeptView(rezept);

            rezeptView.Padding = new Thickness(20, 20, 20, 20);

            layout.Children.Add(logo);
            layout.Children.Add(willkommenLabel);
            layout.Children.Add(tagLabel);
            layout.Children.Add(rezeptView);
        }

        public void SetzeRezept(RezeptModel rezept)
        {
            this.rezept = rezept;
        }
    }
}
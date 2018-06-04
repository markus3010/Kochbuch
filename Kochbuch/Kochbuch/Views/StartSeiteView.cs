using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kochbuch
{
	public class StartSeiteView : ContentView
	{
        private ScrollView scroll;
        private StackLayout layout;
        private RezeptModel rezept;
        private static StartSeiteView instance;
        private StartSeiteView()
        {
            scroll = new ScrollView();
            this.Content = scroll;
            layout = new StackLayout();

            scroll.Content = layout;
            scroll.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;





            Image logo = new Image();
            logo.Source = ImageSource.FromFile("Logo.png");

            Label willkommenLabel = new Label();
            willkommenLabel.Text = "MeiKochbuch! - Ihr Onlinekochbuch!";
            willkommenLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            willkommenLabel.FontAttributes = FontAttributes.Bold;
            willkommenLabel.HorizontalOptions = LayoutOptions.Center;

            Label tagLabel = new Label();
            tagLabel.Text = "Rezept des Tages:";
            tagLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            tagLabel.HorizontalOptions = LayoutOptions.Start;
            tagLabel.Margin = new Thickness(10,10);
            tagLabel.WidthRequest = 5000;

            layout.Children.Add(logo);
            layout.Children.Add(willkommenLabel);
            layout.Children.Add(tagLabel);
            
        }
        public static StartSeiteView getInstance()
        {
            if(instance ==null)
            {
                instance = new StartSeiteView();
            }
            
            return instance;
        }
        public void SetzeRezeptView(RezeptView rezept)
        {
            if(layout.Children.Count > 3)
            {
                layout.Children.RemoveAt(3);
            }
            rezept.Padding = new Thickness(10, 10);
            layout.Children.Add(rezept);
        }
    }
}
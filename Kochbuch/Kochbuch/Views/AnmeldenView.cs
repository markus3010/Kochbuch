using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class AnmeldenView : ContentView
	{
        private ScrollView scroll;
        private StackLayout layout;
        private Entry entryName;
        private Button buttonAnmelden;
        private static AnmeldenView instance;
        private AnmeldenView()
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

            entryName = new Entry();
            entryName.Placeholder = "Benutzername";
            entryName.HorizontalOptions = LayoutOptions.Center;

            buttonAnmelden = new Button();
            buttonAnmelden.Text = "Anmelden";
            buttonAnmelden.HorizontalOptions = LayoutOptions.Center;
            buttonAnmelden.Clicked += ButtonAnmelden_Clicked;

            layout.Children.Add(logo);
            layout.Children.Add(willkommenLabel);
            layout.Children.Add(entryName);
            layout.Children.Add(buttonAnmelden);
        }

        private void ButtonAnmelden_Clicked(object sender, EventArgs e)
        {
            AnmeldenController.getInstance().Anmelden();
        }

        public static AnmeldenView getInstance()
        {
            if (instance == null)
            {
                instance = new AnmeldenView();
            }

            return instance;
        }
        public string GetName()
        {
            return entryName.Text;
        }
    }
}
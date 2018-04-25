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
            layout.Margin = new Thickness(20, 20, 20, 20);

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




        }
	}
}
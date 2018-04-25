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
            Content = scroll;
            layout = new StackLayout();
            scroll.Content = layout;

            layout.Children.Add(new Label
            {
                Text = rezept.titel,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            });
            layout.Children.Add(
                new Label
                {
                    Text = "von " + rezept.autor,
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
            foreach (ZutatModel zutat in rezept.zutaten)
            {
                layout.Children.Add(new ZutatView(zutat));
            }
            layout.Children.Add(new Label
            {
                Text = "Schwierigkeit: " + rezept.schwierigkeit,
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
                Text = rezept.beschreibung,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
            });
        }
    }
}
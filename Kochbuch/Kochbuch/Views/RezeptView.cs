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
            scroll.VerticalOptions = LayoutOptions.CenterAndExpand;
            Content = scroll;
            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;
            layout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            scroll.Content = layout;

            layout.Children.Add(new Label
            {
                Text = rezept.Titel,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class ZutatView : ContentView
	{
        private ZutatModel zutat;
        public ZutatView(ZutatModel zutat)
        {
            this.zutat = zutat;
            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    new Label {
                        Text = zutat.menge.ToString(),
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = 20
                    },
                    new Label
                    {
                        Text = zutat.einheit,
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = 20
                    },
                    new Label
                    {
                        Text = zutat.art,
                        HorizontalOptions = LayoutOptions.Start
                    }
                }
            };
        }
    }
}
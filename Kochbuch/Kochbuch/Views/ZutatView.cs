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
                        Text = zutat.Menge.ToString(),
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = 20
                    },
                    new Label
                    {
                        Text = zutat.Einheit,
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = 20
                    },
                    new Label
                    {
                        Text = zutat.Art,
                        HorizontalOptions = LayoutOptions.Start
                    }
                }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class Page1 : ContentPage
	{
        StackLayout layout;
        
        Seitenleiste leiste;
		public Page1 ()
		{
            layout = new StackLayout();
            if(Height > Width)
            {
                layout.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                layout.Orientation = StackOrientation.Vertical;
            }
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.BackgroundColor = Color.Azure;

            layout.HeightRequest = Height;
            layout.WidthRequest = Width;
            
            leiste = Seitenleiste.getInstance(Width,Height);
            
            this.Content = layout;
            layout.Children.Add(leiste);
        }

      
    }
}
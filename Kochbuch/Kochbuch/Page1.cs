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
       
		public Page1 ()
		{
            layout = new StackLayout();
            Content = layout;
            layout.Children.Add(new RezeptErstellenView());
        }

      
    }
}
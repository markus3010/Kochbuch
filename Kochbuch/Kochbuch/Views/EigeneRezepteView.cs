using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class EigeneRezepteView : ContentView
	{
        private static EigeneRezepteView instance;
        private ScrollView scroll;
        private StackLayout layout;
        private StackLayout rezepteLayout;
		private EigeneRezepteView ()
		{
            scroll = new ScrollView();
            layout = new StackLayout();
            rezepteLayout = new StackLayout();

            this.Content = layout;

            Label labelÜberschrift = new Label();
            labelÜberschrift.Text = "Eigene Rezepte";
            labelÜberschrift.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            labelÜberschrift.WidthRequest = 5000;
            layout.Children.Add(labelÜberschrift);

            layout.Children.Add(scroll);
            scroll.Content = rezepteLayout;
		}
        public static EigeneRezepteView getInstance()
        {
            if(instance == null)
            {
                instance = new EigeneRezepteView();
            }
            return instance;
        }
        public void SetRezepte(List<RezeptModel>rezepte)
        {
            rezepteLayout.Children.Clear();
            foreach(RezeptModel rezept in rezepte)
            {
                rezepteLayout.Children.Add(new RezeptListView(rezept));
            }
        }
	}
}
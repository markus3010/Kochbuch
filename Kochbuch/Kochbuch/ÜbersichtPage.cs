using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class ÜbersichtPage : ContentPage
	{
        static ÜbersichtPage instance;
        StackLayout layout;
        Seitenleiste leiste;
        private int count;

        private int adjustedWidth;
        private int adjustedHeigth;
        private LokalDb db;
        private ÜbersichtPage()
        {
            
            db = LokalDb.GetInstance();
            layout = new StackLayout();
            Content = layout;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.SizeChanged += ÜbersichtPage_SizeChanged;
            
        }

        private void ÜbersichtPage_SizeChanged(object sender, EventArgs e)
        {
            if (Height > 0 && Width > 0)
            {
                

                if (Height > Width)
                {
                    if(layout.Orientation == StackOrientation.Horizontal || Math.Abs(adjustedHeigth - Height) > 100 || Math.Abs(adjustedWidth - Width) > 100)
                    {
                        if (count > 0)
                        {
                            layout.Children.RemoveAt(0);
                        }
                        layout.Orientation = StackOrientation.Vertical;
                        layout.Children.Insert(0, Seitenleiste.getInstance(Height, Width));
                        adjustedHeigth = (int) Height;
                        adjustedWidth = (int)Width;
                    }
                    
                }
                else
                {
                    if (layout.Orientation == StackOrientation.Vertical || Math.Abs(adjustedHeigth - Height) > 100 || Math.Abs(adjustedWidth - Width) > 100)
                    {
                        if (count > 0)
                        {
                            layout.Children.RemoveAt(0);
                        }

                        layout.Orientation = StackOrientation.Horizontal;
                        layout.Children.Insert(0, Seitenleiste.getInstance(Height, Width));
                        adjustedHeigth = (int)Height;
                        adjustedWidth = (int)Width;
                    }
                    
                }
                count++;
            }
        }

        public static ÜbersichtPage getInstance()
        {
            if (instance == null)
            {
                instance = new ÜbersichtPage();
                return instance;
            }
            else
            {
                return instance;
            }
        }
        public static void ShowAlert(string message1,string message2)
        {
            instance.DisplayAlert(message1, message2,"OK");
        }
        public void SetContent(View view)
        {
            //ShowAlert("ALERT",layout.Children.Count.ToString());
            if(layout.Children.Count > 1)
            {
                layout.Children.RemoveAt(1);
            }
            //ShowAlert("ALERT", layout.Children.Count.ToString());
            layout.Children.Add(view);
        }
    }
}
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
        private ÜbersichtPage()
        {


            RezeptModel rezept =
               new RezeptModel
               {
                   Titel = "Schnitzel",
                   Autor = "Markus Gahr",
                   Schwierigkeit = RezeptModel.schwierigkeit.Leicht,
                   Zutaten = new List<ZutatModel>
                       {
                            new ZutatModel
                            {
                                menge = 4,
                                einheit = "",
                                art = "Kalbsschnitzel"
                            },
                            new ZutatModel
                            {
                                menge = 2,
                                einheit = "",
                                art = "Eier"
                            },
                            new ZutatModel
                            {
                                menge = 2,
                                einheit = "EL",
                                art = "geschlangene Sahne"
                            }
                       },
                   Beschreibung = @"Fleisch nacheinander in einem großen Gefrierbeutel ca. 5 mm dünn plattieren.
    Eier und geschlagene Sahne in einer Schale mit der Gabel verquirlen. Die Sahne am besten schlagen, weil die Panierung dadurch luftiger wird.
    Mehl und Semmelbrösel in 2 Schalen geben. Schnitzel rundum leicht mit
     Salz würzen und nacheinander kurz in Mehl wenden. Die gesamte Oberfläche sollte gleichmäßig bemehlt sein, damit die Panierung gut hält. Überschüssiges Mehl abklopfen.
    Schnitzel durch die Eiersahne ziehen und sofort in den Semmelbröseln wenden. Die Brösel nur leicht andrücken, nicht anpressen!
    Schnitzel sofort in reichlich heißem (170 Grad) Butterschmalz in einer großen Pfanne auf jeder Seite ca. 3 Minuten unter gelegentlichem schwenken goldgelb ausbacken.
    Schnitzel auf Küchenpapier abtropfen lassen und mit Petersilienkartoffeln, Gurkensalat (siehe Rezept: Gurkensalat) und Zitronenspalten servieren.
    Warm halten bekommt Schnitzeln nicht. Am besten backen Sie sie frisch, teilen und backen dann die Nächsten."

               };



            layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Content = layout;
            layout.Children.Add(new StartSeiteView(rezept));
            
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
        public void SetRezepte(List<RezeptModel> rezepte)
        {
            ScrollView rezepeteScroll = new ScrollView();

            layout.Children.Add(rezepeteScroll);
            StackLayout rezepeteScrollLayout = new StackLayout();
            
            rezepeteScrollLayout.Padding = new Thickness(50, 50, 50, 50);
            rezepeteScroll.Content = rezepeteScrollLayout;
            foreach (RezeptModel rezept in rezepte)
            {
                rezepeteScrollLayout.Children.Add(new RezeptView(rezept));
            }
        }
    }
}
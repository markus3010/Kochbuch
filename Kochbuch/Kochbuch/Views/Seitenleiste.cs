﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class Seitenleiste : ContentView
	{
        private static Seitenleiste instance;
        private double scale = 0.1;
        private int imageSize = 244;
        
        private int imageHeight = 100;
        private int imageWidth = 100;

        private int parentWidth;
        private int parentHeight;

        private StackLayout layout;

        private List<Image> images;
        
        private Seitenleiste()
        {
            layout = new StackLayout();
            this.Content = layout;
        }

        

        public static Seitenleiste getInstance(double parentWidth, double parentHeight)
        {
            if (instance == null)
            {
                instance = new Seitenleiste();
            }
            instance.UpdateSize(parentWidth, parentHeight);
            return instance;
        }
        public void UpdateSize(double width, double heigth)
        {
            layout.Children.Clear();
            
            parentWidth =   (int) width;
            parentHeight = (int) heigth;

            scale = 0.1;
            imageHeight = (int)(scale * heigth);
            imageWidth = (int)(scale * width);
            
            if(heigth > width)
            {
                layout.Orientation = StackOrientation.Vertical;
                
                layout.VerticalOptions = LayoutOptions.CenterAndExpand;

                layout.HorizontalOptions = LayoutOptions.Start;
            }
            else
            {
                layout.Orientation = StackOrientation.Horizontal;
               
                layout.HorizontalOptions = LayoutOptions.CenterAndExpand;

                layout.VerticalOptions = LayoutOptions.Start;
            }
            
        
            
            images = new List<Image>();

            Image imageHaus = new Image();
            imageHaus.Source = ImageSource.FromFile("Haus.png");
            images.Add(imageHaus);

            Image imageErde = new Image();
            imageErde.Source = ImageSource.FromFile("Erde.png");
            images.Add(imageErde);

            Image imageMensch = new Image();
            imageMensch.Source = ImageSource.FromFile("Mensch.png");
            images.Add(imageMensch);

            Image imageKreuz = new Image();
            imageKreuz.Source = ImageSource.FromFile("Kreuz.png");
            images.Add(imageKreuz);

            
            foreach(Image image in images)
            {
                if(layout.Orientation == StackOrientation.Vertical)
                {
                    image.HeightRequest = imageHeight;
                    image.VerticalOptions = LayoutOptions.CenterAndExpand;
                    image.HorizontalOptions = LayoutOptions.CenterAndExpand;
                }
                else
                {
                    image.WidthRequest = imageWidth;
                    image.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    image.VerticalOptions = LayoutOptions.CenterAndExpand;
                }
            }
            TapGestureRecognizer imageHausTapRecognizer = new TapGestureRecognizer();
            imageHaus.GestureRecognizers.Add(imageHausTapRecognizer);
            imageHausTapRecognizer.Tapped += ImageHausTapRecognizer_Tapped;

            TapGestureRecognizer imageErdeTapRecoginzer = new TapGestureRecognizer();
            imageErde.GestureRecognizers.Add(imageErdeTapRecoginzer);
            imageErdeTapRecoginzer.Tapped += ImageErdeTapRecoginzer_Tapped;

            TapGestureRecognizer imageMenschTapRecognizer = new TapGestureRecognizer();
            imageMensch.GestureRecognizers.Add(imageMenschTapRecognizer);
            imageMenschTapRecognizer.Tapped += ImageMenschTapRecognizer_Tapped;

            TapGestureRecognizer imageKreuzTapRecognizer = new TapGestureRecognizer();
            imageKreuz.GestureRecognizers.Add(imageKreuzTapRecognizer);
            imageKreuzTapRecognizer.Tapped += ImageKreuzTapRecognizer_Tapped;

            layout.Children.Add(imageHaus);
            layout.Children.Add(imageErde);
            layout.Children.Add(imageMensch);
            layout.Children.Add(imageKreuz);
            
        }

        private void ImageErdeTapRecoginzer_Tapped(object sender, EventArgs e)
        {
            ÜbersichtController.getInstance().SetzeInhaltOnlineRezepte();
        }

        private void ImageKreuzTapRecognizer_Tapped(object sender, EventArgs e)
        {
            ÜbersichtController.getInstance().SetzeInhaltRezeptErstellen();
        }

        private async void ImageMenschTapRecognizer_Tapped(object sender, EventArgs e)
        {
            await ÜbersichtController.getInstance().SetzeInhaltEigeneRezepte();
        }

        private async void ImageHausTapRecognizer_Tapped(object sender, EventArgs e)
        {
            await ÜbersichtController.getInstance().SetzeInhaltStartSeite();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class ZutatErstelltView : ContentView
	{
        StackLayout layout;
        private Label labelMenge;
        private Label labelEinheit;
        private Label labelZutat;
        public ZutatErstelltView()
        {
            layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.BackgroundColor = Color.LightGray;
            labelMenge = new Label {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            labelEinheit = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            labelZutat = new Label
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(labelMenge);
            layout.Children.Add(labelEinheit);
            layout.Children.Add(labelZutat);

            Image  btnBearbeiten = new Image();
            btnBearbeiten.Source = (FileImageSource)ImageSource.FromFile("Bearbeiten.png");
            btnBearbeiten.HorizontalOptions = LayoutOptions.End;
            TapGestureRecognizer recognizerBearbeiten = new TapGestureRecognizer();
            btnBearbeiten.GestureRecognizers.Add(recognizerBearbeiten);
            recognizerBearbeiten.Tapped += BtnBearbeiten_Clicked;
            btnBearbeiten.WidthRequest = 25;

            btnBearbeiten.HeightRequest = 25;
            layout.Children.Add(btnBearbeiten);

            this.Content = layout;
        }

        public string GetArt()
        {
            return labelZutat.Text;
        }

        public string GetEinheit()
        {
            return labelEinheit.Text;
        }

        public  int GetMenge()
        {
            int menge = 0;
            try { menge = Convert.ToInt32(labelMenge.Text); }
            catch
            {
                return -1;
            }
            return menge;
        }
        public void SetMenge(int menge)
        {
            labelMenge.Text = menge.ToString();
            //ÜbersichtPage.ShowAlert("ALERT", menge.ToString());
        }
        public void SetEinheit(string einheit)
        {
            labelEinheit.Text = einheit;

           // ÜbersichtPage.ShowAlert("ALERT",einheit);
        }
        public void SetZutat(string zutat)
        {
            labelZutat.Text = zutat;
            //ÜbersichtPage.ShowAlert("ALERT", zutat);
        }
        private void BtnBearbeiten_Clicked(object sender, EventArgs e)
        {
            RezeptErstellenController.getInstance().ZutatBearbeiten(this);
        }
    }
}
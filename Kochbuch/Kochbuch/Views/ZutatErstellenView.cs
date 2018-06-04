using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public class ZutatErstellenView : ContentView
	{
        private StackLayout layout;
        private ScrollView scroll;
        private Entry entryMenge;
        private Entry entryEinheit;
        private Entry entryZutat;

        private StackLayout layoutLeft;
        private StackLayout layoutMid;
        private StackLayout layoutRight;

        public ZutatErstellenView()
        {
          
            layout = new StackLayout();
            Content = layout;


            layoutLeft = new StackLayout();
            layoutMid = new StackLayout();
            layoutRight = new StackLayout();
            layoutLeft.Orientation = StackOrientation.Vertical;
            layoutMid.Orientation = StackOrientation.Vertical;
            layoutRight.Orientation = StackOrientation.Vertical;
            layout.Children.Add(layoutLeft);
            layout.Children.Add(layoutMid);
            layout.Children.Add(layoutRight);

            
            layout.Orientation = StackOrientation.Horizontal;
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Margin = new Thickness(20, 20, 20, 20);

            Label labelMenge = new Label();
            labelMenge.Text = "Menge";
            labelMenge.HorizontalOptions = LayoutOptions.StartAndExpand;

            entryMenge = new Entry();
            entryMenge.Placeholder = "Menge";
            entryMenge.PlaceholderColor = Color.LightGray;
            entryMenge.HorizontalOptions = LayoutOptions.FillAndExpand;
          

            Label labelEineheit = new Label();
            labelEineheit.Text = "Einheit (z.B. Gramm,  EL)";
            if(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                labelEineheit.Text = "Einheit";
            }
            labelEineheit.HorizontalOptions = LayoutOptions.StartAndExpand;

            entryEinheit = new Entry();
            entryEinheit.Placeholder = "Einheit";
            entryEinheit.PlaceholderColor = Color.LightGray;
            entryEinheit.HorizontalOptions = LayoutOptions.FillAndExpand;


            Label labelZutat = new Label();
            labelZutat.Text = "Zutat";
            labelZutat.HorizontalOptions = LayoutOptions.StartAndExpand;

            entryZutat = new Entry();
            entryZutat.Placeholder = "Zutat";
            entryZutat.PlaceholderColor = Color.LightGray;
            entryZutat.HorizontalOptions = LayoutOptions.FillAndExpand;

            layoutLeft.Children.Add(labelMenge);
            layoutLeft.Children.Add(entryMenge);
            layoutMid.Children.Add(labelEineheit);
            layoutMid.Children.Add(entryEinheit);
            layoutRight.Children.Add(labelZutat);
            layoutRight.Children.Add(entryZutat);

            layoutLeft.HorizontalOptions = LayoutOptions.StartAndExpand;
            layoutMid.HorizontalOptions = LayoutOptions.StartAndExpand;
            layoutRight.HorizontalOptions = LayoutOptions.StartAndExpand;

            Image imageLöschen = new Image();
            imageLöschen.WidthRequest = 35;
            imageLöschen.HeightRequest = 35;
            imageLöschen.Source = (FileImageSource)ImageSource.FromFile("Loeschen.png");
            imageLöschen.HorizontalOptions = LayoutOptions.End;
            TapGestureRecognizer recognizerLöschen = new TapGestureRecognizer();
            imageLöschen.GestureRecognizers.Add(recognizerLöschen);
            recognizerLöschen.Tapped += RecognizerLöschen_Tapped;
            layout.Children.Add(imageLöschen);


            Image imageSpeichern = new Image();
            imageSpeichern.WidthRequest = 35;
            imageSpeichern.HeightRequest = 35;
            imageSpeichern.Source = (FileImageSource) ImageSource.FromFile("Speichern.png");
            imageSpeichern.HorizontalOptions = LayoutOptions.End;
            TapGestureRecognizer recognizerSpeichern = new TapGestureRecognizer();
            imageSpeichern.GestureRecognizers.Add(recognizerSpeichern);
            recognizerSpeichern.Tapped += RecognizerSpeichern_Tapped;
            layout.Children.Add(imageSpeichern);
        }

        private void RecognizerLöschen_Tapped(object sender, EventArgs e)
        {
            RezeptErstellenView.getInstance().ZutatLöschen(this);
        }

        private void RecognizerSpeichern_Tapped(object sender, EventArgs e)
        {
            RezeptErstellenController.getInstance().ZuatatHinzufuegen(this);
        }

        public void SetMenge(int menge)
        {
            entryMenge.Text = menge.ToString();
        }
        public void SetEinheit(string einheit)
        {
            entryEinheit.Text = einheit;
        }
        public void SetZutat(string zutat)
        {
            entryZutat.Text = zutat;
        }
        public int GetMenge()
        {
            int menge = 0;
            try { menge = Convert.ToInt32(entryMenge.Text); }
            catch
            {
                return -1;
            }
            return menge;
        }
        public string  GetEinheit()
        {
            return entryEinheit.Text;
        }
        public string GetZutat()
        {
            return entryZutat.Text;
        }
    }
    
}
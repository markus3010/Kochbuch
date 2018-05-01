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
        public ZutatErstellenView()
        {
          
            layout = new StackLayout();
            Content = layout;
            layout.Orientation = StackOrientation.Horizontal;
            if(Device.RuntimePlatform == Device.Android)
            {
                layout.Orientation = StackOrientation.Horizontal;
            }
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Margin = new Thickness(20, 20, 20, 20);

            Label labelMenge = new Label();
            labelMenge.Text = "Menge";
            layout.Children.Add(labelMenge);
            labelMenge.HorizontalOptions = LayoutOptions.Start;

            entryMenge = new Entry();
            entryMenge.Placeholder = "Menge";
            entryMenge.PlaceholderColor = Color.LightGray;
            layout.Children.Add(entryMenge);
            entryMenge.HorizontalOptions = LayoutOptions.FillAndExpand;
          

            Label labelEineheit = new Label();
            labelEineheit.Text = "Einheit (z.B. Gramm,  EL)";
            layout.Children.Add(labelEineheit);
            labelEineheit.HorizontalOptions = LayoutOptions.Start;

            entryEinheit = new Entry();
            entryEinheit.Placeholder = "Einheit";
            entryEinheit.PlaceholderColor = Color.LightGray;
            layout.Children.Add(entryEinheit);
            entryEinheit.HorizontalOptions = LayoutOptions.FillAndExpand;


            Label labelZutat = new Label();
            labelZutat.Text = "Zutat";
            layout.Children.Add(labelZutat);
            labelZutat.HorizontalOptions = LayoutOptions.Start;

            entryZutat = new Entry();
            entryZutat.Placeholder = "Zutat";
            entryZutat.PlaceholderColor = Color.LightGray;
            layout.Children.Add(entryZutat);
            entryZutat.HorizontalOptions = LayoutOptions.FillAndExpand;

            Image btnSpeichern = new Image();
            btnSpeichern.WidthRequest = 25;
            btnSpeichern.HeightRequest = 25;
            btnSpeichern.Source = (FileImageSource) ImageSource.FromFile("Save.png");
            btnSpeichern.HorizontalOptions = LayoutOptions.End;
            TapGestureRecognizer recognizerSpeichern = new TapGestureRecognizer();
            btnSpeichern.GestureRecognizers.Add(recognizerSpeichern);
            recognizerSpeichern.Tapped += RecognizerSpeichern_Tapped;
            layout.Children.Add(btnSpeichern);
        }

        private void RecognizerSpeichern_Tapped(object sender, EventArgs e)
        {
            RezeptErstellenController.getInstance().ZuatatHizufuegen(this);
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
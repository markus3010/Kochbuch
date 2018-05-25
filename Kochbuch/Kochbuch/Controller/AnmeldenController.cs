using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kochbuch
{
    class AnmeldenController
    {
        private static AnmeldenController instance;
        private ContentPage page;
        public static AnmeldenController getInstance()
        {
            if(instance == null)
            {
                instance = new AnmeldenController();
            }
            return instance;
        }
        public void Anmelden()
        {
            string name = AnmeldenView.getInstance().GetName();
            if(name != "")
            {
                Application.Current.Properties["username"] = name;
                page = ÜbersichtPage.getInstance();
                Application.Current.MainPage = page;
            }
            else
            {
                page.DisplayAlert("Achtung", "Benutzername kann nicht leer sein", "OK");
            }
        }
        public ContentPage GetPage()
        {
            string name;
            try
            {
                name = Application.Current.Properties["username"].ToString();
            }
            catch
            {
                Application.Current.Properties["username"] = "";
                name = "";
            }
            if(name == "")
            {
                page = new ContentPage
                {
                    Content = AnmeldenView.getInstance()
                };
            }
            else
            {
                page = ÜbersichtPage.getInstance();
            }
            return page;
        } 
    }
}

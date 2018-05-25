using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kochbuch
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            
            MainPage = AnmeldenController.getInstance().GetPage();
            //MainPage = new Page1();
		}

		protected override void OnStart ()
		{
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

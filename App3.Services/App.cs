using App3.Repository;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class App : Application
	{
        private static UserDb db;
        public static UserDb DB
        {
            get
            {
                if (db == null)
                {
                    db = new UserDb();
                }
                return db;
            }
        } 

        public App ()
		{
            // The root page of your application
            db = new UserDb();
            MainPage = new NavigationPage(new LoginPage());			
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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

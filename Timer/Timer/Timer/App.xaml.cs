using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timer.Data;
using Timer.Helper;
using Timer.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Timer
{
    public partial class App : Application
    {
        static ConfigDatabase database;
        public static TimerViewModel ViewModel { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new Timer.TabbedLandingPage();
        }

        public static ConfigDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ConfigDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Config.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

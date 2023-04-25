using System;
using System.IO;
using System.Reflection;
using App2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App2
{
    public partial class App : Application
    {

        protected static DatabaseHelper _databaseHelper;

        public static DatabaseHelper _DatabaseHelper
        {
            get
            {
                if (_databaseHelper==null)
                    _databaseHelper = new DatabaseHelper(GetDatabasePath());
                return _databaseHelper;
            }
        }
        
        public static string GetDatabasePath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "App2.Data.data.sqlite"; // Update with your actual resource name
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.sqlite");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                resourceStream.CopyTo(fileStream);
            }

            return path;
        }
        public App()
        {
            InitializeComponent();
            MainPage = new Person();
            MainPage = new NavigationPage(new MainPage());
           
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
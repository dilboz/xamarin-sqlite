using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Model;
using App2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace App2
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void ShowLoginView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView());
        }

    }
}
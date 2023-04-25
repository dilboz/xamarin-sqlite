using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            EMail.Text = "t.pakhtaobod@aholi.tj";
        }

        private List<User> _users = new List<User>();

        private  void GetUsers(object sender, EventArgs e)
        {
            string email = EMail.Text;
            string password = Password.Text;

            string sqlQuery = $"SELECT id, Email, PasswordHash  from 'dbo.AspNetUsers' danu WHERE  danu.Email = '{email}';";

            _users = App._DatabaseHelper.GetUsers(sqlQuery);

            if (_users.Count>0)
            {
                Navigation.PushAsync(new Person());
                DataSettings.IDUser = _users[0].Id.ToString();
            }
            else
            {
                AnswerLog.Text = "OO noo";
            }
        }
    }
}
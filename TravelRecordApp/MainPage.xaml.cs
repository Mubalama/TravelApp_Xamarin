using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogingButton_Clicked(object sender, EventArgs e)
        {

            // Form validation for email and password to check if they are not empty

            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            //string message = "Please fill in all the fields !";

            if (isEmailEmpty || isPasswordEmpty)
            {
                //lblMessage.Text = message;
            }
            else
            {
                //lblMessage.Text = "You have successfully logged in"
                //Navigation to another page
                Navigation.PushAsync(new HomePage());
            }

        }
    }
}

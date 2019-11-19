using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Inserting the data into database

            Post post = new Post()
            {
                // insert the experience into database not the ID as the ID is already set as auto increment
                Experience = experienceEntry.Text
            };


            // Create a connection to the Database
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) //we can use the using statement directly to close connection instead of using the close method
            {
                //Create a database table
                conn.CreateTable<Post>();
                //Insert into the database
                int rows = conn.Insert(post); /// here we add the int rows variable to evaluate if insert was successful

                //we need to close the connection
                //conn.Close();

                // evaluate if the insert is successful or not
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience fail to insert", "Ok");
            }


        }
    }
}
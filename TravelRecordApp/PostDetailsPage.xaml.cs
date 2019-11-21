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
    public partial class PostDetailsPage : ContentPage
    {
        // Creating a global property of type post
        Post selectedPost;
        public PostDetailsPage(Post selectedPost)
        {
            InitializeComponent();
            // Initialize the accessibility of the post
            this.selectedPost = selectedPost;

            // We set the selected post to a text as soon as we get it 
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            //edit the selected post
            selectedPost.Experience = experienceEntry.Text;

            // Create a connection to the Database
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) //we can use the using statement directly to close connection instead of using the close method
            {
                //Create a database table
                conn.CreateTable<Post>();
                //Update the table in database
                int rows = conn.Update(selectedPost); /// here we add the int rows variable to evaluate if insert was successful

                //we need to close the connection
                //conn.Close();

                // evaluate if the insert is successful or not
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully Updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience fail to insert", "Ok");
            }
        }

        private void DeletButton_Clicked(object sender, EventArgs e)
        {
            // to delete we just need to call a delete method

            // Create a connection to the Database
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) //we can use the using statement directly to close connection instead of using the close method
            {
                //Create a database table
                conn.CreateTable<Post>();
                //Delete from the database
                int rows = conn.Delete(selectedPost); /// here we add the int rows variable to evaluate if insert was successful

                //we need to close the connection
                //conn.Close();

                // evaluate if the insert is successful or not
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully Deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience fail to insert", "Ok");
            }
        }
    }
}
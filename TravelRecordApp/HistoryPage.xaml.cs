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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }
        // Reading data from the database
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) //we can use the using statement directly to close connection instead of using the close method
            {
                conn.CreateTable<Point>();
                var post = conn.Table<Post>().ToList();
                //conn.Close();
                //// defining the source of data list
                postListView.ItemsSource = post;

            }

        }

        private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //create the variable of type post
            var selectedPost = postListView.SelectedItem as Post;

            //evaluate if selected post has a value
            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailsPage(selectedPost));
            }
        }
    }
}
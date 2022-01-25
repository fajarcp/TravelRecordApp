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
    public partial class PostDetailView : ContentPage
    {
        Post selectedPost;
        public PostDetailView(Post postSelected)
        {
            InitializeComponent();
            this.selectedPost = postSelected;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Successful", "Experience updated successfully!", "ok");
                }
                else
                {
                    DisplayAlert("Failed", "Experience cannot be updated successfully!", "ok");
                }
            }

        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Successful", "Experience deleted successfully!", "ok");
                }
                else
                {
                    DisplayAlert("Failed", "Experience cannot be deleted successfully!", "ok");
                }
            }
        }
    }
}
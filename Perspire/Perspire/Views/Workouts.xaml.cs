using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    

    public partial class Workouts : ContentPage
    {
        public IList<Workout> workout_list { get; set; }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Workout selectedItem = e.SelectedItem as Workout;
        }
        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Workout tappedItem = e.Item as Workout;
        }

        public Workouts ()
        {
            InitializeComponent();

            workout_list = new List<Workout>();
            workout_list.Add(new Workout
            {
                Name = "Deadlift",
                Part = "Back",
                ImageSrc = ""
            }) ;

            workout_list.Add(new Workout
            {
                Name = "Bench Press",
                Part = "Chest",
                ImageSrc = ""
            });

            BindingContext = this;
        }
    }

}
using System;
using Perspire.ViewModels;
using Perspire.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    public partial class WorkoutList : ContentPage
    {
        public WorkoutList()
        {
            var data = new WorkoutListViewModel();
            InitializeComponent();
            BindingContext = data;
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Workout;
            await Navigation.PushModalAsync(new WorkoutListDetail(details.Name, details.Description, details.ImageSrc));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WorkoutEdit());
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            int selecteddIndex = ((WorkoutListViewModel)BindingContext).WorkoutList.IndexOf((GroupedWorkoutModel)(sender as StackLayout).BindingContext);
            ((WorkoutListViewModel)BindingContext).ToggleVis(selecteddIndex);
            System.Console.WriteLine("Tapped header {0}, expanded is now {1}", selecteddIndex, ((WorkoutListViewModel)BindingContext).WorkoutList[selecteddIndex].Expanded);
        }
    }
}
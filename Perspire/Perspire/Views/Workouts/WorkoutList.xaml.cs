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
            var details = e.Item as WorkoutModel;
            await Navigation.PushModalAsync(new WorkoutListDetail(details.Name, details.Description, details.ImageSrc));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WorkoutEdit());
        }
    }
}
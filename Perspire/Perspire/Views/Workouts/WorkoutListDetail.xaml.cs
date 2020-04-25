using Perspire.DataStore;
using Perspire.Models;
using Perspire.ViewModels.Workouts;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    [QueryProperty("Name", "name")]
    public partial class WorkoutListDetail : ContentPage
    {

        WorkoutDetailViewModel data = DependencyService.Resolve<WorkoutDetailViewModel>();

        public WorkoutListDetail()
        {
            InitializeComponent();

            BindingContext = data;

        }

        public string Name
        {
            set
            {
                data.MName = Uri.UnescapeDataString(value);
            }
        }


        private async void Back(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
        private async void Ediit(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"WorkoutEdit?name={data.MName}");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
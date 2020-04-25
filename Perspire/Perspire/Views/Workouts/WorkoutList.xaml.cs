using System;
using Perspire.ViewModels;
using Perspire.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Perspire.Controls;
using System.Windows.Input;

namespace Perspire.Views
{
    public partial class WorkoutList : ContentPage
    {
        public WorkoutList()
        {
            var data = DependencyService.Resolve<WorkoutListViewModel>();

            InitializeComponent();
            BindingContext = data;
        }

        private async void OpenFilter(Object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new ProgramFilter());
        }


        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as WorkoutModel;
            //await Navigation.PushModalAsync(new WorkoutListDetail(details));
            await Shell.Current.GoToAsync($"WorkoutDetail?name={details.Name}");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("WorkoutEdit");
        }
    }
}
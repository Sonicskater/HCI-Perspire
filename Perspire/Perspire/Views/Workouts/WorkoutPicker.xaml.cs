using System;
using Perspire.ViewModels;
using Perspire.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Perspire.Controls;
using System.Windows.Input;

namespace Perspire.Views
{
    public partial class WorkoutPicker : ContentPage
    {
        public WorkoutPickerViewModel data = DependencyService.Resolve<WorkoutPickerViewModel>();
        public WorkoutPicker()
        {
            

            InitializeComponent();
            BindingContext = data;
        }

        private async void OpenFilter(Object sender, EventArgs e)
        {

            //await Navigation.PushModalAsync(new ProgramFilter());
        }


        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as WorkoutModel;
            data.OnWorkoutPicked(details);
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("WorkoutEdit");
        }
    }
}
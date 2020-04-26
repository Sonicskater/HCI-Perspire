using Perspire.ViewModels.Workouts;
using Plugin.Toasts;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    [QueryProperty("Name","name")]
    public partial class WorkoutEdit : ContentPage
    {
        private string _name;
        public string Name
        {
            set
            {
                _name = value;
                data.MName = Uri.UnescapeDataString(_name);
            }
            get
            {
                return _name;
            }
        }
        WorkoutEditViewModel data = DependencyService.Resolve<WorkoutEditViewModel>();
        public WorkoutEdit ()
        {
            InitializeComponent();            
            BindingContext = data;
        }

        public async void OnClickBack(Object sender, EventArgs e)
        {

            await Shell.Current.Navigation.PopModalAsync();

        }


        public async void OnClickSave(Object sender, EventArgs e)
        {
            if (data.Save())
            {
                await Shell.Current.Navigation.PopModalAsync();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            var options = new NotificationOptions()
            {
                Title = "Sorry!",
                Description = "This Feature has not been implemented"
            };

            notificator.Notify(options);
        }
    }
}
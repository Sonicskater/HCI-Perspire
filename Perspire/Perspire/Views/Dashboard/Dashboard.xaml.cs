﻿using Perspire.Controls;
using Perspire.ViewModels;
using Plugin.Toasts;
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
    public partial class Dashboard : ContentPage
    {
        DashBoardViewModel vm = DependencyService.Resolve<DashBoardViewModel>();
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = vm;
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            var x = new WorkoutPicker();
            await Navigation.PushModalAsync(x);
            var result = await x.data.PickWorkout();
            await Navigation.PopModalAsync();

            await Shell.Current.GoToAsync($"WorkoutDetail?name={result.Name}");
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            var options = new NotificationOptions()
            {
                Title = "Sorry!",
                Description = "This Feature has not been implemented"
            };

            notificator.Notify(options);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            var data = (StatViewModel)((Entry)sender).BindingContext;
            data.SaveNew();
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
using Perspire.ViewModels.Workouts;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    public partial class WorkoutEdit : ContentPage
    {
        WorkoutEditViewModel data = DependencyService.Resolve<WorkoutEditViewModel>();
        public WorkoutEdit ()
        {
            

            InitializeComponent();
            BindingContext = data;
        }

        public void OnClickSave(Object sender, EventArgs e)
        {
            data.Save();
        }


    }
}
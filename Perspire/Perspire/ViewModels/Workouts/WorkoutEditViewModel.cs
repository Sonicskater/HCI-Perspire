using Perspire.DataStore;
using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels.Workouts
{
    class WorkoutEditViewModel : BaseViewModel
    {

        public string WorkoutName
        {
            get; set;
        }

        public string WorkoutDescription { get; set; }

        DataRepository datastore = DependencyService.Resolve<DataRepository>();

        public void Save()
        {
            var obj = new WorkoutModel
            {
                Name = WorkoutName,
                Description = WorkoutDescription
            };

            System.Console.WriteLine("Saving workout| Name: " + obj.Name);
            System.Console.WriteLine("Saving workout| Description: " + obj.Description);

            datastore.addWorkout(datastore.getWorkoutPrograms().First(), obj);
        }
    }
}

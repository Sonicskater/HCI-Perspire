using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.ViewModels.Workouts
{
    class WorkoutEditViewModel : BaseViewModel
    {

        public string WorkoutName
        {
            get; set;
        }

        public string WorkoutDescription { get; set; }



        public void Save()
        {
            var obj = new WorkoutModel
            {
                Name = WorkoutName,
                Description = WorkoutDescription
            };

            System.Console.WriteLine("Saving workout| Name: " + obj.Name);
            System.Console.WriteLine("Saving workout| Description: " + obj.Description);
        }
    }
}

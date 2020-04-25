using OxyPlot;
using Perspire.DataStore;
using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    
    class ProgramEditViewModel : BaseViewModel
    {
        private ProgramModel model;
        public String Name
        {
            set
            {
                var data = DependencyService.Resolve<DataRepository>();
                if (value == "")
                {
                    model = new ProgramModel();
                }
                else{
                    model = data.getProgram(value);
                }
                model.PropertyChanged += ((a, b) =>
                {
                    Update();
                });
                Update();
            }
        }

        private void Update()
        {
            ProgramName = model.Name;
            Description = model.Description;
            ImgSrc = model.ImageSrc;
            OnPropertyChanged("ProgramName");
            OnPropertyChanged("Description");
            OnPropertyChanged("ImgSrc");
        }

        internal void AddWorkout(WorkoutModel result)
        {
            workouts.Add(new ProgramWorkoutVM(result));
        }
        public ObservableCollection<ProgramWorkoutVM> workouts { get; set; } = new ObservableCollection<ProgramWorkoutVM>();

        public bool Creation { get; set; }
        public bool NotCreation { get { return !Creation; } }
        public String ProgramName { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }
        public String ImgSrc { get; set; }
    }

    public class ProgramWorkoutVM
    {
        public ProgramWorkoutVM(WorkoutModel model)
        {
            WorkoutName = model.Name;   
        }
        public string WorkoutName { get; set; }

        public WorkoutModel result()
        {
            return new WorkoutModel
            {
                Name = WorkoutName
            };
        }
    }
}

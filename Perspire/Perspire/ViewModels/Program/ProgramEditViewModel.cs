using OxyPlot;
using Perspire.DataStore;
using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    
    class ProgramEditViewModel : BaseViewModel
    {

        DataRepository data = DependencyService.Resolve<DataRepository>();

        private ProgramModel model;
        public String Name
        {
            set
            {
                
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
            workouts.Clear();
            foreach (var i in model.workouts)
            {
                workouts.Add(new ProgramWorkoutVM(i));
            }
            OnPropertyChanged("ProgramName");
            OnPropertyChanged("Description");
            OnPropertyChanged("ImgSrc");
        }

        internal void removeWorkout(ProgramWorkoutVM obj)
        {
            workouts.Remove(obj);
        }

        internal void Save()
        {
            var obj = new ProgramModel
            {
                Name = ProgramName,
                Description = Description
            };
            foreach (var i in workouts)
            {
                obj.workouts.Add(i.result());
            }
            if (Creation)
            {
                
            }
            else
            {
                data.addProgram(obj);
            }
            
        }

        internal void AddWorkout(WorkoutModel result)
        {
            workouts.Add(new ProgramWorkoutVM(new ProgramWorkout { 
                workout  = result
            }));
        }
        public ObservableCollection<ProgramWorkoutVM> workouts { get; set; } = new ObservableCollection<ProgramWorkoutVM>();

        public bool Creation { get; set; }
        public bool NotCreation { get { return !Creation; } }
        public String ProgramName { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }
        public String ImgSrc { get; set; }


    }

    public class ProgramWorkoutVM : BaseViewModel
    {
        private WorkoutModel model;
        private ProgramWorkout pw;
        public ProgramWorkoutVM(ProgramWorkout _pw)
        {
            pw = _pw;

            pw.PropertyChanged += ((a, b) =>
            {
                Update();
            });

            Update();
        }

        public void Update()
        {
            model = pw.workout;
            WorkoutName = pw.workout.Name;

            reps = pw.reps.ToString();
            weeks = pw.weeks.ToString();
            if (reps == "0")
            {
                reps = "";
            }

            if (weeks == "0")
            {
                weeks = "";
            }
            monday = pw.monday;
            tuesday = pw.tuesday;
            wendsday = pw.wendsday;
            thursday = pw.thursday;
            friday = pw.friday;
            saturday = pw.saturday;
            sunday = pw.sunday;

            OnPropertyChanged("");
        }
        public string WorkoutName { get; set; }

        public string reps { get; set; }
        public string weeks { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wendsday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }

        public ProgramWorkout result()
        {
            
            return new ProgramWorkout
            {
                workout = model,
                monday = monday,
                tuesday = tuesday,
                wendsday = wendsday,
                thursday = thursday,
                friday = friday,
                saturday = saturday,
                sunday = sunday,
                weeks = parseIntOrDefault(weeks),
                reps = parseIntOrDefault(reps)
            };
        }

        public int parseIntOrDefault(String s)
        {
            int x;
            Int32.TryParse(s, out x);
            return x;
        }
    }
}

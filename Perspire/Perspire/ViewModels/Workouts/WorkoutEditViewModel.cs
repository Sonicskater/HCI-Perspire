using Perspire.DataStore;
using Perspire.Models;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels.Workouts
{
    class WorkoutEditViewModel : BaseViewModel
    {
        
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public string WorkoutCategory { get; set; }
        public bool UsesWeights { get; set; }
        public string WorkoutUnits { get; set; }
        public string ImgSrc { get; set; }
        public string SelectedCategory { get; set; }

        public bool Creation { get; set; } = true;

        public bool NotCreation { get
            {
                return !Creation;
            } }

        public ObservableCollection<String> Categories { 
            get
            {
                var data = new ObservableCollection<String>();
                foreach ( var i in datastore.getWorkoutGroups())
                {
                    data.Add(i.Name);
                }
                return data;
            } 
        }

        internal void LoadExisting(WorkoutModel model)
        {
            Creation = false;
            WorkoutName = model.Name;
            WorkoutDescription = model.Description;
            WorkoutTime = model.EstTime.ToString();
            ImgSrc = model.ImageSrc;
            UsesWeights = model.weights;
            WorkoutUnits = model.Units;
            OnPropertyChanged("WorkoutTime");
            OnPropertyChanged("WorkoutUnits");
            OnPropertyChanged("UsesWeights");
            OnPropertyChanged("WorkoutName");
            OnPropertyChanged("ImgSrc");
            OnPropertyChanged("Creation");
            OnPropertyChanged("NotCreation");
            OnPropertyChanged("WorkoutDescription");
        }

        public string WorkoutTime { get; set; }
        public string MName { set
            {
                LoadExisting(datastore.getWorkout(value));
            }
        }

        DataRepository datastore = DependencyService.Resolve<DataRepository>();

        public bool Save()
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            if (WorkoutName == "" && Creation)
            {

                var options = new NotificationOptions()
                {
                    Title = "Input Error",
                    Description = "You must give the workout a name"
                };

                notificator.Notify(options);
                return false;
            }

            if (SelectedCategory == null && Creation)
            {
                var options = new NotificationOptions()
                {
                    Title = "Input Error",
                    Description = "You must pick a workout category"
                };

                notificator.Notify(options);
                return false;
            }
            try
            {
                var EstTime = Int32.Parse(WorkoutTime);

                var obj = new WorkoutModel
                {
                    Name = WorkoutName,
                    Description = WorkoutDescription,
                    EstTime = EstTime,
                    ImageSrc = ImgSrc,
                    weights = UsesWeights,
                    Units = WorkoutUnits
                };

                System.Console.WriteLine("Saving workout| Name: " + obj.Name);
                System.Console.WriteLine("Saving workout| Description: " + obj.Description);

                if (Creation)
                {
                    datastore.addWorkout(datastore.getWorkoutGroup(SelectedCategory), obj);
                }
                else
                {
                    datastore.addWorkout(obj);
                }

                return true;
            }
            catch (Exception e)
            {
                

                var options = new NotificationOptions()
                {
                    Title = "Input Error",
                    Description = "Estimated Time must be a whole number"
                };

                notificator.Notify(options);

                return false;
            }
        }
    }
}

using Perspire.DataStore;
using Perspire.Models;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels.Workouts
{
    class WorkoutDetailViewModel : BaseViewModel
    {
        private WorkoutModel _model;
        WorkoutModel model
        {
            set
            {
                _model = value;
                _model.PropertyChanged +=( (a,b) => { 
                    Update();
                });
                Update();
            }
        }

        private void Update()
        {
            Name = _model.Name;
            Desc = _model.Description;
            ImgSrc = _model.ImageSrc;
            Weights = _model.weights;
            Time = _model.EstTime.ToString();
            Date = DateTime.Now;
            WorkoutUnits = _model.Units;
            OnPropertyChanged("Date");
            OnPropertyChanged("WorkoutUnits");
            OnPropertyChanged("Name");
            OnPropertyChanged("Time");
            OnPropertyChanged("Weights");
            OnPropertyChanged("Desc");
            OnPropertyChanged("ImgSrc");
        }

        public String MName
        {
            set
            {
                model = datastore.getWorkout(value);
            }
            get
            {
                return _model.Name;
            }
        }

        internal void saveActivity()
        {
            try
            {
                if (Weights)
                {
                    datastore.addActivity(new Activity
                    {
                        date = new DateTimeOffset(Date),
                        workout = _model,
                        reps = Int32.Parse(Reps),
                        weight = Int32.Parse(Weight)
                    });
                }
                else
                {
                    datastore.addActivity(new Activity
                    {
                        date = new DateTimeOffset(Date),
                        workout = _model,
                        reps = Int32.Parse(Reps)
                    });
                }


                var notificator = DependencyService.Get<IToastNotificator>();
                var options = new NotificationOptions()
                {
                    Title = "Recorded",
                    Description = "Your activity has been recorded, and can be seen on the Dsahboard"
                };

                notificator.Notify(options);
            }
            catch (Exception e)
            {
                var notificator = DependencyService.Get<IToastNotificator>();
                var options = new NotificationOptions()
                {
                    Title = "Input Error",
                    Description = "Reps and weights must be whole nubmers"
                };

                notificator.Notify(options);
            }
        }

        public String Name { get; set; }
        public String Desc { get; set; }
        public String Weight { get; set; }
        public String ImgSrc { get; set; }
        public String WorkoutUnits { get; set; }
        public String Time { get; set; }
        public String Reps { get; set; }
        
        public DateTime Date { get; set; }
        public bool Weights { get; set; }

        DataRepository datastore = DependencyService.Resolve<DataRepository>();
    }
}

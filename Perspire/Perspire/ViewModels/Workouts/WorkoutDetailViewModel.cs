using Perspire.DataStore;
using Perspire.Models;
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
            WorkoutUnits = _model.Units;
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

        public String Name { get; set; }
        public String Desc { get; set; }
        public String ImgSrc { get; set; }
        public String WorkoutUnits { get; set; }
        public String Time {get; set;}
        public bool Weights { get; set; }

        DataRepository datastore = DependencyService.Resolve<DataRepository>();
    }
}

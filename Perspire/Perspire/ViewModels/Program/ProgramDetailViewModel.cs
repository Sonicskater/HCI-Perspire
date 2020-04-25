using Perspire.DataStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Perspire.ViewModels
{
    class ProgramDetailViewModel : BaseViewModel
    {

        public String ProgramName { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }

        public String ImgSrc { get; set; }
        public ObservableCollection<ProgramWorkout> workouts { get; set; } = new ObservableCollection<ProgramWorkout>();

        private ProgramModel model;
        public void LoadProgram(ProgramModel _model)
        {

            model = _model;
            model.PropertyChanged += ((a, b) =>
            {
                Update();
            });
            Update();
        }

        public void Update()
        {
            ProgramName = model.Name;
            Description = model.Description;

            workouts.Clear();
            foreach (var i in model.workouts)
            {
                workouts.Add(i);
            }
            OnPropertyChanged("");
        }

        
    }
}

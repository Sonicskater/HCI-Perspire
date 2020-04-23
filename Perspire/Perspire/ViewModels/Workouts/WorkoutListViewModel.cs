using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Perspire.DataStore;
using Perspire.Models;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel : BaseViewModel
    {

        public ObservableCollection<WorkoutGroupViewModel> WorkoutList { get; set; } = new ObservableCollection<WorkoutGroupViewModel>();

        private String _searchString = "";
        public String SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                
                foreach (var i in WorkoutList)
                {
                    i.filter = value;
                }
                
            }
        }
        DataRepository datastore = DependencyService.Resolve<DataRepository>();
        
        

        public WorkoutListViewModel()
        {
            var datalist = datastore.getWorkoutPrograms();


            foreach (var i in datalist)
            {
                WorkoutList.Add(new WorkoutGroupViewModel(i));
            }

        }



        public void ToggleVis(int index)
        {
            WorkoutList[index].Expanded = !WorkoutList[index].Expanded;
        }
    }


    public class WorkoutGroupViewModel : ObservableCollection<WorkoutModel>, IEquatable<WorkoutGroupViewModel>
    {
        private WorkoutGroupModel workouts;
        private bool _expanded = false;

        public WorkoutGroupViewModel(WorkoutGroupModel workouts) : base()
        {
            this.workouts = workouts;
            Expanded = true;

            workouts.PropertyChanged += (sender, e) => {
                Update();
            };
        }
        private String _filter ="";
        public String filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                Update();      
            }
        }
        public void Update()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
            OnPropertyChanged(new PropertyChangedEventArgs("Glyph"));
            Clear();
            if (_expanded)
            {
                foreach (var i in workouts)
                {
                    if (i.Name.ToLower().StartsWith(_filter.ToLower()))
                    {
                        Add(i);
                    }

                }
            }
        }
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    Update();
                }
            }
        }
        private string collapsed = IconFont.ChevronUp;
        private string expanded = IconFont.ChevronDown;
        public string Glyph
        {
            get
            {
                if (Expanded)
                {
                    return expanded;
                }
                else
                {
                    return collapsed;
                }
            }
        }

        public string Name
        {
            get
            {
                return workouts.Name;
            }
        }

        bool IEquatable<WorkoutGroupViewModel>.Equals(WorkoutGroupViewModel other)
        {
            return this.Name == other.Name;
        }

        public void Toggle()
        {
            this.Expanded = !this.Expanded;
        }
    }

}

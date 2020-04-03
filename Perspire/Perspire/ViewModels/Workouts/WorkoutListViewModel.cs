using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Perspire.Models;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel : BaseViewModel
    {
        public ObservableCollection<WorkoutGroupViewModel> WorkoutList { get; set; } = new ObservableCollection<WorkoutGroupViewModel>();
        public WorkoutListViewModel()
        {
            var group = new WorkoutGroupModel("Back");
            
            group.Add(new WorkoutModel
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new WorkoutModel
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new WorkoutGroupViewModel(group));

            group = new WorkoutGroupModel("Shoulder");
            group.Add(new WorkoutModel
            {
                Name = "Workout 3",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new WorkoutModel
            {
                Name = "Workout 4",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new WorkoutGroupViewModel(group));
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
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("Glyph"));
                    if (_expanded)
                    {
                        foreach (var i in workouts)
                        {
                            Add(i);
                        }
                    }
                    else
                    {
                        Clear();
                    }

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
    }

}

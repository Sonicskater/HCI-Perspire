using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Perspire.Models;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel : BaseViewModel
    {
        public ObservableCollection<GroupedWorkoutModel> WorkoutList { get; set; } = new ObservableCollection<GroupedWorkoutModel>();
        public WorkoutListViewModel()
        {
            var group = new WorkoutGroup("Back");
            
            group.Add(new Workout
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new Workout
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new GroupedWorkoutModel(group));

            group = new WorkoutGroup("Shoulder");
            group.Add(new Workout
            {
                Name = "Workout 3",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new Workout
            {
                Name = "Workout 4",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new GroupedWorkoutModel(group));
        }

        public void ToggleVis(int index)
        {
            WorkoutList[index].Expanded = !WorkoutList[index].Expanded;
        }
    }

    public class GroupedWorkoutModel : ObservableCollection<Workout>, IEquatable<GroupedWorkoutModel>
    {
        private WorkoutGroup workouts;
        private bool _expanded = false;

        public GroupedWorkoutModel(WorkoutGroup workouts) : base()
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

        bool IEquatable<GroupedWorkoutModel>.Equals(GroupedWorkoutModel other)
        {
            return this.Name == other.Name;
        }
    }

}

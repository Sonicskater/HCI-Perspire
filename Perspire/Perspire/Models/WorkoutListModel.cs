using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Perspire.Models
{
    public class WorkoutListModel
    {
        public string Name { get; set; }
        public string Part { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }

    public class GroupedWorkoutModel : ObservableCollection<WorkoutListModel> , INotifyPropertyChanged, IEquatable<GroupedWorkoutModel>
    {
        private ObservableCollection<WorkoutListModel> workouts = new ObservableCollection<WorkoutListModel>();
        private bool _expanded = false;

        public GroupedWorkoutModel(List<WorkoutListModel> list, String name) : base()
        {
            foreach( var i in list)
            {
                workouts.Add(i);
            }
            Name = name;
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
        private string collapsed = IconFont.ChevronDown;
        private string expanded = IconFont.ChevronUp;
        public string Glyph { get
            {
                if (Expanded)
                {
                    return expanded;
                }
                else
                {
                    return collapsed;
                }
            } }

        public string Name { get; set; }

        bool IEquatable<GroupedWorkoutModel>.Equals(GroupedWorkoutModel other)
        {
            return this.Name == other.Name;
        }
    }
}

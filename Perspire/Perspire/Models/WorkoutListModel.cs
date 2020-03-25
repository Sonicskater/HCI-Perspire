using System;
using System.Collections.ObjectModel;

namespace Perspire.Models
{
    public class WorkoutListModel
    {
        public string Name { get; set; }
        public string Part { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }

    public class GroupedWorkoutModel : ObservableCollection<WorkoutListModel>
    {
        public string Name { get; set; }
    }
}

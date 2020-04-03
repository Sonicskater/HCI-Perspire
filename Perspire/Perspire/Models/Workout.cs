using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Perspire.Models
{
    public class Workout
    {
        public string Name { get; set; }
        public string Part { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }

    public class WorkoutGroup : List<Workout>
    {
        public WorkoutGroup(String name) : base()
        {
            Name = name;
        }
        public string Name { get; set; }

    }
    
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Perspire.Models
{
    /// <summary>
    /// Work out data model
    /// </summary>
    public class WorkoutModel
    {
        public string Name { get; set; }
        public string Part { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }
    /// <summary>
    /// Workotu Group data model
    /// </summary>
    public class WorkoutGroupModel : List<WorkoutModel>
    {
        public WorkoutGroupModel(String name) : base()
        {
            Name = name;
        }
        public string Name { get; set; }

    }
    
}

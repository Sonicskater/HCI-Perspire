using Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Perspire.Models
{
    /// <summary>
    /// Work out data model
    /// </summary>
    public class WorkoutModel : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }

        public string Part { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }
    /// <summary>
    /// Workotu Group data model
    /// </summary>
    public class WorkoutGroupModel : RealmObject, ICollection<WorkoutModel>
    {
        public WorkoutGroupModel() : base()
        {

        }
        public WorkoutGroupModel(String name) : base()
        {
            Name = name;
        }

        [PrimaryKey]
        public string Name { get; set; }

        public IList<WorkoutModel> Workouts { get; }

        public int Count => Workouts.Count;

        public bool IsReadOnly => Workouts.IsReadOnly;

        public void Add(WorkoutModel item)
        {
            Workouts.Add(item);
        }

        public void Clear()
        {
            Workouts.Clear();
        }

        public bool Contains(WorkoutModel item)
        {
            return Workouts.Contains(item);
        }

        public void CopyTo(WorkoutModel[] array, int arrayIndex)
        {
            Workouts.CopyTo(array, arrayIndex);
        }

        public IEnumerator<WorkoutModel> GetEnumerator()
        {
            return Workouts.GetEnumerator();
        }

        public bool Remove(WorkoutModel item)
        {
            return Workouts.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Workouts.GetEnumerator();
        }
    }
    
}

using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.DataStore
{
    public class ProgramModel : RealmObject
    {
        public IList<ProgramWorkout> workouts { get; }

        [PrimaryKey]
        public String Name { get; set; }

        public string ImageSrc { get; set; }
        public string Description { get; set; }


    }

    public class ProgramWorkout : RealmObject
    {
        public String WoName { get { return workout.Name; } }

        public int reps { get; set; }
        public int weeks { get; set; }
        public WorkoutModel workout { get; set; }

        public bool monday {get; set;}
        public bool tuesday {get; set;}
        public bool wendsday {get; set;}
        public bool thursday {get; set;}
        public bool friday {get; set;}
        public bool saturday {get; set;}
        public bool sunday {get; set;}
    }

    public class ProgramGroupModel: RealmObject
    {
        public IList<ProgramModel> programs { get; }

        [PrimaryKey]
        public String Name { get; set; }
    }
}

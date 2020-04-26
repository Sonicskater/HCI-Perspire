using Perspire.DataStore;
using Perspire.Views;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.Models
{
    class UserData : RealmObject
    {
        [PrimaryKey]
        public int make_sure_only_1_lol {get; set;}

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public ProgramModel currentProgram { get; set; }

        public IList<Activity> activities { get; }
    }

    public class Activity : RealmObject
    {
        public WorkoutModel workout { get; set; }
        public int reps { get; set; }
        public DateTimeOffset date { get; set; }
    }

    class WorkoutLog : RealmObject
    {
        public WorkoutModel Workout { get; set; }

        public DateTimeOffset Date { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}

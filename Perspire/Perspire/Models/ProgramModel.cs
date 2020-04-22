using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.DataStore
{
    class ProgramModel : RealmObject
    {
        public IList<WorkoutModel> workouts { get; }

        [PrimaryKey]
        public String name { get; set; }
    }
}

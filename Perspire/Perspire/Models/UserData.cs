﻿using Perspire.DataStore;
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
        public String Name { get; set; }
        public ProgramModel currentProgram { get; set; }
    }

    class WorkoutLog : RealmObject
    {
        public WorkoutModel Workout { get; set; }

        public DateTimeOffset Date { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
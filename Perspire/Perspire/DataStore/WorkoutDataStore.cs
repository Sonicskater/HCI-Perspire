using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.DataStore
{
    class WorkoutDataStore : List<WorkoutGroupModel>
    {
        private WorkoutDataStore() : base()
        {
            var group = new WorkoutGroupModel("Back");

            group.Add(new WorkoutModel
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new WorkoutModel
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            Add(group);

            group = new WorkoutGroupModel("Shoulder");
            group.Add(new WorkoutModel
            {
                Name = "Workout 3",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            group.Add(new WorkoutModel
            {
                Name = "Workout 4",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            Add(group);
        }

        // singleton data pattern; not great, but works for now
        private static WorkoutDataStore me = null;
        public static WorkoutDataStore Get()
        {
            if (me == null)
            {
                me = new WorkoutDataStore();
            }
            return me;
        }
    }
}

using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.DataStore
{
    class WorkoutRepository : List<WorkoutGroupModel>
    {
        public WorkoutRepository() : base()
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
    }
}

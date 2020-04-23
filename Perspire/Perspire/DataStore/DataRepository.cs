using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perspire.DataStore
{
    class DataRepository
    {

        private Realm realm = Realm.GetInstance();

        public DataRepository()
        {
            // populate db if db is empty
            if (!realm.All<WorkoutGroupModel>().Any())
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
                addWorkoutGroup(group);

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
                addWorkoutGroup(group);
            }
        }

        public void addWorkout(WorkoutGroupModel group, WorkoutModel workout)
        {
            
            realm.Write(() =>
            {
                group.Add(workout);
                realm.Add(group, true);
                realm.Add(workout, true);
            });
        }

        public void addWorkoutGroup(WorkoutGroupModel group)
        {
            realm.Write(() =>
            {
                realm.Add(group);
            });
        }

        public void addProgram(ProgramModel program)
        {
            realm.Write(() =>
            {
                realm.Add(program);
            });
        }

        internal IEnumerable<WorkoutGroupModel> getWorkoutPrograms()
        {
            return realm.All<WorkoutGroupModel>();
        }
    }
}

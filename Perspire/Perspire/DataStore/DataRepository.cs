﻿using Perspire.Models;
using Realms;
using Realms.Sync;
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
                var group = new WorkoutGroupModel("Back");

                group.Add(new WorkoutModel
                {
                    Name = "Workout 1",
                    ImageSrc = "download.jpg",
                    Description = "back workout"
                });

                group.Add(new WorkoutModel
                {
                    Name = "Workout 2",
                    ImageSrc = "tab_about.png",
                    Description = "back workout"
                });
                addWorkoutGroup(group);

                group = new WorkoutGroupModel("Shoulder");
                group.Add(new WorkoutModel
                {
                    Name = "Workout 3",
                    ImageSrc = "tab_about.png",
                    Description = "back workout"
                });

                group.Add(new WorkoutModel
                {
                    Name = "Workout 4",
                    ImageSrc = "tab_about.png",
                    Description = "back workout"
                });
                addWorkoutGroup(group);

            var programGroup = new ProgramGroupModel
            {
                programs =
                {
                    new ProgramModel
                    {
                        Name = "Test prog 1"
                    },
                    new ProgramModel
                    {
                        Name = "Test prog 2"
                    }

                },
                Name = "Cardio",
               

            };

            addProgramGroup(programGroup);

            programGroup = new ProgramGroupModel
            {
                programs =
                {
                    new ProgramModel
                    {
                        Name = "Test prog 3"
                    },
                    new ProgramModel
                    {
                        Name = "Test prog 4"
                    }
                },
                Name = "Strength",


            };

            addProgramGroup(programGroup);

            var UserData = new UserData
            {
                make_sure_only_1_lol = 1,  
                FirstName = "Bob",
                currentProgram = new ProgramModel
                {
                    Name = "Hello there",
                    Description = "General Kenobi",
                    workouts = {
                        new ProgramWorkout
                        {
                            workout = new WorkoutModel
                        {
                            Name = "Workout 4",
                            ImageSrc = "tab_about.png",
                            Description = "back workout"
                        },
                            saturday = true,
                            weeks = 5
                            
                        }
                        
                    }
                }
            };

            WriteUserData(UserData);

            addStat(new StatModel
            {
                units = "lbs.",
                name = "Weight"
            });

            addStat(new StatModel
            {
                units = "s",
                name = "Sprint Time"
            });

        }

        public void Listen(Realms.Realm.RealmChangedEventHandler func)
        {
            realm.RealmChanged += func;
        }


        internal void setCurrent(ProgramModel model)
        {
            var u = GetUserData();

            realm.Write(() =>
            {
                u.currentProgram = model;
                
            });
        }

        internal ProgramModel getProgram(string value)
        {
            return realm.Find<ProgramModel>(value);
        }

        internal void recordEntry(StatModel stat, StatsEntry statsEntry)
        {
            realm.Write(() =>
            {
                stat.entries.Add(statsEntry);
            });
        }

        internal void addWorkout(WorkoutModel obj)
        {
            realm.Write(() =>
            {
                realm.Add(obj, true);
            });
        }

        internal WorkoutGroupModel getWorkoutGroup(string selectedCategory)
        {
            return realm.Find<WorkoutGroupModel>(selectedCategory);
        }

        internal WorkoutModel getWorkout(string value)
        {
            var y = 1;
            var x = realm.Find<WorkoutModel>(value);
            return x;
        }

        private void addProgramGroup(ProgramGroupModel programGroup)
        {
            realm.Write(() =>
            {
                realm.Add(programGroup, true);
            });
        }

        public void addWorkout(WorkoutGroupModel group, WorkoutModel workout)
        {
            var value = realm.Find<WorkoutModel>(workout.Name);
            if (value == null)
            {
                realm.Write(() =>
                {
                    group.Add(workout);
                    realm.Add(workout, true);
                });
            }
            else
            {
                realm.Write(() =>
                {
                    value.Description = workout.Description;
                    value.ImageSrc = workout.ImageSrc;
                });
            }

        }

        internal void logProgramActivity(ProgramWorkout programWorkout)
        {
            // Xamarin is broke, so this doesnt work
            /*
            addActivity(new Activity
            {
                workout = programWorkout.workout,
                date = new DateTimeOffset(DateTime.Now),
                reps = programWorkout.reps
            });
            */
            

            realm.Write(() =>
            {
                programWorkout.progress = programWorkout.progress + 1;
                programWorkout.b = true;
            });
            
        }

        public void addWorkoutGroup(WorkoutGroupModel group)
        {
            realm.Write(() =>
            {
                realm.Add(group, true);
            });
        }

        public void addProgram(ProgramModel program)
        {
            realm.Write(() =>
            {
                realm.Add(program, true);
            });
        }

        public void addStat(StatModel stat)
        {
            realm.Write(() =>
            {
                realm.Add(stat, true);
            });
        }

        internal IEnumerable<WorkoutGroupModel> getWorkoutGroups()
        {
            return realm.All<WorkoutGroupModel>();
        }

        internal IEnumerable<ProgramGroupModel> getProgramGroups()
        {
            return realm.All <ProgramGroupModel>();
        }

        public IQueryable<StatModel> getStats()
        {
            return realm.All<StatModel>();
        }

        public IQueryable<Activity> getActivites()
        {
            return realm.All<Activity>();
        }

        public void addActivity(Activity act)
        {
            realm.Write(() =>
            {
                realm.Add(act, true);
            });
        }

        public UserData GetUserData()
        {
            return realm.All<UserData>().FirstOrDefault();
            
        }


        public void WriteUserData(UserData data)
        {
            realm.Write(() =>
            {
                realm.Add(data, true);

            });
        }
    }
}

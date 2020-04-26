using Perspire.DataStore;
using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    class DashBoardViewModel : BaseViewModel
    {
        private UserData user;

        public String username { get; set; }

        public String ProgramName { get; set; }

        private DataRepository data = DependencyService.Resolve<DataRepository>();
        public StatsViewModel StatsContext { get; set; }

        public ObservableCollection<ActivityGroup> ActivityGroups { get; set; } = new ObservableCollection<ActivityGroup>();
        public ObservableCollection<Goal> Goals { get; set; } = new ObservableCollection<Goal>();
        public ObservableCollection<ToDo> Today { get; set; } = new ObservableCollection<ToDo>();

        private IQueryable<Activity> activities;
        public DashBoardViewModel()
        {
            StatsContext = DependencyService.Resolve<StatsViewModel>();
            OnPropertyChanged();

            user = data.GetUserData();

            data.Listen((a, b) =>
            {
                Update();
            });

            

            
            activities = data.getActivites();

            activities.AsRealmCollection().PropertyChanged += (a,b) =>
            {
                Update();
            };

            StatsContext.PropertyChanged += ((a, b) => { OnPropertyChanged(); });

            Update();
        }

        private int max_act_group = 5;

        private void Update()
        {
            username = $"Welcome, {user.FirstName}!";

            Goals.Clear();
            Today.Clear();
            foreach (var goal in user.currentProgram.workouts)
            {

                var w = 10;
                if (goal.max > 0)
                {
                    w = goal.max;
                }

                goal.PropertyChanged += (y, b) =>
                {
                    Update();
                };

                Goals.Add(new Goal { 
                    
                    Progress = (float)goal.progress / (float)w,
                    Title = goal.workout.Name
                });

                var todo = false;

                switch (DateTime.Today.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        todo = goal.friday;
                        break;
                    case DayOfWeek.Monday:
                        todo = goal.monday;
                        break;
                    case DayOfWeek.Saturday:
                        todo = goal.saturday;
                        break;
                    case DayOfWeek.Sunday:
                        todo = goal.sunday;
                        break;
                    case DayOfWeek.Thursday:
                        todo = goal.thursday;
                        break;
                    case DayOfWeek.Tuesday:
                        todo = goal.tuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        todo = goal.wendsday;
                        break;
                };

                if (todo)
                {
                    Today.Add(new ToDo(goal));
                }

            }

            user.currentProgram.PropertyChanged += (a, b) =>
            {
                Update();
            };
            ProgramName = user.currentProgram.Name;
            
            ActivityGroups.Clear();

            var groups = activities.ToList()
                .GroupBy( e => e.date.Date )
                .OrderByDescending( g => g.Key );
            int i = 0;
            ActivityGroups.Clear();
            foreach (var g in groups)
            {
                
                if (i >= max_act_group)
                {
                    break;
                }
                var x = new ActivityGroup(g.Key);

                foreach(var a in g)
                {

                    x.activities.Add(a);
                }
                ActivityGroups.Add(x);
                i++;
            }
            OnPropertyChanged("username");
            OnPropertyChanged("ProgramName");
            OnPropertyChanged("Goals");
        }
    }

    class Goal : BaseViewModel
    {
        public String Title { get; set; } = "Test";
        public float Progress { get; set; } = 0.7f;
    }
    class ToDo: BaseViewModel
    {
        private ProgramWorkout programWorkout;
        public ToDo(ProgramWorkout pw)
        {
            programWorkout = pw;
            name = pw.workout.Name;
            b = pw.b;
        }
        public String name { get; set; }

        private bool b;
        public bool Checked { 
            get{
                return b;
            }
            set
            {
                if (!b)
                {
                    b = value;


                    DependencyService.Resolve<DataRepository>().logProgramActivity(programWorkout);
                }
                
            }
        }
        public bool NotChecked { get
            {
                return !Checked;
            } }
    }

    class ActivityGroup : BaseViewModel
    {
        public ObservableCollection<Activity> activities { get; set; } = new ObservableCollection<Activity>();

        public ActivityGroup(DateTime date)
        {
            _date = date;
            OnPropertyChanged();
        }

        private DateTime _date;

        public string date
        {
            get
            {
                if (_date == DateTime.Now.Date)
                {
                    return "Today";
                }
                else if (_date == DateTime.Now.AddDays(-1).Date)
                {
                    return "Yesterday";
                }
                else
                {
                    return _date.ToString("dddd, dd MMMM");
                }
            }
        }
    }
}

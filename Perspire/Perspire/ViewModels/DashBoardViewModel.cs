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
        private DataRepository data = DependencyService.Resolve<DataRepository>();
        public StatsViewModel StatsContext { get; set; }

        public ObservableCollection<ActivityGroup> ActivityGroups { get; set; } = new ObservableCollection<ActivityGroup>();

        private IQueryable<Activity> activities;
        public DashBoardViewModel()
        {
            StatsContext = DependencyService.Resolve<StatsViewModel>();
            OnPropertyChanged();

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
            OnPropertyChanged();
        }
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

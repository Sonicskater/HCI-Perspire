using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using Perspire.DataStore;
using Perspire.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Perspire.ViewModels
{
    class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<StatViewModel> StatList { get; set; } = new ObservableCollection<StatViewModel>();

        private IQueryable<StatModel> data; 
        public StatsViewModel()
        {
            var vm = Xamarin.Forms.DependencyService.Resolve<Perspire.DataStore.DataRepository>();
            data = vm.getStats();
            var p = data.AsRealmCollection();
            p.PropertyChanged += (a, b) =>
            {
                Update();
            };
            Update();
        }

        public void Update()
        {
            StatList.Clear();
            foreach (var i in data)
            {
                StatList.Add(new StatViewModel(i));
            }

        }

    }

    class StatViewModel : BaseViewModel
    {
        public StatViewModel()
        {
            PieModel = CreatePieChart();
        }

        public StatModel stat;


        DataRepository data = Xamarin.Forms.DependencyService.Resolve<Perspire.DataStore.DataRepository>();

        public StatViewModel(StatModel i)
        {

            stat = i;
            stat.PropertyChanged += ((a, b) =>
            {
                Update();
            });
            Update();
        }

        public void Update()
        {
            
            Entries.Clear();
            foreach (var j in stat.entries)
            {
                Entries.Add(j);
            }
            PieModel = CreatePieChart();
            
            GoalLine = stat.goal;
            Name = stat.name;
            Units = stat.units;

            OnPropertyChanged("PieModel");
            OnPropertyChanged("GoalLine");
            OnPropertyChanged("Name");
            OnPropertyChanged("Units");
            OnPropertyChanged("Previous");
        }


        public ObservableCollection<StatsEntry> Entries { get; set; } = new ObservableCollection<StatsEntry>();

        public PlotModel PieModel { get; set; }

        public String GoalLine { get; set; }

        public String Name { get; set; }
        public String Previous
        {
            get {
            
                var x = Entries.LastOrDefault();
                if (x != null)
                {
                    return x.Value.ToString();
                }
                else{
                    return "None";
                }
                
            }
        }
        public String Units { get; set; }

        public String Entry { get; set; }

        private PlotModel CreatePieChart()
        {
            var model = new PlotModel { };

            model.Axes.Add(new DateTimeAxis
            {
                CalendarWeekRule = System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                FirstDayOfWeek = DayOfWeek.Monday,
                Position = AxisPosition.Bottom
            });
            var x = 0;
            Int32.TryParse(GoalLine, out x);

            if (x != 0)
            {

                var Line = new LineAnnotation()
                {
                    StrokeThickness = 1,
                    Color = OxyColors.Aqua,
                    Type = LineAnnotationType.Horizontal,
                    Text = "Goal",
                    TextColor = OxyColors.Black,
                    X = 0,
                    Y = x
                };

                model.Annotations.Add(Line);
            }

            model.Axes.Add(new LinearAxis());

            var ps = new LineSeries
            {
                ItemsSource = Entries
            };

            // http://www.nationsonline.org/oneworld/world_population.htm
            // http://en.wikipedia.org/wiki/Continent
            model.Series.Add(ps);
            return model;
        }

        internal void SaveNew()
        {
            data.recordEntry(stat,new StatsEntry { 
                Date = new DateTimeOffset(DateTime.Now),
                Value = float.Parse(Entry)
            });
        }
    }
}

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Perspire.ViewModels
{
    class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<StatViewModel> StatList { get; set; } = new ObservableCollection<StatViewModel>();

        public StatsViewModel()
        {
            StatList.Add(new StatViewModel
            {
                Entry = "Test",
                Previous = "143",
                Units = "lbs.",
                Name = "Weight"
            }); 
            
            StatList.Add(new StatViewModel
            {
                Entry = "Test1",
                Previous = "122",
                Units = "s",
                Name = "Sprint Time"
            });
        }
        
    }

    class StatViewModel
    {
        public StatViewModel()
        {
            PieModel = CreatePieChart();
        }
        public ObservableCollection<StatsEntry> Entries { get; set; }

        public PlotModel PieModel { get; set; }

        public String GoalLine { get; set; }

        public String Name { get; set; }
        public String Previous { get; set; }
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

            model.Axes.Add(new LinearAxis());

            var ps = new LineSeries
            {
                ItemsSource = new List<StatsEntry>
                {
                    new StatsEntry
                    {
                        Value = 100,
                        Date = new DateTimeOffset(2020,1,1,1,1,1,new TimeSpan())
                    },
                    new StatsEntry
                    {
                        Value = 110,
                        Date = new DateTimeOffset(2020,2,1,1,1,1,new TimeSpan())
                    },
                    new StatsEntry
                    {
                        Value = 90,
                        Date = new DateTimeOffset(2020,3,1,1,1,1,new TimeSpan())
                    }

                }
            };

            // http://www.nationsonline.org/oneworld/world_population.htm
            // http://en.wikipedia.org/wiki/Continent
            model.Series.Add(ps);
            return model;
        }
    }
}

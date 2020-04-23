
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Perspire.Models;
using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphedStat : ContentView
    {
        public GraphedStat()
        {
            this.InitializeComponent();
            PieModel = CreatePieChart();
            BindingContext = this;
        }

        public PlotModel PieModel { get; set; }

        private PlotModel CreatePieChart()
        {
            var model = new PlotModel {};

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


        public string Previous
        {
            get
            {
                return previous.Text;
            }
            set
            {
                previous.Text = value;
            }
        }
        public string Entry
        {
            get; set;
        }

        public string Units
        {
            get { return units1.Text; }
            set { units1.Text = value;
                units2.Text = value;
            }
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            System.Console.WriteLine(Entry);
        }
    }
}
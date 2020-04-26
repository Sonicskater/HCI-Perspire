using OxyPlot;
using OxyPlot.Axes;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.Models
{
    public class StatModel : RealmObject
    {
        [PrimaryKey]
        public String name { get; set; }
        public String units { get; set; }
        public String goal { get; set; }
        public IList<StatsEntry> entries { get; }
    }

    public class StatsEntry : RealmObject, IDataPointProvider
    {
        public float Value { get; set; }

        public DateTimeOffset Date { get; set; }

        public DataPoint GetDataPoint()
        {
            return new DataPoint(DateTimeAxis.ToDouble(Date.DateTime), Value);
        }
    }
}

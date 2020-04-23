using OxyPlot;
using OxyPlot.Axes;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perspire.Models
{
    class StatModel : RealmObject
    {
        public String name { get; set; }
        public String units { get; set; }
        public IList<StatsEntry> entries { get; }
    }

    class StatsEntry : RealmObject, IDataPointProvider
    {
        public int Value { get; set; }

        public DateTimeOffset Date { get; set; }

        public DataPoint GetDataPoint()
        {
            return new DataPoint(DateTimeAxis.ToDouble(Date.DateTime), Value);
        }
    }
}

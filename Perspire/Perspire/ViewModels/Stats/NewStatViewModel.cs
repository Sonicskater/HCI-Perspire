using Perspire.DataStore;
using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    class NewStatViewModel : BaseViewModel
    {
        public string StatTitle{ get; set; }
        public string StatUnits { get; set; }
        public string StatGoal { get; set; }
        public string TagLine { get; set; } = "New Stat";

        private IList<StatsEntry> ls;
        public bool Creation { get; set; } = true;

        public bool NotCreation { get { return !Creation; } }

        DataRepository datastore = DependencyService.Resolve<DataRepository>();

        public void Save()
        {

            var obj = new StatModel
            {
                name = StatTitle,
                units = StatUnits,
                goal = StatGoal

            };
            if (!Creation)
            {
                foreach (var e in ls)
                {
                    obj.entries.Add(e);
                }
            }

            System.Console.WriteLine("Saving stat| Name: " + obj.name);
            System.Console.WriteLine("Saving stat| Units: " + obj.units);
            System.Console.WriteLine("Saving stat| Goal: " + obj.goal);

            datastore.addStat(obj);
            OnPropertyChanged("TagLine");

        }

        internal void Load(StatModel s)
        {
            StatTitle = s.name;
            StatUnits = s.units;
            StatGoal = s.goal;

            Creation = false;

            ls = s.entries;

            TagLine = "Editing Stat";
            OnPropertyChanged("StatTitle");
            OnPropertyChanged("TagLine");
            OnPropertyChanged("StatGoal");
            OnPropertyChanged("StatUnits");
            OnPropertyChanged("Creation");
            OnPropertyChanged("NotCreation");
        }
    }
}

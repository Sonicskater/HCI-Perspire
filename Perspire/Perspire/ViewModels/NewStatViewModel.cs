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

        DataRepository datastore = DependencyService.Resolve<DataRepository>();

        public void Save()
        {

            var obj = new StatModel
            {
                name = StatTitle,
                units = StatUnits,
                goal = StatGoal
            };

            System.Console.WriteLine("Saving stat| Name: " + obj.name);
            System.Console.WriteLine("Saving stat| Units: " + obj.units);
            System.Console.WriteLine("Saving stat| Goal: " + obj.goal);

            datastore.addStat(obj);

        }
    }
}

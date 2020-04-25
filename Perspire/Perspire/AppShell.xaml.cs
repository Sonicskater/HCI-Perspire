using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Perspire
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            
            InitializeComponent();

            Routing.RegisterRoute("WorkoutDetail", typeof(Perspire.Views.WorkoutListDetail));
            Routing.RegisterRoute("WorkoutEdit", typeof(Perspire.Views.WorkoutEdit));
            Routing.RegisterRoute("ProgramEdit", typeof(Perspire.Views.NewProgram));
        }
    }
}

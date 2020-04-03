using Perspire.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views.Workouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutListGroup : ViewCell
    {
        public WorkoutListGroup()
        {
            InitializeComponent();
        }
        private void ToggleGroup(object sender, EventArgs e)
        {
            var bindingContext = ((WorkoutGroupViewModel)BindingContext);
            bindingContext.Toggle();
        }

    }
}
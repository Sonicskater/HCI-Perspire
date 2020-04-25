using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    class DashBoardViewModel : BaseViewModel
    {
        public StatsViewModel StatsContext { get; set; }

        public DashBoardViewModel()
        {
            StatsContext = DependencyService.Resolve<StatsViewModel>();
            OnPropertyChanged();

            StatsContext.PropertyChanged += ((a, b) => { OnPropertyChanged(); });
        }
    }
}

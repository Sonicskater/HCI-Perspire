
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Perspire.Models;
using Perspire.ViewModels;
using Perspire.Views;
using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphedStat : ViewCell
    {
        public GraphedStat()
        {
            this.InitializeComponent();
        }

       


        

        private void Entry_Completed(object sender, EventArgs e)
        {
            ((StatViewModel)BindingContext).SaveNew();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var s = ((StatViewModel)BindingContext).stat;
            Shell.Current.Navigation.PushModalAsync(new NewStat(s));
        }
    }
}
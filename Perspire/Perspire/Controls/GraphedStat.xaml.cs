
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
    public partial class GraphedStat : ViewCell
    {
        public GraphedStat()
        {
            this.InitializeComponent();
        }

       


        

        private void Entry_Completed(object sender, EventArgs e)
        {
            System.Console.WriteLine("Hi");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphedStat : ContentView
    {
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
        public GraphedStat()      
        {
  
            InitializeComponent();
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
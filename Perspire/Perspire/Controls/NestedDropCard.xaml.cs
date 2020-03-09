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
    public partial class NestedDropCard : ContentView
    {
        public NestedDropCard()
        {
            InitializeComponent();
        }
        public View Top
        {
            get { return TopContent.Content; }
            set { TopContent.Content = value; }
        }

        public View Bottom
        {
            get { return BottomContent.Content; }
            set { BottomContent.Content = value; }
        }



    }
}
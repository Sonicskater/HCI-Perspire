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
    public partial class SearchControl : ContentView
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProgramFilter());
        }
    }
}
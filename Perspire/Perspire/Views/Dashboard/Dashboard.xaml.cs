using Perspire.Controls;
using Perspire.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        DashBoardViewModel vm = DependencyService.Resolve<DashBoardViewModel>();
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            System.Console.Out.WriteLine("Clicked!");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushModalAsync(new Programs());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfileSetup());
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            var data = (StatViewModel)((Entry)sender).BindingContext;
            data.SaveNew();
        }
    }
}
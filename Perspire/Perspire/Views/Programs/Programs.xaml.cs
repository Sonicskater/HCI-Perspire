using Perspire.DataStore;
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
    public partial class Programs : ContentPage
    {
        public Programs()
        {
            var data = DependencyService.Resolve<ProgramListViewModel>();
            InitializeComponent();
            BindingContext = data;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"ProgramEdit?name={""}");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new ProgramDetail());
        }

        private async void OpenFilter(Object sender, EventArgs e)
        {

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ProgramDetail((ProgramModel)e.Item));
        }
    }
}
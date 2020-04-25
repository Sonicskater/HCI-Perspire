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
    [QueryProperty("Name", "name")]
    public partial class NewProgram : ContentPage
    {
        ProgramEditViewModel vm = DependencyService.Resolve<ProgramEditViewModel>();

        public string Name
        {
            set
            {
                vm.Name = Uri.UnescapeDataString(value);
            }
        }
        public NewProgram()
        {
            InitializeComponent();
            BindingContext = vm;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var x = new WorkoutPicker();
            await Navigation.PushModalAsync(x);
            var result = await x.data.PickWorkout();
            await Navigation.PopModalAsync();

            vm.AddWorkout(result);
        }
    }
}
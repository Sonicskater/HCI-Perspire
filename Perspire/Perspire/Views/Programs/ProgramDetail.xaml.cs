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
    [QueryProperty("Name","name")]
    public partial class ProgramDetail : ContentPage
    {
        private string _Name;
        public string Name
        {
            set
            {
                _Name = value;
            }
        }

        public ProgramDetail(ProgramModel model)
        {
            var data = DependencyService.Resolve<ProgramDetailViewModel>();
            InitializeComponent();
            BindingContext = data;

            data.LoadProgram(model);
            Name = model.Name;

        }

        
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WorkoutList());
        }

        private async void Ediit(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"ProgramEdit?name={_Name}");
        }
    }
}
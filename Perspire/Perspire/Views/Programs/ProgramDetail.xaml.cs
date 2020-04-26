using Perspire.DataStore;
using Perspire.ViewModels;
using Plugin.Toasts;
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
        ProgramModel _model;
        ProgramDetailViewModel data = DependencyService.Resolve<ProgramDetailViewModel>();
        DataRepository datastore = DependencyService.Resolve<DataRepository>();
        public ProgramDetail(ProgramModel model)
        {
            _model = model;
            
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

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            datastore.setCurrent(_model);
            var notificator = DependencyService.Get<IToastNotificator>();
            var options = new NotificationOptions()
            {
                Title = "Recorded",
                Description = "Your Program has been set"
            };

            notificator.Notify(options);
        }
    }
}
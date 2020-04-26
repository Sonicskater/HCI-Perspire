using Perspire.Models;
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
    public partial class NewStat : ContentPage
    {
        NewStatViewModel data = DependencyService.Resolve<NewStatViewModel>();
        public NewStat()
        {
            InitializeComponent();
            
            BindingContext = data;
        }

        public NewStat(StatModel s)
        {
            InitializeComponent();

            BindingContext = data;

            data.Load(s);
        }

        public void OnClickSave(Object sender, EventArgs e)
        {
            data.Save();
            Navigation.PopModalAsync();
        }
    }
}
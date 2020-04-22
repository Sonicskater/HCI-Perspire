using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchControlWorkouts : ContentView
    {
        public SearchControlWorkouts()
        {
            InitializeComponent();
            FilterButtonCommand = new Command(() =>
            {
                Navigation.PushModalAsync(new ProgramFilter());
            });
        }

        public static readonly BindableProperty FilterButtonProperty = BindableProperty.Create(nameof(FilterButtonCommand), typeof(ICommand), typeof(SearchControlWorkouts), null);

        public ICommand FilterButtonCommand
        {
            get { return (ICommand)GetValue(FilterButtonProperty); }
            set { SetValue(FilterButtonProperty, value); }
        }
    }
}
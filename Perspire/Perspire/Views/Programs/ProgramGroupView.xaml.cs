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
    public partial class ProgramGroupView : ViewCell
    {
        public ProgramGroupView()
        {
            InitializeComponent();
        }



        private void ToggleGroup(object sender, EventArgs e)
        {
            var bindingContext = ((ProgramGroupViewModel)BindingContext);
            bindingContext.Toggle();
        }
    }
}
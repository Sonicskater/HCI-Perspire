using Perspire.DataStore;
using Perspire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    public class ProgramListViewModel : BaseViewModel
    {
        public ObservableCollection<ProgramGroupViewModel> ProgramGroups { get; set; }  = new ObservableCollection<ProgramGroupViewModel>();

        private String _searchString = "";
        public String SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;

                foreach (var i in ProgramGroups)
                {
                    i.filter = value;
                }

            }
        }

        DataRepository data = DependencyService.Resolve<DataRepository>();

        private UserData user;
        public ProgramListViewModel()
        {
            user = data.GetUserData();

            user.PropertyChanged += (a, b) =>
            {
                Update();
            };

            Update();
        }

        public void Update()
        {
            ProgramGroups.Clear();
            ProgramGroups.Add(new ProgramGroupViewModel(new ProgramGroupModel
            {
                Name = "Current",
                programs = { user.currentProgram }
            }));
            foreach (var i in data.getProgramGroups())
            {
                ProgramGroups.Add(new ProgramGroupViewModel(i));
            }
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as ProgramModel;
            // await Navigation.PushModalAsync(new WorkoutListDetail(details.Name, details.Description, details.ImageSrc));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new WorkoutEdit());
        }
    }

    public class ProgramGroupViewModel : ObservableCollection<ProgramModel>, IEquatable<ProgramGroupViewModel>
    {
        private ProgramGroupModel programs;
        private bool _expanded = false;

        public ProgramGroupViewModel(ProgramGroupModel programs) : base()
        {
            this.programs = programs;
            Expanded = true;

            programs.PropertyChanged += (sender, e) => {
                Update();
            };
        }
        private String _filter = "";
        public String filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                Update();
            }
        }
        public void Update()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
            OnPropertyChanged(new PropertyChangedEventArgs("Glyph"));
            Clear();
            if (_expanded)
            {
                foreach (var i in programs.programs)
                {
                    if (i.Name.ToLower().Contains(_filter.ToLower()))
                    {
                        Add(i);
                    }

                }
            }
        }
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    Update();
                }
            }
        }
        private string collapsed = IconFont.ChevronUp;
        private string expanded = IconFont.ChevronDown;
        public string Glyph
        {
            get
            {
                if (Expanded)
                {
                    return expanded;
                }
                else
                {
                    return collapsed;
                }
            }
        }

        public string Name
        {
            get
            {
                return programs.Name;
            }
        }

        bool IEquatable<ProgramGroupViewModel>.Equals(ProgramGroupViewModel other)
        {
            return this.Name == other.Name;
        }

        public void Toggle()
        {
            this.Expanded = !this.Expanded;
        }
        
    }
}

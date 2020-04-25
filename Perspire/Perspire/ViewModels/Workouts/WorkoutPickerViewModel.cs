using Perspire.DataStore;
using Perspire.Models;
using Perspire.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Perspire.Views
{
    public class WorkoutPickerViewModel : BaseViewModel
    {
        public ObservableCollection<WorkoutGroupViewModel> WorkoutList { get; set; } = new ObservableCollection<WorkoutGroupViewModel>();

        private String _searchString = "";
        public String SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;

                foreach (var i in WorkoutList)
                {
                    i.filter = value;
                }

            }
        }
        DataRepository datastore = DependencyService.Resolve<DataRepository>();



        public WorkoutPickerViewModel()
        {
            var datalist = datastore.getWorkoutGroups();


            foreach (var i in datalist)
            {
                WorkoutList.Add(new WorkoutGroupViewModel(i));
            }

        }

        public void OnWorkoutPicked(WorkoutModel model)
        {
            if (taskCompletionSource != null)
            {
                taskCompletionSource.SetResult(model);
                taskCompletionSource = null;
            }
        }


        public void ToggleVis(int index)
        {
            WorkoutList[index].Expanded = !WorkoutList[index].Expanded;
        }

        public Task<WorkoutModel> PickWorkout()
        {
            taskCompletionSource = new TaskCompletionSource<WorkoutModel>();
            return taskCompletionSource.Task;
        }

        private TaskCompletionSource<WorkoutModel> taskCompletionSource;
    }
}
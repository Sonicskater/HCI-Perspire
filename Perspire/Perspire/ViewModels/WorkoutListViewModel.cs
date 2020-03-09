using System.Collections.ObjectModel;
using Perspire.Models;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel
    {
        public ObservableCollection<WorkoutListModel> WorkoutList { get; set; }
        public WorkoutListViewModel()
        {
            WorkoutList = new ObservableCollection<WorkoutListModel>();

            WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            /* add more stuffs */
        }
    }
}

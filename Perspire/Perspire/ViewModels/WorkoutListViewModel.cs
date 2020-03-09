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
                Name = "Deadlift",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            WorkoutList.Add(new WorkoutListModel
            {
                Name = "Bench Press",
                Part = "Chest",
                ImageSrc = "tab_about.png",
                Description = "chest workout"
            });
            /* add more stuffs */
        }
    }
}

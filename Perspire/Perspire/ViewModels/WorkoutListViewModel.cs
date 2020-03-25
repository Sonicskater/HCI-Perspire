using System.Collections.ObjectModel;
using Perspire.Models;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel
    {
        public ObservableCollection<GroupedWorkoutModel> WorkoutList { get; set; }
        public WorkoutListViewModel()
        {
            WorkoutList = new ObservableCollection<GroupedWorkoutModel>();
            WorkoutList.Add(new GroupedWorkoutModel());
            WorkoutList.Add(new GroupedWorkoutModel());
            WorkoutList[0].Name = "Back";
            WorkoutList[0].Add(new WorkoutListModel
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            WorkoutList[0].Add(new WorkoutListModel
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            WorkoutList[1].Name = "Shoulder";
            WorkoutList[1].Add(new WorkoutListModel
            {
                Name = "Workout 3",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            WorkoutList[1].Add(new WorkoutListModel
            {
                Name = "Workout 4",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            /* add more stuffs */


        }
    }
}

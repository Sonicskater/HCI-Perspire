using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Perspire.Models;

namespace Perspire.ViewModels
{
    public class WorkoutListViewModel : BaseViewModel
    {
        public ObservableCollection<GroupedWorkoutModel> WorkoutList { get; set; } = new ObservableCollection<GroupedWorkoutModel>();
        public WorkoutListViewModel()
        {
            var _WorkoutList = new List<WorkoutListModel>();
            
            _WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 1",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            _WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 2",
                Part = "Back",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new GroupedWorkoutModel(_WorkoutList, "Back"));
            _WorkoutList.Clear();
            _WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 3",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });

            _WorkoutList.Add(new WorkoutListModel
            {
                Name = "Workout 4",
                Part = "Shoulder",
                ImageSrc = "tab_about.png",
                Description = "back workout"
            });
            WorkoutList.Add(new GroupedWorkoutModel(_WorkoutList, "Shoulder"));
        }

        public void ToggleVis(int index)
        {
            WorkoutList[index].Expanded = !WorkoutList[index].Expanded;
        }
    }

}

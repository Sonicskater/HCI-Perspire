using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Perspire.Views;
using Autofac;
using Perspire.DataStore;
using Xamarin.Forms.Internals;
using Perspire.ViewModels;
using Perspire.ViewModels.Workouts;

namespace Perspire
{
    public partial class App : Application
    {

        public App()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataRepository>().SingleInstance();
            builder.RegisterType<WorkoutListViewModel>().SingleInstance();
            builder.RegisterType<WorkoutEditViewModel>();
            builder.RegisterType<WorkoutDetailViewModel>();
            builder.RegisterType<ProgramEditViewModel>();
            builder.RegisterType<WorkoutPickerViewModel>();
            builder.RegisterType<NewStatViewModel>();
            builder.RegisterType<StatsViewModel>().SingleInstance();
            builder.RegisterType<ProgramListViewModel>().SingleInstance();
            builder.RegisterType<ProgramDetailViewModel>();

            builder.RegisterType<DashBoardViewModel>();

            var container = builder.Build();

            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);

            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

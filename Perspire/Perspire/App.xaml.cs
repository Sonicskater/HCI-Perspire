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
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataRepository>().SingleInstance();
            builder.RegisterType<WorkoutListViewModel>().SingleInstance();
            builder.RegisterType<WorkoutEditViewModel>().SingleInstance();
            builder.RegisterType<StatsViewModel>().SingleInstance();

            var container = builder.Build();

            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

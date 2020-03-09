using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Views
{
    public partial class WorkoutListDetail : ContentPage
    {
        public WorkoutListDetail (string Name, string Description, string ImageSrc)
        {
            InitializeComponent();

            name.Text = Name;
            description.Text = Description;
/*
            image.Source = new UriImageSource()
            {
                Uri = new Uri(ImageSrc)
            };
*/
        }
    }
}
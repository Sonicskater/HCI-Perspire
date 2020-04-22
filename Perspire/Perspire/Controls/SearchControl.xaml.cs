﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Perspire.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchControl : ContentView
    {
        public SearchControl()
        {
            InitializeComponent();
            FilterButtonCommand = new Command(() =>
            {
                System.Console.WriteLine("TEST!");
            });
        }

        public static readonly BindableProperty FilterButtonProperty = BindableProperty.Create(nameof(FilterButtonCommand), typeof(ICommand), typeof(SearchControl), null);

        public ICommand FilterButtonCommand
        {
            get { return (ICommand)GetValue(FilterButtonProperty); }
            set { SetValue(FilterButtonProperty, value); }
        }
    }
}
﻿using System;
using System.ComponentModel;
using LifeCycleEffectTesting.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleEffectTesting.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();
        }
    }
}
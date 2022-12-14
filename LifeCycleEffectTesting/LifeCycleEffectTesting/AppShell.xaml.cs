using LifeCycleEffectTesting.Extensions;
using LifeCycleEffectTesting.ViewModels;
using LifeCycleEffectTesting.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LifeCycleEffectTesting
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

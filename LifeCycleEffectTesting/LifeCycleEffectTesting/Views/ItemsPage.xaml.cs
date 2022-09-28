using LifeCycleEffectTesting.Models;
using LifeCycleEffectTesting.ViewModels;
using LifeCycleEffectTesting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeCycleEffectTesting.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleEffectTesting.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
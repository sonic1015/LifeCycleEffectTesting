using LifeCycleEffectTesting.Extensions;
using LifeCycleEffectTesting.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LifeCycleEffectTesting.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();
            
            BindingContext = new ItemDetailViewModel();
        }
    }
}
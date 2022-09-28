using LifeCycleEffectTesting.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LifeCycleEffectTesting.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
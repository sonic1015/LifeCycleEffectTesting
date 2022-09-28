using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeCycleEffectTesting.Extensions;
using LifeCycleEffectTesting.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleEffectTesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemView
    {
        public NewItemView()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();

            BindingContext = new NewItemViewModel();
        }
    }
}
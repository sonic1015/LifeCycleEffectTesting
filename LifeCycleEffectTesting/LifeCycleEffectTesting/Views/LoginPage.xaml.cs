using LifeCycleEffectTesting.Extensions;
using LifeCycleEffectTesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleEffectTesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            this.InitializeConnectionToParent();

            InitializeComponent();
            
            this.BindingContext = new LoginViewModel();
        }
    }
}
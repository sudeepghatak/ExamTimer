using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerSettings : ContentPage
    {
        public TimerSettings()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new ParametersViewModel(this);

        }
    }
}
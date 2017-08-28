using System.Collections.Generic;
using System.Threading.Tasks;
using Timer.Data;
using Timer.ViewModels;
using Xamarin.Forms;


namespace Timer
{


    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
             InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (App.ViewModel == null) App.ViewModel = new TimerViewModel(this);

            this.BindingContext = App.ViewModel;

            var result = await App.Database.GetItemsAsync();

            if (result.Count == 0)
            {
                Config config1 = new Config();
                config1.Key = "Questions";
                config1.Value = 60;

                Task<int> taskId1 = App.Database.InsertItemAsync(config1);

                Config config2 = new Config();
                config2.Key = "Minutes";
                config2.Value = 120;

                Task<int> taskId2 = App.Database.InsertItemAsync(config2);
            }


        }
    }
}

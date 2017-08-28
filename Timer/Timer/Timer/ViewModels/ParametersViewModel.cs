using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Timer.Data;
using Xamarin.Forms;

namespace Timer.ViewModels
{
    public class ParametersViewModel: INotifyPropertyChanged
    {
        public ICommand UpdateParameters { get; private set; }
        public int QuesId { get; set; }
        public int MinutesId { get; set; }

        public ParametersViewModel(TimerSettings settingsPage)
        {
            Initialize();
            
            UpdateParameters = new Command<object>(UpdateConfigValues);
        }

        public async void UpdateConfigValues(object obj)
        {
            ParametersViewModel param = (ParametersViewModel)obj;
            int mins = param.Minutes;
            int ques = param.Questions;

            Config configQuestions = new Config();
            configQuestions.ID = QuesId;
            configQuestions.Key = "Questions";
            configQuestions.Value = ques;

            Config configMinutes = new Config();
            configMinutes.ID = QuesId;
            configMinutes.Key = "Minutes";
            configMinutes.Value = mins;

            await App.Database.SaveItemAsync(configQuestions);
            await App.Database.SaveItemAsync(configMinutes);

        }

        

        public async void Initialize()
        {
            Config questions = await App.Database.GetKey("Questions");
            Questions = questions.Value;
            QuesId = questions.ID;

            Config minutes = await App.Database.GetKey("Minutes");
            Minutes = minutes.Value;
            MinutesId = minutes.ID;
        }

        private int _questions;
        public int Questions {
            get {
                
                return this._questions;
            }
            set
            {
                this._questions = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Questions"));
                }

            }
        }
        private int _minutes;
        public int Minutes
        {
            get
            {
                return this._minutes;
            }
            set
            {
                this._minutes = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Minutes"));
                }

            }
        }
        public int Seconds { get { return Minutes * 60;}   }
        public int Hours { get { return Minutes / 60; } }
        public int RemainingMinutes { get { return Minutes % 60; } }
        public int RemainingSeconds { get { return Seconds % 60; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

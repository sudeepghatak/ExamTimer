using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Timer.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        public TimerViewModel(MainPage activityPage)
        {
            this.StartTimerClock = new Command<string>((key) =>
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    this.ExamProgress += 0.1;
                    return true;
                })
                );
            

        }
        

        private double _examProgress;
        public double ExamProgress
        {
            get { return this._examProgress; }
            set {
                this._examProgress = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("ExamProgress"));
                }
                
            }
        }


        private Color _alertColor;
        public Color AlertColor
        {
            get { return this._alertColor; }
            set { this._alertColor = value; }
        }
        //public double ExamProgress { get; set; }
        public ICommand StartTimerClock { get; private set; }
        
    }
}

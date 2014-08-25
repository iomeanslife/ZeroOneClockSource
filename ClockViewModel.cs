using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BinaryClockTry1
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        private int _digit1;
        private int _digit2;
        private int _digit3;
        private int _digit4;
        private int _digit5;
        private int _digit6;
        private TimeSpan _manipulateTime;

        private Visibility _dotsVisibility;

        private DispatcherTimer Timer;

        public ClockViewModel()
        {
            this.Timer = new DispatcherTimer();
            this.Timer.Tick += Timer_Tick;
            this.Timer.Interval = TimeSpan.FromMilliseconds(100d);
            this.Timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now + this.ManipulateTime;

            this.Digit1 = currentDateTime.Hour / 10;
            this.Digit2 = currentDateTime.Hour % 10;

            this.Digit3 = currentDateTime.Minute / 10;
            this.Digit4 = currentDateTime.Minute % 10;

            this.Digit5 = currentDateTime.Second / 10;
            this.Digit6 = currentDateTime.Second % 10;

            if (DateTime.Now.Second % 2 != 0)
            {
                DotsVisibility = Visibility.Visible;
            }
            else
            {
                DotsVisibility = Visibility.Collapsed;
            }
        }

        public TimeSpan ManipulateTime
        {
            get
            {
                return this._manipulateTime;
            }
            set
            {
                if (this._manipulateTime != value)
                {
                    this._manipulateTime = value;
                    OnPropertyChanged("ManipulateTime");
                }
            }
        }

        public int Digit1
        {
            get
            {
                return this._digit1;
            }

            private set
            {
                if (this._digit1 != value)
                {
                    this._digit1 = value;
                    OnPropertyChanged("Digit1");
                }
            }
        }

        public int Digit2
        {
            get
            {
                return this._digit2;
            }

            private set
            {
                if (this._digit2 != value)
                {
                    this._digit2 = value;
                    OnPropertyChanged("Digit2");
                }
            }
        }

        public int Digit3
        {
            get
            {
                return this._digit3;
            }

            private set
            {
                if (this._digit3 != value)
                {
                    this._digit3 = value;
                    OnPropertyChanged("Digit3");
                }
            }
        }

        public int Digit4
        {
            get
            {
                return this._digit4;
            }

            private set
            {
                if (this._digit4 != value)
                {
                    this._digit4 = value;
                    OnPropertyChanged("Digit4");
                }
            }
        }

        public int Digit5
        {
            get
            {
                return this._digit5;
            }

            private set
            {
                if (this._digit5 != value)
                {
                    this._digit5 = value;
                    OnPropertyChanged("Digit5");
                }
            }
        }

        public int Digit6
        {
            get
            {
                return this._digit6;
            }

            private set
            {
                if (this._digit6 != value)
                {
                    this._digit6 = value;
                    OnPropertyChanged("Digit6");
                }
            }
        }

        public Visibility DotsVisibility
        {
            get
            {
                return this._dotsVisibility;
            }

            set
            {
                if (this._dotsVisibility != value)
                {
                    this._dotsVisibility = value;
                    OnPropertyChanged("DotsVisibility");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

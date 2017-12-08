#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace SampleBrowser
{
    public class StocksViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Members

        ObservableCollection<StockData> data;
        Random r = new Random(123345345);
        internal Timer timer;
        private bool enableTimer = false;
        //private DelegateCommand<object> btonClick;
        private double timerValue;
        private string buttonContent;
        private int noOfUpdates = 500;
        List<string> StockSymbols = new List<string>();
        string[] accounts = new string[] {
            "American Funds",
            "College Savings",
            "Day Trading",
            "Retirement Savings",
            "Mountain Ranges",
            "Fidelity Funds",
            "Mortages",
            "Housing Loans"
        };

        #endregion

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockData> Stocks
        {
            get
            {
                return this.data;
            }
        }

        #region Constructor



        /// <summary>
        /// Initializes a new instance of the <see cref="StocksViewModel"/> class.
        /// </summary>
        public StocksViewModel()
        {
            this.data = new ObservableCollection<StockData>();
            this.AddRows(2000);
            this.timer = new Timer();
            this.ResetRefreshFrequency(2500);
            timer.Interval = (double)TimeSpan.FromMilliseconds(200).Milliseconds;
            ButtonContent = "Start Timer";
            timer.Elapsed += timer_Tick;
            ButtonClicked();
        }


        #endregion

        #region Timer and updating code

        /// <summary>
        /// Sets the interval.
        /// </summary>
        /// <param name="time">The time.</param>
        public void SetInterval(TimeSpan time)
        {
            this.timer.Interval = Convert.ToDouble(time);
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            if (!this.timer.Enabled)
            {
                this.timer.Start();
                this.ButtonContent = "Stop Timer";
            }
        }

        /// <summary>
        /// Gets or sets the timer value.
        /// </summary>
        /// <value>The timer value.</value>
        public double TimeSpanValue
        {
            get
            {
                return timerValue;
            }
            set
            {
                timerValue = value;
                this.timer.Interval = Convert.ToDouble(TimeSpan.FromMilliseconds(timerValue));
                RaisePropertyChanged("TimeSpanValue");
            }
        }

        /// <summary>
        /// Gets or sets the button contnt.
        /// </summary>
        /// <value>The button contnt.</value>
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                buttonContent = value;
                RaisePropertyChanged("ButtonContent");
            }
        }

        /// <summary>
        /// Gets the bton click.
        /// </summary>
        /// <value>The bton click.</value>
        //        public DelegateCommand<object> BtonClick
        //        {
        //            get { return btonClick; }
        //        }

        /// <summary>
        /// Determines whether this instance [can button click].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance [can button click]; otherwise, <c>false</c>.
        /// </returns>
        bool CanButtonClick(object param)
        {
            return true;
        }

        /// <summary>
        /// Buttons the clicked.
        /// </summary>
        /// <param name="param">The param.</param>
        /// 
        public void ButtonClicked()
        {
            if (ButtonContent.Equals("Start Timer"))
            {
                this.EnableTimer = true;

                this.StartTimer();
                ButtonContent = "Stop Timer";
            }
            else {
                this.EnableTimer = false;

                this.StopTimer();
                ButtonContent = "Start Timer";
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, object e)
        {
            int startTime = DateTime.Now.Millisecond;
            noOfUpdates = 100;
            ChangeRows(noOfUpdates);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable timer].
        /// </summary>
        /// <value><c>true</c> if [enable timer]; otherwise, <c>false</c>.</value>
        public bool EnableTimer
        {
            get
            {
                return this.enableTimer;
            }
            set
            {
                this.enableTimer = value;
            }
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void AddRows(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockData();
                newRec.Symbol = ChangeSymbol();
                newRec.Account = ChangeAccount(i);
                newRec.Open = Math.Round(r.NextDouble() * 30, 2);
                newRec.LastTrade = Math.Round((1 + r.NextDouble() * 50));
                double d = r.NextDouble();
                if (d < .5)
                    newRec.StockChange = Math.Round(d, 2);
                else
                    newRec.StockChange = Math.Round(d, 2) * -1;

                newRec.PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                newRec.Volume = r.Next();
                data.Add(newRec);
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns></returns>
        private String ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

            } while (StockSymbols.Contains(builder.ToString()));

            StockSymbols.Add(builder.ToString());
            return builder.ToString();
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private String ChangeAccount(int index)
        {
            return accounts[index % accounts.Length];
        }

        /// <summary>
        /// Resets the refresh frequency.
        /// </summary>
        /// <param name="changesPerTick">The changes per tick.</param>
        public void ResetRefreshFrequency(int changesPerTick)
        {
            if (this.timer == null)
            {
                return;
            }

            if (!this.noOfUpdates.Equals(changesPerTick))
            {
                this.StopTimer();
                this.noOfUpdates = changesPerTick;
                if (enableTimer)
                    this.StartTimer();
            }
        }

        public object SelectedItem
        {
            get
            {
                return noOfUpdates;
            }
            set
            {
                noOfUpdates = 2;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public List<int> ComboCollection
        {
            get
            {
                return new List<int> { 500, 5000, 50000, 500000 };
            }
        }

        /// <summary>
        /// Changes the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void ChangeRows(int count)
        {
            if (data.Count < count)
                count = data.Count;
            for (int i = 0; i < count; ++i)
            {
                int recNo = r.Next(data.Count);
                StockData recRow = data[recNo];

                data[recNo].LastTrade = Math.Round((1 + r.NextDouble() * 50));

                double d = r.NextDouble();
                if (d < .5)
                {
                    data[recNo].StockChange = Math.Round(d, 2);
                }
                else {
                    data[recNo].StockChange = Math.Round(d, 2) * -1;
                }
                data[recNo].Open = Math.Round(r.NextDouble() * 50, 2);
                data[recNo].PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                data[recNo].Volume = r.Next();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Elapsed -= timer_Tick;
                this.StopTimer();
            }
        }

        #endregion
    }
}

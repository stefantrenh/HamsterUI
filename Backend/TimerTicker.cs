using System;
using  Backend.Events;
using System.Threading;

namespace Backend
{
    public class TimerTicker
    {
        Timer Timer_;
        private int counter;
        private int dayCounter = 2;
        private int tickerSpeed;
        private DateTime date;
        private DateTime totalDays;
        public event EventHandler<TimerEventArgs> SendTick;

        public TimerTicker(int tickspeed,int totaldays)
        {
            date = new DateTime(2021, 04, 01, 07, 00, 00);
            tickerSpeed = tickspeed;
            totalDays = new DateTime(2021,04,totaldays+1);
        }
        public void StartTicks()
        {
            Timer_ = new Timer(new TimerCallback(OnStartTicks), null, 500, tickerSpeed);
        }
        public virtual void OnStartTicks(object state)
        {
            counter++;
            if (counter > 1)
            {
                date = date.AddMinutes(6);
            }
            if (counter % 102 == 0)
            {
                date = new DateTime(2021, 04, dayCounter, 07, 00, 00);
                dayCounter++;
                counter = 0;
            }
            TimerEventArgs args = new TimerEventArgs();
            args.Ticker = counter;
            args.Time = date;
            if (date.Day == totalDays.Day)
            {
                Timer_.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else
            {
                SendTick?.Invoke(this, args);
            }
        }
        public virtual void OnSendningDailyInfo(object sender, DailyReportEventArgs e)
        {
                Timer_.Change(Timeout.Infinite, Timeout.Infinite); // stops the ticker
                Timer_.Change(5000,tickerSpeed);
        }
    }

    public class TimerEventArgs : EventArgs
    {
        public int Ticker { get; set; }
        public DateTime Time { get; set; }
    }
}

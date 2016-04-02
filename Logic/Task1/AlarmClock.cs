using System;
using System.Threading;

namespace Logic.Task1
{
    public class AlarmClock
    {
        private uint seconds;
        public event EventHandler<AlarmClockEventArgs> OnAlarm = delegate { };

        public AlarmClock(uint seconds)
        {
            this.seconds = seconds;
        }

        public void Start()
        {
            for (uint i = 0; i < seconds; i++)
                Thread.Sleep(1000);
                   
            AlarmClockEventArgs args = new AlarmClockEventArgs(seconds);
            Alarm(args);
        }

        private void Alarm(AlarmClockEventArgs e)
        {
            EventHandler<AlarmClockEventArgs> eventHandler = OnAlarm;
            eventHandler?.Invoke(this, e);
        }
    }

    public class AlarmClockEventArgs: EventArgs
    {
        private uint elapsedSeconds;
        public uint ElapsedSeconds { get { return elapsedSeconds; } }
        public AlarmClockEventArgs(uint elapsedSeconds)
        {
            this.elapsedSeconds = elapsedSeconds;
        }
    }
}

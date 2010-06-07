using System;
using System.Threading;

namespace MemeLibrary
{
    public class MemeEvent
    {
        private Timer _memeDelay;

        public delegate void TimerFired(MemeEvent sender);

        public event TimerFired OnTimerFired;

        #region Properties

        public TimeSpan Delay { get; private set; }

        public MemeEventType EventType { get; private set; }

        public MemePriority Priority { get; private set; }

        #endregion

        #region Constructors

        public MemeEvent(TimeSpan delay, MemePriority priority, MemeEventType eventType)
        {
            Delay = delay;
            Priority = priority;
            EventType = eventType;

            _memeDelay = new Timer(TimerHasFired, null, new TimeSpan(0,0,3), delay);
        } 

        #endregion

        public void TimerHasFired(object stuff)
        {
            if (OnTimerFired != null)
            {
                OnTimerFired(this);
            }
        }
    }
}

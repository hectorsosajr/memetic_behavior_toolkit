using System;
using MemeLibrary;

namespace CustomMemes
{
    public class WanderMeme : Meme
    {
        public new MemeEventHasFired OnMemeEventHasFired;

        #region Member Variables

        private MemeEvent event1;
        private MemeEvent event2;
        private MemeEvent event3;
        private MemeEvent event4; 

        #endregion

        #region Constructors

        public WanderMeme()
        {
            Name = "Wandering Meme";
        } 

        #endregion

        #region Public Members

        public override void Restart()
        {
            Priority = MemePriority.Low;
            PriorityLevel = 0;
            Flags = MemeFlags.Resume | MemeFlags.Repeat;

            SetupEventGenerators();
        }

        public override void Stop()
        {
            event1.OnTimerFired -= EventOnTimerFiredHandler;
            event2.OnTimerFired -= EventOnTimerFiredHandler;
            event3.OnTimerFired -= EventOnTimerFiredHandler;
            event4.OnTimerFired -= EventOnTimerFiredHandler;

            Events.Clear();
        }

        #endregion

        #region Private Members

        private void SetupEventGenerators()
        {
            event1 = new MemeEvent(new TimeSpan(0, 0, 5), MemePriority.Medium, MemeEventType.Timed);
            event1.OnTimerFired += EventOnTimerFiredHandler;
            Events.Add(event1);

            event2 = new MemeEvent(new TimeSpan(0, 0, 3), MemePriority.Medium, MemeEventType.Timed);
            event2.OnTimerFired += EventOnTimerFiredHandler;
            Events.Add(event2);

            event3 = new MemeEvent(new TimeSpan(0, 0, 10), MemePriority.Low, MemeEventType.Timed);
            event3.OnTimerFired += EventOnTimerFiredHandler;
            Events.Add(event3);

            event4 = new MemeEvent(new TimeSpan(0, 0, 20), MemePriority.Medium, MemeEventType.Timed);
            event4.OnTimerFired += EventOnTimerFiredHandler;
            Events.Add(event4);
        } 

        #endregion

        #region Event Handlers

        private void EventOnTimerFiredHandler(MemeEvent sender)
        {
            if (OnMemeEventHasFired != null)
            {
                OnMemeEventHasFired(this, sender);
            }
        } 

        #endregion
    }
}

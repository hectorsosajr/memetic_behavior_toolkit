using System;
using System.Collections.Generic;

namespace MemeLibrary
{
    /// <summary>
    /// A meme is the encapsulation of the smallest behavior, or sets of behaviors.
    /// </summary>
    public class Meme: IMeme
    {
        #region Constructors

        public Meme()
        {
            Init();
        }

        public Meme(string name)
        {
            Name = name;
            Init();
        }

        #endregion

        #region Public Members

        public virtual void Start() {}

        #endregion

        #region Private Members

        private void Init()
        {
            Priority = MemePriority.Default;

            PriorityLevel = 0;

            Flags = MemeFlags.Resume;

            Events = new List<MemeEvent>();
        }

        #endregion

        #region Implementation of IMeme

        /// <summary>
        /// The name for this meme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Flags for this meme.
        /// </summary>
        public MemeFlags Flags { get; set; }

        /// <summary>
        /// The behavior priority for this meme.
        /// </summary>
        public MemePriority Priority { get; set; }

        /// <summary>
        /// Priorities are bands of values. The priority level defines
        /// where in the priority does this band fall. These are usually
        /// between -100 and 100.
        /// </summary>
        public int PriorityLevel { get; set; }

        /// <summary>
        /// A meme can contain child memes. This contains a list of all the
        /// child memes.
        /// </summary>
        public List<IMeme> ChildMemes { get; set; }

        /// <summary>
        /// Holds a list of internal event generators that will fire throught
        /// the meme's lifecycle.
        /// </summary>
        public List<MemeEvent> Events { get; set; }

        /// <summary>
        /// This helps in identifying memes, as two memes can have the same name.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// How long this meme will last. This is optional functionality.
        /// </summary>
        public TimeSpan Duration { get; set; }

        public virtual void Restart()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual void Stop()
        {
        }

        public event MemeEventHasFired MemeEventFired;

        #endregion
    }
}

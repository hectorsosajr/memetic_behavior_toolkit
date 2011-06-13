using System;
using System.Collections.Generic;

namespace MemeLibrary
{
    /// <summary>
    /// A meme is the encapsulation of the smallest behavior, or sets of behaviors.
    /// </summary>
    public class Meme : IMeme
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

        #region Implementation of IMeme

        public event MemeEventHasFired OnMemeEventHasFired;

        /// <summary>
        /// Gets or sets the name for this meme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Flags for this meme.
        /// </summary>
        public MemeFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the behavior priority for this meme.
        /// </summary>
        public MemePriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the priority level for this meme.
        /// </summary>
        /// <remarks>
        /// Priorities are bands of values. The priority level defines
        /// where in the priority does this band fall. These are usually
        /// between -100 and 100.
        /// </remarks>
        public int PriorityLevel { get; set; }

        /// <summary>
        /// Gets or sets the list of child memes.
        /// </summary>
        /// <remarks>
        /// A meme can contain child memes. This contains a list of all the
        /// child memes.
        /// </remarks>
        public List<IMeme> ChildMemes { get; set; }

        /// <summary>
        /// Gets or sets a list of internal event generators that will fire throughout
        /// the meme's lifecycle.
        /// </summary>
        public List<MemeEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the meme's time stamp.
        /// </summary>
        /// <remarks>
        /// This helps in identifying memes, as two memes can have the same name.
        /// </remarks>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the meme's duration.
        /// </summary>
        /// <remarks>
        /// How long this meme will last. This is optional functionality.
        /// </remarks>
        public TimeSpan Duration { get; set; }

        public virtual void Restart()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual void Stop()
        { }

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
    }
}

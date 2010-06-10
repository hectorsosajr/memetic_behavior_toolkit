using System;
using System.Collections.Generic;

namespace MemeLibrary
{
    class MemeFIFOSequence : Stack<Meme>, IMeme
    {
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

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public event MemeEventHasFired OnMemeEventHasFired;

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace MemeLibrary
{
    /// <summary>
    /// Interface for any entity that will behave like a meme.
    /// </summary>
    public interface IMeme
    {
        #region Properties

        /// <summary>
        /// The name for this meme.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The Flags for this meme.
        /// </summary>
        MemeFlags Flags { get; set; }

        /// <summary>
        /// The behavior priority for this meme.
        /// </summary>
        MemePriority Priority { get; set; }

        /// <summary>
        /// Priorities are bands of values. The priority level defines
        /// where in the priority does this band fall. These are usually
        /// between -100 and 100.
        /// </summary>
        int PriorityLevel { get; set; }

        /// <summary>
        /// A meme can contain child memes. This contains a list of all the
        /// child memes.
        /// </summary>
        List<IMeme> ChildMemes { get; set; }

        /// <summary>
        /// Holds a list of internal event generators that will fire throught
        /// the meme's lifecycle.
        /// </summary>
        List<MemeEvent> Events { get; set; }

        /// <summary>
        /// This helps in identifying memes, as two memes can have the same name.
        /// </summary>
        DateTime TimeStamp { get; set; }

        /// <summary>
        /// How long this meme will last. This is optional functionality.
        /// </summary>
        TimeSpan Duration { get; set; }

        #endregion

        #region Public Members

        void Restart();

        void Stop();

        #endregion

        #region Events

        event MemeEventHasFired OnMemeEventHasFired; 

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace MemeLibrary
{
    /// <summary>
    /// Interface for any entity that will behave like a meme.
    /// </summary>
    public interface IMeme
    {
        #region Events

        event MemeEventHasFired OnMemeEventHasFired;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name for this meme.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the Flags for this meme.
        /// </summary>
        MemeFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the behavior priority for this meme.
        /// </summary>
        MemePriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the priority level for this meme.
        /// </summary>
        /// <remarks>
        /// Priorities are bands of values. The priority level defines
        /// where in the priority does this band fall. These are usually
        /// between -100 and 100.
        /// </remarks>
        int PriorityLevel { get; set; }

        /// <summary>
        /// Gets or sets the list of child memes.
        /// </summary>
        /// <remarks>
        /// A meme can contain child memes. This contains a list of all the
        /// child memes.
        /// </remarks>
        List<IMeme> ChildMemes { get; set; }

        /// <summary>
        /// Gets or sets a list of internal event generators that will fire throughout
        /// the meme's lifecycle.
        /// </summary>
        List<MemeEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the meme's time stamp.
        /// </summary>
        /// <remarks>
        /// This helps in identifying memes, as two memes can have the same name.
        /// </remarks>
        DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the meme's duration.
        /// </summary>
        /// <remarks>
        /// How long this meme will last. This is optional functionality.
        /// </remarks>
        TimeSpan Duration { get; set; }

        #endregion

        #region Public Members

        void Restart();

        void Stop();

        #endregion
    }
}

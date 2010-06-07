using System;

namespace MemeLibrary
{
    /// <summary>
    /// The importance of the meme. The meme with
    /// the highest priority at any given time will
    /// the one running.
    /// </summary>
    public enum MemePriority
    {
        None,
        Default,
        Low,
        Medium,
        High,
        VeryHigh
    }

    /// <summary>
    /// Controls the behavior of the meme during its lifecycle.
    /// 
    /// </summary>
    [Flags]
    public enum MemeFlags
    {
        /// <summary>
        /// Auto resume the behavior, if the meme is interrupted.
        /// </summary>
        Resume,
        /// <summary>
        /// Causes the meme to loop.
        /// </summary>
        Repeat,
        /// <summary>
        /// Do not create the behavior, if there are memes with higher priorities.
        /// </summary>
        Instant,
        /// <summary>
        /// Create the behavior, but do not interrupt the current one.
        /// </summary>
        Immediate
    }

    public enum MemeStates
    {
        /// <summary>
        /// The meme is currently active and engaged.
        /// </summary>
        Active,
        /// <summary>
        /// The meme is waiting for other memes to finish, or
        /// is queued up to be next.
        /// </summary>
        Pending
    }

    public enum MemeEventType
    {
        Timed,
        Signal
    }
}

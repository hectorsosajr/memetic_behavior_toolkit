using System.Collections;

namespace NpcLibrary
{
    /// <summary>
    /// A sense-based message.
    /// </summary>
    public class SensoryMessage
    {
        /// <summary>
        /// Initializes a new instance of the SensoryMessage class.
        /// </summary>
        /// <param name="targetedSense">The sense this message is for.</param>
        /// <param name="messageStrength">The strength of the message.</param>
        public SensoryMessage(SensoryType targetedSense, int messageStrength)
        {
            this.TargetedSense = targetedSense;
            this.MessageStrength = messageStrength;
            this.Context = new Hashtable();
        }

        /// <summary>Gets the sense this message is for.</summary>
        public SensoryType TargetedSense { get; private set; }

        /// <summary>Gets the strength of the message.</summary>
        public int MessageStrength { get; private set; }

        /// <summary>Gets the context for the view processor to use to render the message.</summary>
        public Hashtable Context { get; private set; }
    }
}

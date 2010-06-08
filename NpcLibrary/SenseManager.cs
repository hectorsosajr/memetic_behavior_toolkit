using System.Collections.Generic;

namespace NpcLibrary
{
    /// <summary>
    /// A manager of senses, as used for perception by Things.
    /// </summary>
    public class SenseManager
    {
        /// <summary>The synchronization locking object.</summary>
        private readonly object lockObject = new object();

        /// <summary>The collection of managed senses.</summary>
        private Dictionary<SensoryType, Sense> senses = new Dictionary<SensoryType, Sense>();

        /// <summary>
        /// Provide array-style indexing for the managed senses.
        /// </summary>
        /// <param name="index">The senses index.</param>
        /// <returns>The sense found at that index.</returns>
        public Sense this[SensoryType index]
        {
            get
            {
                return this.senses[index];
            }

            set
            {
                this.senses[index] = value;
            }
        }

        /// <summary>
        /// Adds the specified sense to this SenseManager.
        /// </summary>
        /// <param name="sense">The sense to add.</param>
        public void AddSense(Sense sense)
        {
            lock (this.lockObject)
            {
                this.senses.Add(sense.Name, sense);
            }
        }

        /// <summary>
        /// Removes the specified sense from this SenseManager.
        /// </summary>
        /// <param name="sense">The sense to remove.</param>
        public void RemoveSense(Sense sense)
        {
            lock (this.lockObject)
            {
                this.senses.Remove(sense.Name);
            }
        }

        /// <summary>
        /// Determines if the collection of senses contain the specified sense.
        /// </summary>
        /// <param name="sense">The sense to search for.</param>
        /// <returns>True if the collection of senses contains this sense, else false.</returns>
        public bool Contains(Sense sense)
        {
            return this.senses.ContainsKey(sense.Name);
        }

        /// <summary>
        /// Determines if the collection of senses contain the specified sense.
        /// </summary>
        /// <param name="senseType">The sense to search for.</param>
        /// <returns>True if the collection of senses contains this sense, else false.</returns>
        public bool Contains(SensoryType senseType)
        {
            lock (this.lockObject)
            {
                return this.senses.ContainsKey(senseType);
            }
        }

        /// <summary>
        /// Gets the total count of all senses.
        /// </summary>
        /// <returns>The total count of all senses.</returns>
        public int Count()
        {
            return this.senses.Count;
        }

        /// <summary>
        /// Gets an enumerator for the senses.
        /// </summary>
        /// <returns>An enumerator for the senses.</returns>
        public IEnumerator<Sense> GetEnumerator()
        {
            return this.senses.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets the dictionary of senses.
        /// </summary>
        /// <returns>A dictionary of senses.</returns>
        public Dictionary<SensoryType, Sense> GetSenses()
        {
            return this.senses;
        }

        /// <summary>
        /// Determine if the specified sensory message can be processed.
        /// </summary>
        /// <param name="message">The sensory message.</param>
        /// <returns>True if it can be processed, else false.</returns>
        public bool CanProcessSensoryMessage(SensoryMessage message)
        {
            if (this.senses.ContainsKey(message.TargetedSense) &&
                (this.senses[message.TargetedSense].LowThreshold <= message.MessageStrength &&
                    this.senses[message.TargetedSense].HighThreshold >= message.MessageStrength) &&
                        this.senses[message.TargetedSense].Enabled == true)
            {
                return true;
            }

            return false;
        }
    }
}

using System.Collections.Generic;

namespace MemeLibrary
{
    public class MemeManager
    {
        /// <summary>The collection of managed memes.</summary>
        private readonly Dictionary<string, IMeme> memes = new Dictionary<string, IMeme>();

        /// <summary>The synchronization locking object.</summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// Adds the specified sense to this SenseManager.
        /// </summary>
        /// <param name="sense">The sense to add.</param>
        public void AddMeme(Meme sense)
        {
            lock (lockObject)
            {
                memes.Add(sense.Name, sense);
            }
        }

        /// <summary>
        /// Removes the specified sense from this SenseManager.
        /// </summary>
        /// <param name="sense">The sense to remove.</param>
        public void RemoveMeme(Meme sense)
        {
            lock (lockObject)
            {
                memes.Remove(sense.Name);
            }
        }

        /// <summary>
        /// Determines if the collection of senses contain the specified sense.
        /// </summary>
        /// <param name="meme">The meme to search for.</param>
        /// <returns>True if the collection of senses contains this sense, else false.</returns>
        public bool Contains(Meme meme)
        {
            return memes.ContainsKey(meme.Name);
        }

        /// <summary>
        /// Gets the total count of all memes.
        /// </summary>
        /// <returns>The total count of all memes.</returns>
        public int Count()
        {
            return memes.Count;
        }

        /// <summary>
        /// Gets an enumerator for the memes.
        /// </summary>
        /// <returns>An enumerator for the memes.</returns>
        public Dictionary<string, IMeme>.ValueCollection.Enumerator GetEnumerator()
        {
            return memes.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets the dictionary of memes.
        /// </summary>
        /// <returns>A dictionary of memes.</returns>
        public Dictionary<string, IMeme> GetSenses()
        {
            return memes;
        }
    }
}

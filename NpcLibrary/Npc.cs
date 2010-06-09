using MemeLibrary;

namespace NpcLibrary
{
    public class Npc
    {
        #region Member Variables

        /// <summary>The senses available to this thing.</summary>
        private readonly SenseManager _senseManager = new SenseManager();
 
        private readonly MemeManager _memeManager = new MemeManager();

        #endregion

        #region Constructors

        public Npc()
        {
            LoadSenses();
        } 

        #endregion

        #region Properties

        public SenseManager Senses
        {
            get { return _senseManager; }
        }
 
        public MemeManager Memes
        {
            get { return _memeManager; }
        }

        public string Name { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// Allows a caller to determine whether this npc can be detected by somethings senses
        /// </summary>
        /// <param name="senses">The sense manager.</param>
        /// <returns>True if detectable by sense, else false.</returns>
        public virtual bool IsDetectableBySense(SenseManager senses)
        {
            return senses.Contains(SensoryType.Sight) && senses[SensoryType.Sight].Enabled;
        }

        public virtual void StopMemes()
        {
            foreach (var meme in Memes)
            {
                meme.Stop();
            }
        }

        public virtual void StartMemes()
        {
            foreach (var meme in Memes)
            {
                meme.Restart();
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Load the senses of the entity.
        /// </summary>
        private void LoadSenses()
        {
            int senseCount;
            Sense currSense = null;

            for (senseCount = 1; senseCount < 7; senseCount++)
            {
                switch (senseCount)
                {
                    case 1:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Hearing;
                        currSense.MessagePrefix = "[HEARING]";
                        currSense.Measurement = SensoryTypeMeasurement.Decibel;
                        currSense.Enabled = true;
                        break;
                    case 2:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Sight;
                        currSense.MessagePrefix = "[SIGHT]";
                        currSense.Measurement = SensoryTypeMeasurement.Lumen;
                        currSense.Enabled = true;
                        break;
                    case 3:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Smell;
                        currSense.MessagePrefix = "[SMELL]";
                        currSense.Measurement = SensoryTypeMeasurement.PartsPerMillion;
                        currSense.Enabled = true;
                        break;
                    case 4:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Touch;
                        currSense.MessagePrefix = "[TOUCH]";
                        currSense.Measurement = SensoryTypeMeasurement.PoundsPerSquareInch;
                        currSense.Enabled = true;
                        break;
                    case 5:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Taste;
                        currSense.MessagePrefix = "[TASTE]";
                        currSense.Measurement = SensoryTypeMeasurement.PartsPerMillion;
                        currSense.Enabled = true;
                        break;
                    case 6:
                        currSense = new Sense();
                        currSense.Name = SensoryType.Debug;
                        currSense.MessagePrefix = "[DEBUG]";
                        currSense.Measurement = SensoryTypeMeasurement.Debug;
                        currSense.Enabled = true;
                        break;
                    default:
                        break;
                }

                if (currSense != null)
                {
                    currSense.LowThreshold = 0;
                    currSense.HighThreshold = 100;
                    Senses.AddSense(currSense);
                }
            }
        } 

        #endregion
    }
}

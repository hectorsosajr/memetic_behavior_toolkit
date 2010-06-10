using MemeLibrary;

namespace NpcLibrary
{
    public class Npc
    {
        #region Animal Base Definitions

        private const double HUNGER_RATE_CARNIVORE = 0.03;
        private const double HUNGER_RATE_HERBIVORE = 0.06;
        private const double HUNGER_RATE_OMNIVORE = 0.04;

        private const double TINY_CREATURE_MASS = 1.0;
        private const double SMALL_CREATURE_MASS = 8.0;
        private const double MEDIUM_CREATURE_MASS = 60.0;
        private const double LARGE_CREATURE_MASS = 500.0;
        private const double HUGE_CREATURE_MASS = 4000.0;

        private const double TINY_CREATURE_STARVE = 5.0;
        private const double SMALL_CREATURE_STARVE = 15.0;
        private const double MEDIUM_CREATURE_STARVE = 20.0;
        private const double LARGE_CREATURE_STARVE = 30.0;
        private const double HUGE_CREATURE_STARVE = 30.0;

        /// <summary>
        /// Will become exhausted when 75% of the way to starvation
        /// </summary>
        private const double EXHAUSTION_HUNGER_PERCENT = 0.75; 

        #endregion

        #region Member Variables

        /// <summary>The senses available to this thing.</summary>
        private readonly SenseManager _senseManager = new SenseManager();
 
        private readonly MemeManager _memeManager = new MemeManager();

        #endregion

        #region Constructors

        public Npc()
        {
            DietHabits = Diet.Herbivore;
            MassSize = BodyMass.Medium;

            SetNpcBaseSettings();
        }
 
        public Npc(Diet diet, BodyMass bodyMass)
        {
            DietHabits = diet;
            MassSize = bodyMass;

            SetNpcBaseSettings();
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

        public double Mass { get; private set; }

        public double HungerRate { get; set; }

        public double StarvationRate { get; set; }

        public BodyMass MassSize { get; set; }

        public Diet DietHabits { get; set; }

        public bool IsHungry { get; set; }

        public bool IsStarved { get; set; }

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

        private void SetNpcBaseSettings()
        {
            SetSize();
            SetHungerRate();
            SetStarvationRate();
            LoadSenses();
        }

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
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Hearing,
                                            MessagePrefix = "[HEARING]",
                                            Measurement = SensoryTypeMeasurement.Decibel,
                                            Enabled = true
                                        };
                        break;
                    case 2:
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Sight,
                                            MessagePrefix = "[SIGHT]",
                                            Measurement = SensoryTypeMeasurement.Lumen,
                                            Enabled = true
                                        };
                        break;
                    case 3:
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Smell,
                                            MessagePrefix = "[SMELL]",
                                            Measurement = SensoryTypeMeasurement.PartsPerMillion,
                                            Enabled = true
                                        };
                        break;
                    case 4:
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Touch,
                                            MessagePrefix = "[TOUCH]",
                                            Measurement = SensoryTypeMeasurement.PoundsPerSquareInch,
                                            Enabled = true
                                        };
                        break;
                    case 5:
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Taste,
                                            MessagePrefix = "[TASTE]",
                                            Measurement = SensoryTypeMeasurement.PartsPerMillion,
                                            Enabled = true
                                        };
                        break;
                    case 6:
                        currSense = new Sense
                                        {
                                            Name = SensoryType.Debug,
                                            MessagePrefix = "[DEBUG]",
                                            Measurement = SensoryTypeMeasurement.Debug,
                                            Enabled = true
                                        };
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
 
        private void SetSize()
        {
            switch (MassSize)
            {
                case BodyMass.Tiny:
                    Mass = TINY_CREATURE_MASS;
                    break;
                case BodyMass.Small:
                    Mass = SMALL_CREATURE_MASS;
                    break;
                case BodyMass.Medium:
                    Mass = MEDIUM_CREATURE_MASS;
                    break;
                case BodyMass.Large:
                    Mass = LARGE_CREATURE_MASS;
                    break;
                case BodyMass.Huge:
                    Mass = HUGE_CREATURE_MASS;
                    break;
            }
        }

        private void SetHungerRate()
        {
            switch (DietHabits)
            {
                case Diet.Herbivore:
                    HungerRate = HUNGER_RATE_HERBIVORE;
                    break;
                case Diet.Carnivore:
                    HungerRate = HUNGER_RATE_CARNIVORE;
                    break;
                case Diet.Omnivore:
                    HungerRate = HUNGER_RATE_OMNIVORE;
                    break;
            }
        }

        private void SetStarvationRate()
        {
            switch (MassSize)
            {
                case BodyMass.Tiny:
                    StarvationRate = TINY_CREATURE_STARVE;
                    break;
                case BodyMass.Small:
                    StarvationRate = SMALL_CREATURE_STARVE;
                    break;
                case BodyMass.Medium:
                    StarvationRate = MEDIUM_CREATURE_STARVE;
                    break;
                case BodyMass.Large:
                    StarvationRate = LARGE_CREATURE_STARVE;
                    break;
                case BodyMass.Huge:
                    StarvationRate = HUGE_CREATURE_STARVE;
                    break;
            }
        }

        #endregion
    }
}

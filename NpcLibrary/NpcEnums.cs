namespace NpcLibrary
{
    /// <summary>
    /// Sensory types.
    /// </summary>
    [System.Flags]
    public enum SensoryType
    {
        /// <summary>Lack of any sense.</summary>
        None = 0,

        /// <summary>Sight, you're using it to read this.</summary>
        Sight = 1,

        /// <summary>Hearing, the sense to hear by.</summary>
        Hearing = 2,

        /// <summary>Able to touch the world around, this would also be able to feel earthquakes, etc.</summary>
        Touch = 4,

        /// <summary>Able to taste.</summary>
        Taste = 8,

        /// <summary>Able to smell.</summary>
        Smell = 16,

        /// <summary>Able to see in the dark.</summary>
        NightVision = 32,

        /// <summary>Heat vision</summary>
        HeatVision = 64,

        /// <summary>Ultraviolet vision</summary>
        UltraViolet = 128,

        /// <summary>Magnified vision, to see small things or things before unseen to the naked eye.</summary>
        MagnifiedVision = 512,

        /// <summary>X-Ray vision</summary>
        XRay = 1024,

        /// <summary>A special Debug sense.</summary>
        Debug = 2048,

        /// <summary>All the senses.</summary>
        All = 4096,
    }

    /// <summary>
    /// Measurements used for specific senses.
    /// </summary>
    public enum SensoryTypeMeasurement
    {
        /// <summary>Used for debugging.</summary>
        Debug,

        /// <summary>How loud a sound is.</summary>
        Decibel,

        /// <summary>How bright something is.</summary>
        Lumen,

        /// <summary>
        /// Used for smell and taste. Both senses use the same
        /// measurement.
        /// </summary>
        PartsPerMillion,

        /// <summary>Provides tactile feedback to the touch sense.</summary>
        PoundsPerSquareInch
    }
}

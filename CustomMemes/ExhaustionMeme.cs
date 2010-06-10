using MemeLibrary;

namespace CustomMemes
{
    public class ExhaustionMeme : Meme
    {
        public new MemeEventHasFired OnMemeEventHasFired;

        #region Constructors

        public ExhaustionMeme()
        {
            Name = "Exhaustion Meme";
        }

        #endregion

        #region Public Members

        public override void Restart()
        {
            Priority = MemePriority.Medium;
            PriorityLevel = 50;
            Flags = MemeFlags.Instant;
        }

        public override void Stop()
        {
            Events.Clear();
        } 

        #endregion
    }
}

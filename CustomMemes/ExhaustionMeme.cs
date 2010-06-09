using MemeLibrary;

namespace CustomMemes
{
    public class ExhaustionMeme : Meme
    {
        public event MemeEventHasFired OnMemeEventHasFired;

        #region Constructors

        public ExhaustionMeme()
        {
            Name = "Exhaustion Meme";
        }

        #endregion

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
    }
}

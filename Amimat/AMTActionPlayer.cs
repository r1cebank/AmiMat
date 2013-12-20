using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Core;

namespace Amimat.Player
{
    public class AMTActionPlayer
    {
        private AMTAction Action;
        private Random RandomGenerator;
        private int CurrentFrame;
        private int LoopTimes;
        public AMTActionPlayer(AMTAction Act)
        {
            this.Action = Act;
            this.CurrentFrame = 0;
            this.LoopTimes = 0;
            this.RandomGenerator = new Random();
        }
        public void Reset()
        {
            CurrentFrame = 0;
        }
        public int GetCurrentFrame() { return this.CurrentFrame; }
        public AMTFrame GetNextFrame()
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                CurrentFrame = 0;
            if (CurrentFrame == Action.Frames.Count - 1)
                LoopTimes++;
            return Action.Frames[CurrentFrame++];
        }
        public AMTFrame GetNextFrameWithRandomness()
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                CurrentFrame = 0;
            if (CurrentFrame == Action.Frames.Count - 1)
                LoopTimes++;
            AMTFrame f = (AMTFrame)Action.Frames[CurrentFrame++].Clone();
            f.Delay = (int)((f.Randomness * RandomGenerator.NextDouble()) * f.Delay) + f.Delay;
            return f;
        }
        public int GetLoopTime() { return LoopTimes; }
    }
}

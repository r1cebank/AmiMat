using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amimat.Core;
using Amimat.Util;

namespace Amimat.Player
{
    public class AMTActionPlayer
    {
        private AMTPackage Package;
        private AMTAction Action;
        private Random RandomGenerator;
        private int CurrentFrame;
        private int LoopTimes;
        public AMTActionPlayer(AMTPackage Pak, AMTAction Act)
        {
            this.Package = Pak;
            this.Action = AMTUtil.ExpandFrame(Pak.Animation, Act);
            this.CurrentFrame = 0;
            this.LoopTimes = 0;
            this.RandomGenerator = new Random();
        }
        public void Reset()
        {
            CurrentFrame = 0;
        }
        public int GetCurrentFrame() 
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                return 0;
            else
                return CurrentFrame;
        }
        public KeyValuePair<AMTFrame, byte[]> GetNextFrame()
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                CurrentFrame = 0;
            if (CurrentFrame == Action.Frames.Count - 1)
                LoopTimes++;
            AMTFrame f = Action.Frames[CurrentFrame++];
            Package.SwitchResource(f.Resource);
            return new KeyValuePair<AMTFrame,byte[]>(f, Package.CurrentResource.Frames[f.FrameRef]);
        }
        public KeyValuePair<AMTFrame, byte[]> GetNextFrameWithRandomness()
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                CurrentFrame = 0;
            if (CurrentFrame == Action.Frames.Count - 1)
                LoopTimes++;
            AMTFrame f = (AMTFrame)Action.Frames[CurrentFrame++].Clone();
            f.Delay = (int)((f.Randomness * RandomGenerator.NextDouble()) * f.Delay) + f.Delay;
            Package.SwitchResource(f.Resource);
            return new KeyValuePair<AMTFrame, byte[]>(f, Package.CurrentResource.Frames[f.FrameRef]);
        }
        public int GetLoopTime() { return LoopTimes; }
    }
}

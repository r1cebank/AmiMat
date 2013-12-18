using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimat.Core
{
    public class AMTActionPlayer
    {
        private AMTAction Action;
        private int CurrentFrame;
        public AMTActionPlayer(AMTAction Act)
        {
            this.Action = Act;
            CurrentFrame = 0;
        }
        public void Reset()
        {
            CurrentFrame = 0;
        }
        public AMTFrame GetNextFrame()
        {
            if (CurrentFrame > Action.Frames.Count - 1)
                CurrentFrame = 0;
            return Action.Frames[CurrentFrame++];
        }
    }
}

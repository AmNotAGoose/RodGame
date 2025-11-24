using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osuTK;

namespace RodGame.Game.Gameplay
{
    public class GameClock : ManualFramedClock
    {
        public void Advance(double deltaMs)
        {
            CurrentTime += deltaMs;
            ProcessFrame();
        }

        public void SetTime(double timeMs)
        {
            CurrentTime = timeMs;
        }
    }
}

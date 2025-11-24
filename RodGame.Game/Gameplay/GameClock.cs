using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osuTK;

namespace RodGame.Game.Gameplay
{
    public class GameClock : ManualFramedClock
    {
        public double MaxTime = 3000;

        public BindableDouble BindableTime { get; set; } = new BindableDouble
        {
            MinValue = 0,
            MaxValue = 1,
            Value = 0
        };

        public void InitializeClock()
        {
            BindableTime.BindValueChanged(value =>
            {
                SetTime(MaxTime * value.NewValue);
            });
            IsRunning = true;
        }

        public void Advance(double deltaMs)
        {
            CurrentTime += deltaMs;
            BindableTime.Value = CurrentTime / MaxTime;
            ProcessFrame();  
        }

        public void SetTime(double timeMs)
        {
            CurrentTime = timeMs;
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osuTK;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class GameClock
    {
        public Track Song;
        public bool IsSeeking = false;

        public BindableDouble UIUpdateTime { get; set; } = new BindableDouble
        {
            MinValue = 0,
            MaxValue = 1,
            Value = 0
        };

        public void Load(Track song)
        {
            Song = song;
            Song.Looping = false;
            Song.Start();
        }

        public void Update()
        {
            if (IsSeeking) return;
            UIUpdateTime.Value = Song.CurrentTime / Song.Length;
        }

        public async void SetTime(double timeMs)
        {
            IsSeeking = true;
            await Song.SeekAsync(timeMs);
            UIUpdateTime.Value = timeMs / Song.Length;
            Song.Seek(timeMs);
            IsSeeking = false;
        }
    }
}



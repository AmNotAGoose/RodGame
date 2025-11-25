using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osuTK;

namespace RodGame.Game.Gameplay
{
    public partial class GameClock(string trackName) : Drawable
    {
        public string TrackName { get; } = trackName;

        public Track Song;
        public bool IsSeeking = false;

        public BindableDouble UIUpdateTime { get; set; } = new BindableDouble
        {
            MinValue = 0,
            MaxValue = 1,
            Value = 0
        };

        [BackgroundDependencyLoader]
        private void load(ITrackStore trackStore)
        {
            Song = trackStore.Get(TrackName);
            Song.Looping = false;
            Console.WriteLine(Song.Length.ToString());
            
            //UIUpdateTime.BindValueChanged(value =>
            //{
            //    SetTime(Song.Length * value.NewValue);
            //});

            Song.Start();
        }

        protected override void Update()
        {
            base.Update();
            if (IsSeeking) { IsSeeking = false; return; }
            UIUpdateTime.Value = Song.CurrentTime / Song.Length;
        }

        public void SetTime(double timeMs)
        {
            //GameplayClock.CurrentTime = timeMs;
            IsSeeking = true;
            Song.Seek(timeMs);
            UIUpdateTime.Value = timeMs / Song.Length;
        }
    }
}


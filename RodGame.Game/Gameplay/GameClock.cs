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
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class GameClock() : Drawable
    {
        private ChartModel chartModel;
        //public string TrackName { get; } = trackName;

        public Track Song;
        public bool IsSeeking = false;

        public BindableDouble UIUpdateTime { get; set; } = new BindableDouble
        {
            MinValue = 0,
            MaxValue = 1,
            Value = 0
        };

        public void Load(ITrackStore trackStore, ChartModel _chartModel)
        {
            chartModel = _chartModel;
            Song = trackStore.Get(chartModel.SongId);
            Song.Looping = false;
            Console.WriteLine(Song.Length.ToString());
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


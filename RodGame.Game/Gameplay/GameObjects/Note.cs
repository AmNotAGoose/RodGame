using System;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.Models;
using SharpGen.Runtime.Trimming;
using Veldrid;

namespace RodGame.Game.Gameplay.GameObjects
{
    public partial class Note : Sprite
    {
        public NoteModel Model;

        private Sample hitSound;

        public const double FADE_IN_TIME = 1000;
        public const double FADE_OUT_TIME = 200;
        public const double HIT_WINDOW = 50;

        [Resolved] private ChartSong gameSong { get; set; }

        private Rod parentRod;
        private bool hasBeenHit = false;


        [BackgroundDependencyLoader]
        private void load(IRenderer renderer, ISampleStore samples)
        {
            hitSound = samples.Get("hitsound.wav");
            Texture = renderer.WhitePixel;
            RelativeSizeAxes = Axes.None;
            RelativePositionAxes = Axes.None;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(50, 50);
            Colour = Color4.Black;
            AlwaysPresent = true;
        }

        public void SetParentRod(Rod rod)
        {
            parentRod = rod;
            Position = parentRod.GetRodPositionAsWorldSpaceAtTime(Model.StartTime, Model.StartPosition.X);
        }

        protected override void Update()
        {
            base.Update();

            double currentTime = gameSong.Song.CurrentTime;
            double timeDifference = currentTime - Model.StartTime;


            if (!hasBeenHit && Math.Abs(timeDifference) <= HIT_WINDOW)
            {
                hasBeenHit = true;
                hitSound?.Play();
            }

            if (hasBeenHit && timeDifference < -HIT_WINDOW)
            {
                hasBeenHit = false;
            }

            if (timeDifference < -FADE_IN_TIME)
            {
                Alpha = 0;
            }
            else if (timeDifference < 0)
            {
                Alpha = (float)((timeDifference + FADE_IN_TIME) / FADE_IN_TIME);
            }
            else if (timeDifference < FADE_OUT_TIME)
            {
                Alpha = (float)(1.0 - (timeDifference / FADE_OUT_TIME));
            }
            else
            {
                Alpha = 0;
            }
        }
    }
}

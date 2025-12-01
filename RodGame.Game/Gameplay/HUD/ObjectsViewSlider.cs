using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osu.Framework.Timing;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.GameObjects;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay.HUD
{
    public partial class ObjectVliewSlider: CompositeDrawable
    {
        [Resolved] private ChartSong gameSong { get; set; }
        private ChartModel GameChart { get; set; }

        public ObjectVliewSlider(ChartModel gameChart)
        {
            GameChart = gameChart;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            InternalChildren = new Drawable[]
            {
                new ClickableSliderBar<double>()
                {
                    OnSliderClick = setGameClockTime,
                    OnSliderDrag = setGameClockTime,
                    RelativeSizeAxes = Axes.Both,
                    RelativePositionAxes = Axes.Both,
                    Width = 0.95f,
                    Height = 0.1f,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Y = -0.05f,
                    Current = gameSong.UIUpdateTime
                },
            };
        }




        private void setGameClockTime()
        {
            gameSong.SetTime(timeSliderBar.Current.Value * gameSong.Song.Length);
            
        }
    }
}

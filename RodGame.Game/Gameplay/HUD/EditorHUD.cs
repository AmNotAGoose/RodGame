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
    public partial class EditorHUD: CompositeDrawable
    {
        [Resolved] private ChartSong gameSong { get; set; }

        private BasicSliderBar<double> timeSliderBar;
        private ChartModel GameChart { get; set; }

        public EditorHUD(ChartModel gameChart)
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
                timeSliderBar = new ClickableSliderBar<double>()
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
                //new BasicButton()
                //{
                //    RelativeSizeAxes = Axes.Both,
                //    RelativePositionAxes = Axes.Both,
                //    Width = 0.1f,
                //    Height = 0.1f,
                //    Anchor = Anchor.CentreLeft,
                //},
                //new BasicButton()
                //{
                //    RelativeSizeAxes = Axes.Both,
                //    RelativePositionAxes = Axes.Both,
                //    Width = 0.1f,
                //    Height = 0.1f,
                //    Anchor = Anchor.CentreLeft,
                //    Position = new Vector2(0, 0.5f),
                //}
            };
        }

        private void setGameClockTime()
        {
            gameSong.SetTime(timeSliderBar.Current.Value * gameSong.Song.Length);
            
        }
    }
}

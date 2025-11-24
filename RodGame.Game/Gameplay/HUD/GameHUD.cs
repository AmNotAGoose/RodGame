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
    public partial class GameHUD: CompositeDrawable
    {
        [Resolved]
        private GameClock gameClock { get; set; } = new();

        private BasicSliderBar<double> timeSliderBar;
        

        [BackgroundDependencyLoader]
        private void load()
        {

            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            InternalChildren = new Drawable[]
            {
                timeSliderBar = new BasicSliderBar<double>()
                {
                    Width = 100,
                    Height = 50,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Current = new BindableDouble
                    {
                        MinValue = 0f,
                        MaxValue = 100f,
                        Value = 50f
                    }
                }
            };

            //timeSliderBar.Current.BindValueChanged(value => gameClock.SetTime(value.NewValue));

            timeSliderBar.Current.BindValueChanged(value =>
            {
                Console.WriteLine(value.NewValue);
            });
        }

    }
}

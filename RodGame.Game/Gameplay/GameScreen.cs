using System;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
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
using RodGame.Game.Gameplay.HUD;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class GameScreen: Screen
    {
        private Container gameplayContainer = new()
        {
            RelativeSizeAxes = Axes.Both,   
        };
        private Container dynamicBackgroundContainer = new()
        {
            RelativeSizeAxes = Axes.Both,
        };
        private Container stationaryBackgroundContainer = new()
        {
            RelativeSizeAxes = Axes.Both,
        };
        private Container hudBackgroundContainer = new()
        {
            RelativeSizeAxes = Axes.Both,
        };

        private CameraManager cameraManager;
        private GameHUD gameHUD = new();

        [Cached]
        private GameClock gameClock { get; } = new();

        [BackgroundDependencyLoader]
        private void load()
        {
            stationaryBackgroundContainer.Add(
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                }
            );

            gameplayContainer.AddRange(new Drawable[]
            {
                new Rod
                {
                    Model = new RodModel
                    {
                        StartRotationSpeed = 1,
                    },
                },
                new Rod
                {
                    Model = new RodModel
                    {
                        StartPosition = new Vector2 (100, 100),
                        StartRotationSpeed = 1,
                    },
                },
                new Note
                {
                    Model = new NoteModel
                    {
                        StartPosition = new Vector2 (100, 100)
                    },
                }
            });

            dynamicBackgroundContainer.Add(new Box()
            {
                Colour = Color4.Aquamarine,
                Size = new Vector2(10, 10),
                RelativeSizeAxes = Axes.None,
                RelativePositionAxes = Axes.None,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2 (-10, 10),
            });

            hudBackgroundContainer.Add(gameHUD);

            InternalChildren = new Drawable[]
            {
                stationaryBackgroundContainer,
                dynamicBackgroundContainer,
                gameplayContainer,
                hudBackgroundContainer
            };

            cameraManager = new(stationaryBackgroundContainer, dynamicBackgroundContainer, gameplayContainer);

            cameraManager.MoveCamTo(new Vector2(300, 300), 3000, Easing.None);
            gameClock.InitializeClock();
        }

        protected override void Update()
        {
            base.Update();

            if (gameClock.IsRunning) gameClock.Advance(Time.Elapsed);
        }
    }
}

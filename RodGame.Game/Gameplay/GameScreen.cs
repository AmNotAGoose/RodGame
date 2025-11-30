using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;
using RodGame.Game.Gameplay.GameObjects;
using RodGame.Game.Gameplay.HUD;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class GameScreen: Screen
    {
        private MapStore mapStore;
        private EditorHUD gameHUD = new();
        private CameraManager cameraManager;

        private ChartModel chartModel;

        private Container gameplayContainer = new() { RelativeSizeAxes = Axes.Both };
        private Container dynamicBackgroundContainer = new() { RelativeSizeAxes = Axes.Both };
        private Container stationaryBackgroundContainer = new() { RelativeSizeAxes = Axes.Both };
        private Container hudBackgroundContainer = new() { RelativeSizeAxes = Axes.Both };

        [Cached]
        private GameClock gameClock { get; set; } = new();

        [BackgroundDependencyLoader]
        private void load(ITrackStore trackStore)
        {

            var mapStore = new NamespacedResourceStore<byte[]>(Game.Resources, "Maps");
            mapStore.AddExtension("json");
            byte[] jsonBytes = mapStore.Get("map");

            foreach (var item in mapStore.GetAvailableResources())
            {
                Console.WriteLine(item);
            }

            chartModel = new ChartModel(jsonBytes);

            Track song = trackStore.Get(chartModel.SongId);
            gameClock.Load(song);

            stationaryBackgroundContainer.Add(
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                }
            );

            foreach (var rodModel in chartModel.RodModels)
            {
                var rodDrawable = new Rod
                {
                    Model = rodModel
                };

                rodDrawable.Notes = new List<Note>();
                foreach (var noteModel in rodModel.NoteModels)
                {
                    var noteDrawable = new Note
                    {
                        Model = noteModel
                    };
                    rodDrawable.Notes.Add(noteDrawable);

                    gameplayContainer.Add(noteDrawable);
                }

                gameplayContainer.Add(rodDrawable);
            }

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
        }

        protected override void Update()
        {
            base.Update();
            gameClock.Update();
        }
    }
}

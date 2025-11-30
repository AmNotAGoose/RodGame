//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using osu.Framework.Allocation;
//using osu.Framework.Audio.Track;
//using osu.Framework.Graphics;
//using osu.Framework.Graphics.Containers;
//using osu.Framework.Graphics.Shapes;
//using osu.Framework.IO.Stores;
//using osu.Framework.Screens;
//using osuTK;
//using osuTK.Graphics;
//using RodGame.Game.Gameplay.GameObjects;
//using RodGame.Game.Gameplay.HUD;
//using RodGame.Game.Gameplay.Models;

//namespace RodGame.Game.Gameplay
//{
//    public partial class Editor: Screen
//    {
//        private Container gameplayContainer = new()
//        {
//            RelativeSizeAxes = Axes.Both,   
//        };
//        private Container dynamicBackgroundContainer = new()
//        {
//            RelativeSizeAxes = Axes.Both,
//        };
//        private Container stationaryBackgroundContainer = new()
//        {
//            RelativeSizeAxes = Axes.Both,
//        };
//        private Container hudBackgroundContainer = new()
//        {
//            RelativeSizeAxes = Axes.Both,
//        };

//        private CameraManager cameraManager;
//        private EditorHUD gameHUD = new();

//        private ChartModel chartModel;

//        [Cached]
//        private GameClock gameClock { get; set; } = new();

//        [BackgroundDependencyLoader]
//        private void load(ITrackStore trackStore)
//        {
//            var mapStore = new NamespacedResourceStore<byte[]>(Game.Resources, "Maps");
//            mapStore.AddExtension("json");
//            byte[] jsonBytes = mapStore.Get("map");

//            chartModel = new ChartModel(jsonBytes);
//            gameClock.Load(trackStore, chartModel);

//            stationaryBackgroundContainer.Add(
//                new Box
//                {
//                    Colour = Color4.Violet,
//                    RelativeSizeAxes = Axes.Both,
//                }
//            );

//            foreach (var rodModel in chartModel.RodModels)
//            {
//                var rodDrawable = new Rod
//                {
//                    Model = rodModel
//                };

//                rodDrawable.Notes = new List<Note>();
//                foreach (var noteModel in rodModel.NoteModels)
//                {
//                    var noteDrawable = new Note
//                    {
//                        Model = noteModel
//                    };
//                    rodDrawable.Notes.Add(noteDrawable);

//                    gameplayContainer.Add(noteDrawable);
//                }

//                gameplayContainer.Add(rodDrawable);
//            }

//            dynamicBackgroundContainer.Add(new Box()
//            {
//                Colour = Color4.Aquamarine,
//                Size = new Vector2(10, 10),
//                RelativeSizeAxes = Axes.None,
//                RelativePositionAxes = Axes.None,
//                Anchor = Anchor.Centre,
//                Origin = Anchor.Centre,
//                Position = new Vector2 (-10, 10),
//            });

//            hudBackgroundContainer.Add(gameHUD);
//            hudBackgroundContainer.Add(gameClock);

//            InternalChildren = new Drawable[]
//            {
//                stationaryBackgroundContainer,
//                dynamicBackgroundContainer,
//                gameplayContainer,
//                hudBackgroundContainer
//            };

//            cameraManager = new(stationaryBackgroundContainer, dynamicBackgroundContainer, gameplayContainer);

//            cameraManager.MoveCamTo(new Vector2(300, 300), 3000, Easing.None);
//        }
//    }
//}

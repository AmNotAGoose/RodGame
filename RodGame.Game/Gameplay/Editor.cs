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
    public partial class Editor : GameScreen
    {
        private EditorHUD gameHUD = new();

        [Cached]
        private ChartSong gameClock { get; set; } = new();

        [BackgroundDependencyLoader]
        private void load(ITrackStore trackStore)
        {
            var mapStore = new NamespacedResourceStore<byte[]>(Game.Resources, "Maps");
            mapStore.AddExtension("json");
            byte[] jsonBytes = mapStore.Get("map");

            foreach (var item in mapStore.GetAvailableResources())
            {
                Console.WriteLine(item);
                new ChartManager(Game.Resources, Model, item);
            }

            Model = new ChartModel(jsonBytes);

            Track song = trackStore.Get(Model.SongId);
            gameClock.Load(song);


            StationaryBackgroundContainer.Add(
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                }
            );

            foreach (var rodModel in Model.RodModels)
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

                    GameplayContainer.Add(noteDrawable);
                }

                GameplayContainer.Add(rodDrawable);
            }

            DynamicBackgroundContainer.Add(new Box()
            {
                Colour = Color4.Aquamarine,
                Size = new Vector2(10, 10),
                RelativeSizeAxes = Axes.None,
                RelativePositionAxes = Axes.None,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(-10, 10),
            });

            HudBackgroundContainer.Add(gameHUD);

            InternalChildren = new Drawable[]
            {
                StationaryBackgroundContainer,
                DynamicBackgroundContainer,
                GameplayContainer,
                HudBackgroundContainer
            };

            GameCamera = new(StationaryBackgroundContainer, DynamicBackgroundContainer, GameplayContainer);
        }

        protected override void Update()
        {
            base.Update();
            gameClock.Update();

        }
    }
}

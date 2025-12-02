using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
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
        protected string MapJsonPath;

        protected ChartManager GameChartManager;
        protected Camera GameCamera;

        protected NamespacedResourceStore<byte[]> MapResourceStore { get; set; }
        protected ITrackStore MapResourceTrackStore { get; set; }
        protected ITextureStore MapResourceTextureStore { get; set; }

        protected Container GameplayContainer { get; set; } = new() { RelativeSizeAxes = Axes.Both };
        protected Container DynamicBackgroundContainer { get; set; } = new() { RelativeSizeAxes = Axes.Both };
        protected Container StationaryBackgroundContainer { get; set; } = new() { RelativeSizeAxes = Axes.Both };
        protected Container HudBackgroundContainer { get; set; } = new() { RelativeSizeAxes = Axes.Both };

        [Cached] private ChartSong gameSong { get; set; } = new();
        protected ChartModel GameChart { get; set; }

        public GameScreen(string mapJsonPath)
        {
            MapJsonPath = mapJsonPath;
        }

        protected void Load(AudioManager audio, IRenderer renderer)
        {
            // TODO: seperate ts loading somwehre else
            string mapDirectory = string.Join("", MapJsonPath.Split('/')[..^1]);
            MapResourceStore = new(Game.Resources, "Maps/" + mapDirectory);
            MapResourceStore.AddExtension("json");
            MapResourceStore.AddExtension("mp3");
            MapResourceStore.AddExtension("png");
            MapResourceStore.AddExtension("jpg");
            MapResourceTrackStore = audio.GetTrackStore(MapResourceStore);
            MapResourceTextureStore = new TextureStore(renderer, new TextureLoaderStore(MapResourceStore), scaleAdjust: 1);

            string songName = MapResourceStore.GetAvailableResources().Where(name => name.EndsWith(".mp3")).First();
            Track track = MapResourceTrackStore.Get(songName);
            gameSong.Load(track);

            string chartName = MapResourceStore.GetAvailableResources().Where(name => name.EndsWith(".json")).First();
            Console.WriteLine(chartName);
            ChartModel chartModel = new(MapResourceStore.Get(chartName));
            GameChart = chartModel;

            // TODO: implement the actual system latr

            string stationaryBackgroundName = MapResourceStore.GetAvailableResources().Where(name => name.StartsWith("stationary")).First();
            Texture stationaryBackgroundTexture = MapResourceTextureStore.Get(stationaryBackgroundName);

            string dynamicBackgroundName = MapResourceStore.GetAvailableResources().Where(name => name.StartsWith("dynamic")).First();
            Texture dynamicBackgroundTexture = MapResourceTextureStore.Get(dynamicBackgroundName);


            StationaryBackgroundContainer.Add(
                new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = stationaryBackgroundTexture,
                    FillMode = FillMode.Fill,
                }
            );

            foreach (var rodModel in GameChart.RodModels)
            {
                var rodDrawable = new Rod
                {
                    Model = rodModel,
                };

                rodDrawable.Initialize();

                foreach (var noteModel in rodModel.NoteModels)
                {
                    var noteDrawable = new Note
                    {
                        Model = noteModel
                    };
                    rodDrawable.AddNote(noteDrawable);

                    GameplayContainer.Add(noteDrawable);
                }

                GameplayContainer.Add(rodDrawable);
            }

            DynamicBackgroundContainer.Add(new Sprite()
            {
                Texture = dynamicBackgroundTexture,
                Size = new Vector2(1, 1),
                RelativeSizeAxes = Axes.Both,
                RelativePositionAxes = Axes.None,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(-10, 10),
                FillMode = FillMode.Fill
            });

            InternalChildren = new Drawable[]
            {
                StationaryBackgroundContainer,
                DynamicBackgroundContainer,
                GameplayContainer,
                HudBackgroundContainer
            };

            GameCamera = new(StationaryBackgroundContainer, DynamicBackgroundContainer, GameplayContainer);

            GameCamera.MoveCamTo(new Vector2(-100, -100), 3000, Easing.InExpo);
        }

        protected override void Update()
        {
            base.Update();
            gameSong.Update();
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Key == Key.Space)
            {
                gameSong.TogglePause();
            }

            return base.OnKeyDown(e);
        }
    }
}

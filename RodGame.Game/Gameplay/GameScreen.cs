using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Audio;
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
        protected string MapJsonPath;

        protected ChartManager GameChartManager;
        protected Camera GameCamera;

        protected NamespacedResourceStore<byte[]> MapResourceStore { get; set; }
        protected ITrackStore MapResourceTrackStore { get; set; }

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

        protected void Load(AudioManager audio)
        {
            // TODO: seperate ts loading somwehre else
            string mapDirectory = string.Join("", MapJsonPath.Split('/')[..^1]);
            MapResourceStore = new(Game.Resources, "Maps/" + mapDirectory);
            MapResourceStore.AddExtension("json");
            MapResourceStore.AddExtension("mp3");
            MapResourceTrackStore = audio.GetTrackStore(MapResourceStore);

            string songName = MapResourceStore.GetAvailableResources().Where(name => name.EndsWith(".mp3")).First();
            Track track = MapResourceTrackStore.Get(songName);
            gameSong.Load(track);

            string chartName = MapResourceStore.GetAvailableResources().Where(name => name.EndsWith(".json")).First();
            Console.WriteLine(chartName);
            ChartModel chartModel = new(MapResourceStore.Get(chartName));
            GameChart = chartModel;

            StationaryBackgroundContainer.Add(
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                }
            );

            foreach (var rodModel in GameChart.RodModels)
            {
                var rodDrawable = new Rod
                {
                    Model = rodModel,
                    Notes = new List<Note>()
                };

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
            gameSong.Update();
        }
    }
}

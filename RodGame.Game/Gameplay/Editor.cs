using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Rendering;
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
        private EditorHUD gameHUD;

        public Editor(string mapJsonPath) : base(mapJsonPath)
        {
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio, IRenderer renderer)
        {
            base.Load(audio, renderer);

            gameHUD = new(GameChart);

            HudBackgroundContainer.Add(gameHUD);
        }
    }
}

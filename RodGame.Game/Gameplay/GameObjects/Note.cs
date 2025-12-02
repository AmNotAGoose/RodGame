using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay.GameObjects
{
    public partial class Note : Sprite
    {
        public NoteModel Model;

        private Vector2 currentPosition;
        [Resolved] private ChartSong gameSong { get; set; }

        private Rod parentRod;


        [BackgroundDependencyLoader]
        private void load(IRenderer renderer)
        {
            Texture = renderer.WhitePixel;
            RelativeSizeAxes = Axes.None;
            RelativePositionAxes = Axes.None;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(50, 50);
            Colour = Color4.Black;
        }

        public void SetParentRod(Rod rod)
        {
            parentRod = rod;
            Console.WriteLine("asdf");
            Position = parentRod.GetRodPositionAsWorldSpaceAtTime(Model.StartTime, Model.StartPosition.X);
        }
    }
}

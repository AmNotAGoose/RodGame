using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Rendering;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osu.Framework.Timing;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay.GameObjects
{
    public partial class Rod : Sprite
    {
        public RodModel Model;

        [Resolved]
        private GameClock gameClock { get; set; }

        private Vector2 currentPosition = Vector2.Zero;
        private double currentRotation = 0d;
        private double currentRotationSpeed = 0d;

        public List<Note> Notes;

        [BackgroundDependencyLoader]
        private void load(IRenderer renderer)
        {
            currentPosition = Model.StartPosition;
            currentRotationSpeed = Model.StartRotationSpeed;
            Position = currentPosition;

            Texture = renderer.WhitePixel;
            RelativeSizeAxes = Axes.None;
            RelativePositionAxes = Axes.None;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(10000, 10);
            Colour = Color4.Black;
        }

        protected override void Update()
        {
            // Rotation
            Rotation = (float)gameClock.Song.CurrentTime * (float)currentRotationSpeed;
        }
    }
 }

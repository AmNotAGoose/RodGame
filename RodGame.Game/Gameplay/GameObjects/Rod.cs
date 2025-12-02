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

        [Resolved] private ChartSong gameSong { get; set; }

        private Vector2 currentPosition = Vector2.Zero;
        private double currentRotationSpeed = 0d;

        private List<Note> notes = new();

        [BackgroundDependencyLoader]
        private void load(IRenderer renderer) // NOTE: WARNING THIS HAPPENS AFTER A LOT OF STUFF THATS PROBABLY WHY THINGS ARE DEFAULT VALUE/  BROKENB
        {
            Texture = renderer.WhitePixel;
            RelativeSizeAxes = Axes.None;
            RelativePositionAxes = Axes.None;
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(10000, 10);
            Colour = Color4.Black;
        }

        public void Initialize()
        {
            currentPosition = Model.StartPosition;
            currentRotationSpeed = Model.StartRotationSpeed;

            Position = currentPosition;
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
            note.SetParentRod(this);
        }

        public Vector2 GetRodPositionAsWorldSpaceAtTime(double timeMs, double distanceFromRodOrigin)
        {
            double rotationAtTime = GetRotationAtTime(timeMs);
            double rotationRadians = rotationAtTime * (Math.PI / 180.0);

            Vector2 offset = new Vector2(
                (float)(Math.Cos(rotationRadians) * distanceFromRodOrigin),
                (float)(Math.Sin(rotationRadians) * distanceFromRodOrigin)
            );

            return currentPosition + offset;
        }

        protected override void Update()
        {
            Rotation = Model.StartRotation + (float)gameSong.Song.CurrentTime * (float)currentRotationSpeed;
        }

        public double GetRotationAtTime(double timeMs)
        {
            return Model.StartRotation + (float)timeMs * (float)GetRotationSpeedAtTime(timeMs);
        }

        public double GetRotationSpeedAtTime(double timeMs)
        {
            // eventually this will have adittional logic when theres actually different note types which impact the rod
            return currentRotationSpeed;
        }
    }
 }

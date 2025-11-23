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

        private Vector2 currentPosition = Vector2.Zero;

        [BackgroundDependencyLoader]
        private void load(IRenderer renderer)
        {
            currentPosition = Model.StartingPosition;
                
            Texture = renderer.WhitePixel;
            
            Size = new Vector2(100, 100);
            Colour = Color4.Black;
            Position = currentPosition;
        }
    }
}

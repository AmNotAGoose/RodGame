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

namespace RodGame.Game
{
    public partial class Rod : Sprite
    {



        [BackgroundDependencyLoader]
        private void load(IRenderer renderer)
        {
            Texture = renderer.WhitePixel;
            
            Size = new Vector2(10000, 10);
            Colour = Color4.Black;
        }

        public void Rotate()
        {
            Rotation = (float)Time.Current * 0.1f;
        }

        protected override void Update()
        {
            Rotate();
        }
    }    
 }

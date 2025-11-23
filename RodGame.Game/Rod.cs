using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace RodGame.Game
{
    public partial class Rod: Box
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Width = 100;
            Height = 100;
            Colour = Color4.AliceBlue;
        }

        public void Rotate()
        {
            Rotation += 10;
        }
    }
}

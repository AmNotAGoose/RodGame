using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace RodGame.Game
{
    public partial class GameButton : CompositeDrawable
    {
        private BasicButton Button;

        [BackgroundDependencyLoader]
        private void load()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Button = new BasicButton
            {
                Width = 200,
                Height = 50,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                BackgroundColour = Color4.DarkGray,
                Text = "Game Button",
            }; 
            InternalChild = Button;
        }
    }
}

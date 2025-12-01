using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace RodGame.Game
{
    public partial class MenuScreen: Screen
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                },
                new BasicButton
                {
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.None,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Position = new Vector2(0, 0),
                    Size = new Vector2(300f, 300f),
                    Text = "Rod Game; i cant think of a name :("
                },
            };
        }


    }
}

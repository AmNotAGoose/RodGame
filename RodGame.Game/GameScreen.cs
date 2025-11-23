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
    public partial class GameScreen: Screen
    {
        private Rod rod;

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
                rod = new Rod
                {
                    RelativeSizeAxes = Axes.None,
                    RelativePositionAxes = Axes.None,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                },
                new Rod
                {
                    RelativeSizeAxes = Axes.None,
                    RelativePositionAxes = Axes.None,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Position = new Vector2(100, 100),
                }
            };
        }
    }
}

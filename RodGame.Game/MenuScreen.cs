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
                new SpriteText
                {
                    Width = 400,
                    Height = 50,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "diddy blud",
                },
                new GameButton
                {
                    Width = 300,
                    Height = 10,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "Start Game",
                },
            };
        }


    }
}

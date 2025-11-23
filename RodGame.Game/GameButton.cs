using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Localisation;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace RodGame.Game
{
    public partial class GameButton : BasicButton
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            var background = new NineSliceSprite()
            {
                Texture = textures.Get("ui/menubutton"),
                TextureInset = new MarginPadding(10),
                RelativeSizeAxes = Axes.Both,
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
            };

            InternalChildren = new Drawable[]
            {
                background
            };

        }
    }
}


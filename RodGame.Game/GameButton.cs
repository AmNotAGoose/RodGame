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
    public partial class GameButton : CompositeDrawable
    {
        private BasicButton Button = new(); 
        public LocalisableString Text
        {
            get => Button.Text;
            set => Button.Text = value;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Size = new osuTK.Vector2(200, 60);

            var background = new NineSliceSprite()
            {
                Texture = textures.Get("ui/menubutton"),
                TextureInset = new MarginPadding(10),
                RelativeSizeAxes = Axes.Both
            };

            InternalChildren = new Drawable[]
            {
                background,
                Button,
            };
        }
    }
}

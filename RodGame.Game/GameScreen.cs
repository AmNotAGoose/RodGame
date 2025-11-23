using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.GameObjects;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game
{
    public partial class GameScreen: Screen
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
                new Rod
                {
                    Model = new RodModel(),
                },
                new Rod
                {                    
                    Model = new RodModel
                    {
                        StartPosition = new Vector2 (100, 100)
                    },
                },
                new Note
                {
                    Model = new NoteModel
                    {
                        StartPosition = new Vector2 (100, 100)
                    },
                }
            };
        }
    }
}

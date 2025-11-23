using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
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
        private Container gameplayContainer = new()
        {
            RelativeSizeAxes = Axes.Both,
        };

        [BackgroundDependencyLoader]
        private void load()
        {
            gameplayContainer.AddRange(new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                },
                new Rod
                {
                    Model = new RodModel
                    {
                        StartRotationSpeed = 1,
                    },
                },
                new Rod
                {
                    Model = new RodModel
                    {
                        StartPosition = new Vector2 (100, 100),
                        StartRotationSpeed = 1,
                    },
                },
                new Note
                {
                    Model = new NoteModel
                    {
                        StartPosition = new Vector2 (100, 100)
                    },
                }
            });

            InternalChild = gameplayContainer;

            gameplayContainer.MoveTo(new Vector2 (300, 300), 3000, Easing.Out);

        }
    }
}

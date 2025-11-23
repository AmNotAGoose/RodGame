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
    public partial class Rod : Box
    {
        [BackgroundDependencyLoader]
        private void load()
        {
        }

        public void Rotate()
        {
            Rotation += 0.5f;
        }
        protected override void Update()
        {
            base.Update();
            Rotate();
        }
    }

    
 }

using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using RodGame.Game.Gameplay;

namespace RodGame.Game
{
    public partial class RodGameGame : RodGameGameBase
    {
        private MapStore mapStore;
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(@"RodGame.Resources.dll"));
            
            mapStore = new(Resources);
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            //screenStack.Push(new Editor(mapStore.GetAvailableMapIDs().First()));
            screenStack.Push(new MenuScreen());
        }
    }
}

using osu.Framework.iOS;
using RodGame.Game;

namespace RodGame.iOS
{
    /// <inheritdoc />
    public class AppDelegate : GameApplicationDelegate
    {
        /// <inheritdoc />
        protected override osu.Framework.Game CreateGame() => new RodGameGame();
    }
}

using osu.Framework.Platform;
using osu.Framework;
using RodGame.Game;

namespace RodGame.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"RodGame"))
            using (osu.Framework.Game game = new RodGameGame())
                host.Run(game);
        }
    }
}

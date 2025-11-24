using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osuTK;

namespace RodGame.Game.Gameplay
{
    public class GameplayManager(
        Container _stationaryBackgroundContainer,
        Container _dynamicBackgroundContainer,
        Container _gameplayContainer)
    {
        private Container stationaryBackgroundContainer = _stationaryBackgroundContainer;
        private Container dynamicBackgroundContainer = _dynamicBackgroundContainer;
        private Container gameplayContainer = _gameplayContainer;

        public ManualClock GameClock;

        public void StartGame()
        {
            GameClock.IsRunning = false;
            GameClock.CurrentTime = 0;
            GameClock.IsRunning = true;
        }

        public void TogglePauseGame()
        {
            GameClock.IsRunning = !GameClock.IsRunning;
        }
    }
}

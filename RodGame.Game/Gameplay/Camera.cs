using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace RodGame.Game.Gameplay
{
    public class Camera(
        Container _stationaryBackgroundContainer,
        Container _dynamicBackgroundContainer,
        Container _gameplayContainer)
    {
        private Container stationaryBackgroundContainer = _stationaryBackgroundContainer;
        private Container dynamicBackgroundContainer = _dynamicBackgroundContainer;
        private Container gameplayContainer = _gameplayContainer;

        public void MoveCamTo(Vector2 position, int timeMs, Easing easing)
        {
            dynamicBackgroundContainer.MoveTo(position, timeMs, easing);
            gameplayContainer.MoveTo(position, timeMs, easing);
        }


    }
}

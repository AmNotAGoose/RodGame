using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.IO.Stores;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public class Chart
    {
        public ChartModel Model;

        private IResourceStore<byte[]> resources;

        public Chart(IResourceStore _resources, string chartId)
        {
            resources = _resources;

            Model = new ChartModel(resources.Get(chartId));
            
        }
    }
}

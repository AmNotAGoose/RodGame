using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.IO.Stores;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public class ChartManager
    {
        private NamespacedResourceStore<byte[]> curMapResourceStore;
        private ChartModel chartModel;

        public ChartManager(IResourceStore<byte[]> store, ChartModel model, string mapJsonPath)
        {
            chartModel = model;
            string mapDirectory = string.Join("", mapJsonPath.Split('/')[..^1]);
            curMapResourceStore = new(store, "Maps/" + mapDirectory);
        }
    }
}

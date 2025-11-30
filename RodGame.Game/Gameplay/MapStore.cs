using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using RodGame.Game.Gameplay.GameObjects;
using RodGame.Game.Gameplay.HUD;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class MapStore
    {
        private NamespacedResourceStore<byte[]> mapsResourceStore;

        public MapStore(IResourceStore<byte[]> store)
        {
            mapsResourceStore = new(store, "Maps");
            mapsResourceStore.AddExtension("json");
        }

        public IEnumerable<string> GetAvailableMapIDs()
        {
            var _maps = mapsResourceStore.GetAvailableResources();
            return _maps;
            // in the future theres gonna be some check here to see if its actually a valid map but idgaf rn
        }

        public ChartModel GetMap(string mapID)
        {
            return new ChartModel(mapsResourceStore.Get(mapID));
        }
    }
}

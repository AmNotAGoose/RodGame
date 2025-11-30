using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.IO.Stores;
using osuTK.Graphics.OpenGL;
using RodGame.Game.Gameplay.Models;

namespace RodGame.Game.Gameplay
{
    public partial class ChartManager : Drawable
    {
        [Resolved] protected NamespacedResourceStore<byte[]> MapResourceStore { get; set; }

        [Resolved] protected Container GameplayContainer { get; set; }
        [Resolved] protected Container DynamicBackgroundContainer { get; set; }
        [Resolved] protected Container StationaryBackgroundContainer { get; set; }
        [Resolved] protected Container HudBackgroundContainer { get; set; }

        [Resolved] protected ChartSong GameSong { get; set; }
        [Resolved] protected ChartModel GameChart { get; set; }

        public ChartManager(IResourceStore<byte[]> store, string mapJsonPath)
        {
            string mapDirectory = string.Join("", mapJsonPath.Split('/')[..^1]);
            MapResourceStore = new(store, "Maps/" + mapDirectory);
        }

        
    }
}

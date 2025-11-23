using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace RodGame.Game
{
    public enum RodEventNames
    {
        ChangeSpeed,
        Destroy,
    }

    public class RodEventModel
    {
        public RodEventNames EventName;
        public double StartTime;
        public List<int> Data;
    }
}

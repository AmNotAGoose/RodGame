using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace RodGame.Game.Gameplay.Models
{
    public enum NoteEventNames
    {
        ChangeSpeed,
        Destroy,
    }

    public class NoteEventModel
    {
        public NoteEventNames EventName;
        public double StartTime;
        public List<int> Data;
    }
}

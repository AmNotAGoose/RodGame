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
        Reverse,
        Anchor, // sets new origin
    }

    public class NoteEventModel : GameObjectEventModel
    {
        public NoteEventNames EventName;
    }
}

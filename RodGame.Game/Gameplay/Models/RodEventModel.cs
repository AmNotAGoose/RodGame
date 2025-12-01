using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace RodGame.Game.Gameplay.Models
{
    public enum RodEventNames
    {
        Destroy,
    }

    public class RodEventModel : GameObjectEventModel // these should NEVER IMPACT THE POSITIONING / ROTATION OF THE ROD THAT STUFF BELONGS IN NoteEventModel
    {
        public RodEventNames EventName;
    }
}

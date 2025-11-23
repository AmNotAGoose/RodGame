using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace RodGame.Game.Gameplay.Models
{
    public class RodModel
    {
        public List<RodEventModel> Events;

        public float CurrentRotationSpeed;
    }
}

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace RodGame.Game.Gameplay.Models
{
    public class RodModel : GameObjectModel
    {
        public List<RodEventModel> Events;
        public List<NoteModel> NoteModels = new();

        public float StartRotationSpeed;
        public float StartRotation;
    }
}

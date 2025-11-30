using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;

namespace RodGame.Game.Gameplay
{
    public partial class ClickableSliderBar<T> : BasicSliderBar<double> where T : struct, INumber<T>, IMinMaxValue<T>
    {
        public Action OnSliderClick;
        public Action OnSliderDrag;

        protected override void OnDrag(DragEvent e)
        {
            OnSliderDrag?.Invoke();
            base.OnDrag(e);
        }

        protected override bool OnClick(ClickEvent e)
        {
            OnSliderClick?.Invoke();
            return base.OnClick(e);
        }
    }
}

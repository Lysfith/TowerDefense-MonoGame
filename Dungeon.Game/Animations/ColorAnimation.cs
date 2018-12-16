using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public class ColorAnimation : Animation
    {
        private Color _colorStart;
        private Color _colorEnd;

        public ColorAnimation(Color colorStart, Color colorEnd)
        {
            _colorStart = colorStart;
            _colorEnd = colorEnd;
        }

        public override void Update(GameTime gameTime)
        {
            if(_startTime > 0)
            {
                _time -= gameTime.ElapsedGameTime.TotalSeconds;
            }

            var percent = (float)(1.0 - (_time / _startTime));

            var r = (int)(_colorStart.R + (_colorEnd.R - _colorStart.R) * percent);
            var g = (int)(_colorStart.G + (_colorEnd.G - _colorStart.G) * percent);
            var b = (int)(_colorStart.B + (_colorEnd.B - _colorStart.B) * percent);
            var a = (int)(_colorStart.A + (_colorEnd.A - _colorStart.A) * percent);

            _actor.SetColor(new Color(r, g, b, a));
        }
    }
}

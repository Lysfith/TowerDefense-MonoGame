using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public enum MoveAnimationType
    {
        DIRECTION,
        TWO_POINTS
    }
    public class MoveAnimation : Animation
    {
        private Vector2 _direction;
        private Vector2 _start;
        private Vector2 _end;
        private MoveAnimationType _type;
        private Func<float, float, Vector2> _function;

        public MoveAnimation(Vector2 direction, Func<float, float, Vector2> function = null)
        {
            _direction = direction;
            _function = function;
            _type = MoveAnimationType.DIRECTION;
        }

        public MoveAnimation(Vector2 start, Vector2 end)
        {
            _start = start;
            _end = end;
            _type = MoveAnimationType.TWO_POINTS;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            var speed = gameTime.ElapsedGameTime.TotalSeconds * _actor.Speed;

            float x = 0;
            float y = 0;

            if (_type == MoveAnimationType.DIRECTION)
            {
                x = (float)(_actor.X + _direction.X * speed);
                y = (float)(_actor.Y + _direction.Y * speed);
            }
            else if (_type == MoveAnimationType.TWO_POINTS)
            {
                if((int)_end.X == (int)Math.Round(_actor.X) && (int)_end.Y == (int)Math.Round(_actor.Y))
                {
                    _running = false;
                    x = _actor.X;
                    y = _actor.Y;
                }
                else
                {
                    Vector2 v = new Vector2(_end.X - _actor.X, _end.Y - _actor.Y);
                    v.Normalize();

                    x = (float)(_actor.X + v.X * speed);
                    y = (float)(_actor.Y + v.Y * speed);
                }
                
            }

            _actor.SetPosition(x, y);
        }
    }
}

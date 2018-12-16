using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public class Animation : IAnimation, ICloneable
    {
        protected Actor _actor;
        protected double _startTime;
        protected double _time;
        protected Action<Animation, GameTime> _callback;
        protected bool _repeated;
        protected bool _running;

        public Animation()
        {
            _repeated = false;
            _running = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (_startTime > 0)
            {
                _time -= gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (_time <= 0 && _callback != null)
            {
                _callback(this, gameTime);
            }

            if (_time <= 0 && _repeated)
            {
                Reset();
            }

            if (_time <= 0 && _startTime > 0)
            {
                _running = false;
            }
        }

        public void Reset()
        {
            _time = _startTime;
            _running = true;
        }

        public bool IsEnded()
        {
            return !_running || ((_startTime > 0 && _time <= 0) && !_repeated);
        }

        public void SetActor(Actor actor)
        {
            _actor = actor;
        }

        public void SetCallback(Action<Animation, GameTime> callback)
        {
            _callback = callback;
        }

        public void SetTimeAnimation(double time)
        {
            _startTime = time;
            Reset();
        }

        public void SetRepeat(bool value)
        {
            _repeated = value;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual Animation GetClone()
        {
            return (Animation)Clone();
        }
    }
}

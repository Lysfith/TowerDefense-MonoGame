using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public class AnimationSequence : Animation, ICloneable
    {
        private Queue<Animation> _animations;
        private int _index = 0;

        public AnimationSequence(bool repeated = false)
        {
            _animations = new Queue<Animation>();
            _repeated = repeated;
        }

        public override void Update(GameTime gameTime)
        {
            if(_animations.ElementAt(_index).IsEnded())
            {
                _index++;
                if(_index > _animations.Count-1)
                {
                    _index = 0;
                }
            }
            else
            {
                _animations.ElementAt(_index).SetActor(_actor);
                _animations.ElementAt(_index).Update(gameTime);
            }

            if(_animations.All(x => x.IsEnded()) && _repeated)
            {
                Reset();
                _index = 0;
            }
        }

        public new bool IsEnded()
        {
            return _animations.All(x => x.IsEnded()) && !_repeated;
        }

        public new void Reset()
        {
            foreach(var animation in _animations)
            {
                animation.Reset();
            }
        }

        public void AddAnimation(Animation animation)
        {
            _animations.Enqueue(animation);
        }

        public Queue<Animation> GetAnimations()
        {
            return _animations;
        }

        public void ClearAnimations()
        {
            _animations.Clear();
        }

        public new AnimationSequence GetClone()
        {
            var c = (AnimationSequence)Clone();

            foreach (var animation in _animations)
            {
                c.AddAnimation(animation.GetClone());
            }

            return c;
        }
    }
}

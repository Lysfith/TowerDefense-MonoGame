using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public class AnimationParallele : Animation
    {
        private Queue<Animation> _animations;

        public AnimationParallele()
        {
            _animations = new Queue<Animation>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var animation in _animations)
            {
                animation.Update(gameTime);
            }
        }

        public new bool IsEnded()
        {
            return _animations.All(x => x.IsEnded());
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
    }
}

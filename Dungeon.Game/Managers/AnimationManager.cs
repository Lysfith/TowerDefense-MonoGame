using Dungeon.Game.Animations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Managers
{
    public class AnimationManager
    {
        private List<Animation> _animations;
        private Queue<Animation> _nextAnimations;
        private bool _clearAsked = false;

        public AnimationManager()
        {
            _animations = new List<Animation>();
            _nextAnimations = new Queue<Animation>();
        }

        public void Update(GameTime gameTime)
        {
            foreach(var animation in _animations)
            {
                animation.Update(gameTime);
            }

            if (_nextAnimations.Any())
            {
                while(_nextAnimations.Any())
                {
                    _animations.Add(_nextAnimations.Dequeue());
                }
            }

            if (_animations.Any())
            {
                _animations.RemoveAll(x => x.IsEnded());
            }

            if(_clearAsked)
            {
                _animations.Clear();
                _nextAnimations.Clear();
                _clearAsked = false;
            }
        }

        public void AddAnimation(Animation animation)
        {
            if (animation == null)
            {
                throw new Exception("Impossible d'ajouter l'animation, elle est null");
            }

            _nextAnimations.Enqueue(animation);
        }

        public void Clear()
        {
            _clearAsked = true;
        }
    }
}

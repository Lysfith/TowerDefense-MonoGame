using _2015_Project_3.Scenes.GameSceneEntities.Ennemies;
using _2015_Project_3.Scenes.GameSceneEntities.Towers;
using Dungeon.Game.Animations;
using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities.Bullets
{
    public class Bullet : Entity
    {
        public Tower Parent { get; protected set; }
        public int Damage { get; protected set; }
        public Ennemy Target { get; protected set; }

        public double _speed;

        public Bullet(Tower parent, int damage, Ennemy target)
        {
            _speed = 0;
            Parent = parent;
            Damage = damage;
            Target = target;
            Life = 1;
        }

        public override void LoadAnimations()
        {
            var animation = new Animation();
            animation.SetCallback(Move);
            animation.SetRepeat(true);

            this.AttachAnimation(animation);
            this.Scene.AnimationManager.AddAnimation(animation);
        }

        public virtual void Move(Animation animation, GameTime gameTime)
        {
            if (Target != null && IsAlive())
            {
                if (_speed == 0)
                {
                    _speed = Speed * gameTime.ElapsedGameTime.TotalSeconds;
                }

                var v = new Vector2(Target.X - X, Target.Y - Y);
                v.Normalize();

                SetPosition((float)(X + v.X * _speed), (float)(Y + v.Y * _speed));

                bool collision = Tower.PointInCircle(X, Y, Target.X, Target.Y, Target.Width);
                if (collision)
                {
                    Effect();

                    Death();
                    animation.SetRepeat(false);
                }
            }
            
        }

        public virtual void Effect()
        {
            Target.SetDamage(Damage);

        }

    }
}

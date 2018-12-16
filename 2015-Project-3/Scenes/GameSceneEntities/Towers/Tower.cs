using _2015_Project_3.Scenes.GameSceneEntities.Bullets;
using _2015_Project_3.Scenes.GameSceneEntities.Ennemies;
using Dungeon.Game.Animations;
using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities.Towers
{
    public class Tower : Entity
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int RangeMin { get; protected set; }
        public int RangeMax { get; protected set; }
        public Ennemy Target { get; protected set; }

        private Animation _checkTarget;
        private Animation _fire;

        public Tower(string name, int damage, int rangeMax, int rangeMin = 0)
        {
            Name = name;
            Damage = damage;
            RangeMax = rangeMax;
            RangeMin = rangeMin;

        }

        public override void LoadAnimations()
        {
            _checkTarget = new Animation();
            _checkTarget.SetCallback(CheckTarget);
            _checkTarget.SetRepeat(true);
            _checkTarget.SetTimeAnimation(0.2);

            this.AttachAnimation(_checkTarget);
            this.Scene.AnimationManager.AddAnimation(_checkTarget);

            _fire = new Animation();
            _fire.SetCallback(Fire);
            _fire.SetRepeat(true);
            _fire.SetTimeAnimation(1);

            this.AttachAnimation(_fire);
            this.Scene.AnimationManager.AddAnimation(_fire);

        }

        public virtual void CheckTarget(Animation animation, GameTime gameTime)
        {
            //On cherche une cible
            if (Target == null)
            {
                foreach (var e in Scene.GetEnnemies())
                {
                    bool min = false;
                    bool max = false;
                    if (RangeMin != 0)
                    {
                        min = PointInCircle(e.X, e.Y, X, Y, RangeMin);
                    }

                    if(!min)
                    {
                        max = PointInCircle(e.X, e.Y, X, Y, RangeMax);

                        if(max)
                        {
                            Target = e;
                            _fire.Reset();
                            break;
                        }
                    }
                }
            }
            else
            {
                bool min = false;
                bool max = false;
                if (RangeMin != 0)
                {
                    min = PointInCircle(Target.X, Target.Y, X, Y, RangeMin);
                }

                if (!min)
                {
                    max = PointInCircle(Target.X, Target.Y, X, Y, RangeMax);

                    if (!max)
                    {
                        Target = null;
                    }
                }
                else
                {
                    Target = null;
                }
            }
        }

        public virtual void Fire(Animation animation, GameTime gameTime)
        {
            if (Target != null && Target.IsAlive())
            {
                var bullet = new Bullet(this, this.Damage, Target);
                bullet.SetColor(Microsoft.Xna.Framework.Color.Green);
                bullet.SetSize(16, 16);
                bullet.SetPosition(X, Y);
                bullet.SetSpeed(300);
                bullet.SetScene(Scene);
                Sprite.Layer.AddSprite(bullet.Sprite);

                Scene.AddBullet(bullet);
            }
            
        }

        public void SetTarget(Ennemy ennemy)
        {
            Target = ennemy;
        }

        public static bool PointInCircle(float px, float py, float cx, float cy, int r)
        {
            return Math.Sqrt(Math.Pow(px-cx, 2) + Math.Pow(py - cy, 2)) < r;
        }
    }
}

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
    public class FreezeTower : Tower
    {
        public FreezeTower(string name, int damage, int rangeMax, int rangeMin = 0)
            : base (name, damage, rangeMax, rangeMin)
        {

        }

        public override void Fire(Animation animation, GameTime gameTime)
        {
            if (Target != null && Target.IsAlive())
            {
                var bullet = new FreezeBullet(this, this.Damage, Target, 0.5);
                bullet.SetColor(Microsoft.Xna.Framework.Color.Blue);
                bullet.SetSize(16, 16);
                bullet.SetPosition(X, Y);
                bullet.SetSpeed(300);
                bullet.SetScene(Scene);
                Sprite.Layer.AddSprite(bullet.Sprite);

                Scene.AddBullet(bullet);
            }
            
        }
    }
}

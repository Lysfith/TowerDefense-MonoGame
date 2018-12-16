using _2015_Project_3.Scenes.GameSceneEntities.Effects;
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
    public class FreezeBullet : Bullet
    {
        private Effect _effect;

        public FreezeBullet(Tower parent, int damage, Ennemy target, double slow)
            : base(parent, damage, target)
        {
            _effect = new FreezeEffect(target, 3, slow);

        }


        public override void Effect()
        {
            Target.SetDamage(Damage);
            Target.AddEffect(_effect);
        }
    }
}

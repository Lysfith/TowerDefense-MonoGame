using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities.Effects
{
    public class FreezeEffect : Effect
    {
        public double Slow { get; protected set; }

        public FreezeEffect(Entity target, double time, double slow)
            : base(EffectEnum.FREEZE, target, time)
        {
            Slow = slow;
        }

        public override void Apply(GameTime gameTime)
        {
            base.Apply(gameTime);

            if(Target != null && Target.IsAlive())
            {
                if (!IsEnded())
                {
                    Target.SetSpeed((int)(Target.SpeedMax - Target.SpeedMax * Slow));
                    Target.SetColor(Color.Magenta);
                }
                else
                {
                    Target.SetSpeed(Target.SpeedMax);
                    Target.SetColor(Color.Red);
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities.Effects
{
    public class Effect : ICloneable
    {
        public Entity Target { get; }
        public EffectEnum Type { get; }
        public double Time { get; protected set; }

        public Effect(EffectEnum type, Entity target, double time)
        {
            Type = type;
            Target = target;
            Time = time;
        }

        public virtual void Apply(GameTime gameTime)
        {
            Time -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        public bool IsEnded()
        {
            return Time <= 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

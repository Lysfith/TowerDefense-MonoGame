using _2015_Project_3.Scenes.GameSceneEntities.Effects;
using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities
{
    public class Entity : Actor
    {
        public Sprite Sprite { get; private set; }
        public GameScene Scene { get; private set; }

        public int LifeMax { get; protected set; }
        public int Life { get; protected set; }

        public int SpeedMax { get; protected set; }

        private Dictionary<EffectEnum, Effect> _effects;

        public Entity()
        {
            Sprite = new Sprite("blank", new Rectangle(0, 0, 64, 64));

            _effects = new Dictionary<EffectEnum, Effect>();
        }

        public override void SetPosition(float x, float y)
        {
            base.SetPosition(x, y);
            Sprite.SetPosition((int)(x - Width * 0.5), (int)(y - Height * 0.5));
        }

        public override void SetSize(int width, int height)
        {
            base.SetSize(width, height);
            Sprite.SetSize(width, height);
        }

        public override void SetColor(Color color)
        {
            base.SetColor(color);
            Sprite.SetColor(color);
        }

        public override void SetSpeed(int speed)
        {
            Speed = speed;
        }

        public void SetSpeedMax(int speed)
        {
            SpeedMax = speed;
            Speed = speed;
        }

        public void SetDamage(int amount)
        {
            Life -= amount;
        }

        public void SetScene(GameScene scene)
        {
            Scene = scene;
        }

        public bool IsAlive()
        {
            return Life > 0;
        }

        public void Death()
        {
            Life = 0;

        }

        public virtual void LoadAnimations()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(var e in _effects)
            {
                e.Value.Apply(gameTime);
            }

        }

        public void AddEffect(Effect effect)
        {
            if(!_effects.ContainsKey(effect.Type))
            {
                _effects.Add(effect.Type, effect);
            }
            else
            {
                _effects[effect.Type] = effect;
            }
        }

    }
}

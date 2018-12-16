using Dungeon.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Game.Components
{
    public class Scene : IDrawable, IUpdatable
    {
        public bool Visible { get; protected set; }
        public string Name { get; protected set; }

        public AnimationManager AnimationManager { get; protected set; }

        public Layer BackgroundLayer { get; protected set; }
        public Layer ForegroundLayer { get; protected set; }
        public Layer UILayer { get; protected set; }

        public bool Started { get; protected set; }
        public bool Paused { get; protected set; }

        //protected List<Layer> _layers;

        public Scene(string name)
        {
            //_layers = new List<Layer>();
            Visible = false;
            Name = name;
        }

        public virtual void Start(int width, int height)
        {
            BackgroundLayer = new Layer(0, 0, width, height);
            ForegroundLayer = new Layer(0, 0, width, height);
            UILayer = new Layer(0, 0, width, height);

            AnimationManager = new AnimationManager();

            Started = true;
        }

        public virtual void End()
        {
            Started = false;

            BackgroundLayer = null;
            ForegroundLayer = null;
            UILayer = null;
        }

        public virtual void Pause()
        {
            Paused = true;
        }

        public virtual void Resume()
        {
            Paused = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Visible)
            {
                BackgroundLayer.Update(gameTime);
                ForegroundLayer.Update(gameTime);
                UILayer.Update(gameTime);

                AnimationManager.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                BackgroundLayer.Draw(gameTime, spriteBatch);
                ForegroundLayer.Draw(gameTime, spriteBatch);
                UILayer.Draw(gameTime, spriteBatch);
            }
        }

        //public void AddLayer(Layer layer)
        //{
        //    if(Visible)
        //        throw new Exception("Impossible d'ajouter un layer si la scène est visible");

        //    _layers.Add(layer);
        //}

        //public void RemoveLayer(Layer layer)
        //{
        //    if (Visible)
        //        throw new Exception("Impossible de supprimer un layer si la scène est visible");

        //    if (!_layers.Contains(layer))
        //        throw new Exception("Impossible de supprimer le layer, il n'existe pas");

        //    _layers.Remove(layer);
        //}

        //public void ClearLayers()
        //{
        //    if (Visible)
        //        throw new Exception("Impossible de supprimer les layers si la scène est visible");

        //    _layers.Clear();
        //}

        public void SetVisible(bool value)
        {
            Visible = value;


        }
    }
}

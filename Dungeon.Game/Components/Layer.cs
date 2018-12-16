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
    public class Layer : IDrawable, IUpdatable
    {
        public int Order { get; set; }
        public bool Visible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private List<Sprite> _sprites;

        private List<TextDisplay> _texts;

        public Layer(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            _sprites = new List<Sprite>();
            _texts = new List<TextDisplay>();
            Visible = true;
            
        }

        public void Update(GameTime gameTime)
        {
            if (Visible)
            {
             
            }

            //if (_nextSprites.Any())
            //{
            //    while (_nextSprites.Any())
            //    {
            //        _sprites.Add(_nextSprites.Dequeue());
            //    }
            //}
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                foreach (var sprite in _sprites)
                {
                    spriteBatch.Draw(ResourceManager.Instance.GetSpriteSheet(), sprite.DestinationRectangle, ResourceManager.Instance.GetRegion(sprite.Texture), sprite.Color);
                }

                foreach (var text in _texts)
                {
                    spriteBatch.DrawString(
                        ResourceManager.Instance.GetFont("Segoe UI Mono"),
                        text.Text, text.Position, text.Color);
                }
            }
        }

        public void AddSprite(Sprite sprite)
        {
            sprite.SetLayer(this);
            _sprites.Add(sprite);
        }

        public void RemoveSprite(Sprite sprite)
        {
            _sprites.Remove(sprite);
        }

        public void AddText(TextDisplay text)
        {
            text.SetLayer(this);
            _texts.Add(text);
        }

        public void RemoveText(TextDisplay text)
        {
            _texts.Remove(text);
        }
    }
}

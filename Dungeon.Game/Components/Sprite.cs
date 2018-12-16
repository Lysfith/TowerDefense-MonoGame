using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Components
{
    public class Sprite
    {
        public Layer Layer;
        public string Texture;
        public Rectangle DestinationRectangle;
        public Color Color;

        public Sprite(string texture, Rectangle destinationRectangle)
        {
            Texture = texture;
            DestinationRectangle = destinationRectangle;
            Color = Color.White;
        }

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void SetPosition(int x, int y)
        {
            DestinationRectangle.X = x;
            DestinationRectangle.Y = y;
        }

        public void SetSize(int width, int height)
        {
            DestinationRectangle.Width = width;
            DestinationRectangle.Height = height;
        }

        public void SetLayer(Layer layer)
        {
            Layer = layer;
        }
    }
}

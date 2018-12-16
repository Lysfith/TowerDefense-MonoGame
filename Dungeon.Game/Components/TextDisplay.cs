using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Components
{
    public class TextDisplay
    {
        public Layer Layer;
        public string Text;
        public Vector2 Position;
        public Color Color;

        public TextDisplay(string text, Vector2 position)
        {
            Text = text;
            Position = position;
            Color = Color.White;
        }

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void SetPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void SetLayer(Layer layer)
        {
            Layer = layer;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}

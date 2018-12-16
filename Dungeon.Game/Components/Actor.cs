using Dungeon.Game.Animations;
using Dungeon.Game.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Components
{
    public class Actor
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public float ScaleX { get; protected set; }
        public float ScaleY { get; protected set; }
        public Color Color { get; protected set; }
        public bool Visible { get; protected set; }
        public int Speed { get; protected set; }


        public Actor()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            ScaleX = 1;
            ScaleY = 1;
            Speed = 0;
            Color = Color.White;
            Visible = false;
        }

        public void AttachAnimation(Animation animation)
        {
            animation.SetActor(this);
           
        }

        public virtual void SetColor(Color color)
        {
            Color = color;
        }

        public virtual void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        public virtual void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual void SetScale(int x, int y)
        {
            ScaleX = x;
            ScaleY = y;
        }

        public virtual void SetVisible(bool value)
        {
            Visible= value;
        }

        public virtual void SetSpeed(int speed)
        {
            Speed = speed;
        }
    }
}

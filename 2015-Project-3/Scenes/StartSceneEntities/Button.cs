using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.StartSceneEntities
{
    public class Button : Actor
    {
        public Sprite Sprite { get; private set; }

        public Button()
        {
            Sprite = new Sprite("blank", new Rectangle(100, 100, 64, 64));
            X = 100;
            Y = 100;
            Width = 64;
            Height = 64;
        }

        public new void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            Sprite.SetPosition(x, y);
        }

        public new void SetSize(int width, int height)
        {
            base.SetSize(width, height);
            Sprite.SetPosition(width, height);
        }

        public new void SetColor(Color color)
        {
            base.SetColor(color);
            Sprite.SetColor(color);
        }
    }
}

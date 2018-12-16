using _2015_Project_3.Scenes.StartSceneEntities;
using Dungeon.Game.Animations;
using Dungeon.Game.Components;
using Dungeon.Game.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes
{
    public class StartScene
    {
        public Scene Scene { get; }
        public Layer BackgroundLayer { get; }
        public Layer ForegroundLayer { get; }

        public StartScene()
        {

        }

        private void LoadBackgroundLayer()
        {
            //var button = new Button();
            //button.SetPosition(200, 100);
            //BackgroundLayer.AddSprite(button.Sprite);

            //var animSequence = new AnimationSequence(true);

            //var animationc0 = new ColorAnimation(Color.Blue, Color.Red);
            //var animation1 = new MoveAnimation(new Vector2(1, 0), 200, Test);
            //var animationc1 = new ColorAnimation(Color.Red, Color.Transparent);
            //var animation2 = new MoveAnimation(new Vector2(0, 1), 200);
            //var animation3 = new MoveAnimation(new Vector2(-1, 0), 200);
            //var animationc2 = new ColorAnimation(Color.Transparent, Color.Blue);
            //var animation4 = new MoveAnimation(new Vector2(0, -1), 200);

            //var animParallele1 = new AnimationParallele();

            //animParallele1.AddAnimation(animationc0);
            //animParallele1.AddAnimation(animation1);

            //animSequence.AddAnimation(animParallele1);

            //var animParallele2 = new AnimationParallele();

            //animParallele2.AddAnimation(animationc1);
            //animParallele2.AddAnimation(animation2);

            //animSequence.AddAnimation(animParallele2);

            //animSequence.AddAnimation(animation3);

            //var animParallele3 = new AnimationParallele();

            //animParallele3.AddAnimation(animationc2);
            //animParallele3.AddAnimation(animation4);

            //animSequence.AddAnimation(animParallele3);


            //AnimationManager.Instance.AddAnimation(animSequence);
        }

        private void LoadForegroundLayer()
        {

        }

        private Vector2 Test(int x, int y)
        {
            return new Vector2(x, y + (int)(Math.Sin(x/5) * 10));
        }
    }
}

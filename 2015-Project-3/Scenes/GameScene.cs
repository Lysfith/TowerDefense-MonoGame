using _2015_Project_3.Scenes.GameSceneEntities;
using _2015_Project_3.Scenes.GameSceneEntities.Bullets;
using _2015_Project_3.Scenes.GameSceneEntities.Ennemies;
using _2015_Project_3.Scenes.GameSceneEntities.Towers;
using _2015_Project_3.Scenes.StartSceneEntities;
using Dungeon.Game.Animations;
using Dungeon.Game.Components;
using Dungeon.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes
{
    public class GameScene : Scene
    {
       
        private List<Tower> _towers;
        private List<Ennemy> _ennemies;
        private List<Bullet> _bullets;

        private TextDisplay _debug;

        public GameScene() : base("GameScene")
        {

        }


        public override void Start(int width, int height)
        {
            base.Start(width, height);

            Started = false;

            _bullets = new List<Bullet>();
            _towers = new List<Tower>();
            _ennemies = new List<Ennemy>();

            LoadBackgroundLayer();
            LoadForegroundLayer();
            LoadUILayer();

            //Animations Loading
            foreach(var t in _towers)
            {
                t.LoadAnimations();
            }

            foreach (var e in _ennemies)
            {
                e.LoadAnimations();
            }

            foreach (var b in _bullets)
            {
                b.LoadAnimations();
            }

            Started = true;
        }

        public override void End()
        {
            base.End();
        }

        public override void Pause()
        {
            base.Pause();
        }

        public override void Resume()
        {
            base.Resume();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Maj entities
            foreach(var b in _bullets)
            {
                b.Update(gameTime);
            }

            foreach (var e in _ennemies)
            {
                e.Update(gameTime);
            }

            foreach (var t in _towers)
            {
                t.Update(gameTime);
            }

            _bullets.Where(x => !x.IsAlive()).ToList().ForEach(x => x.Sprite.Layer.RemoveSprite(x.Sprite));
            _bullets.RemoveAll(x => !x.IsAlive());

            _ennemies.Where(x => !x.IsAlive()).ToList().ForEach(x => x.Sprite.Layer.RemoveSprite(x.Sprite));
            _ennemies.RemoveAll(x => !x.IsAlive());

            _debug.SetText(GameManager.ElapsedTime.ToString("0.000000"));
        }

        private void LoadBackgroundLayer()
        {
            
        }

        private void LoadForegroundLayer()
        {
            var tower1 = new Tower("Tower1", 10, 200);
            tower1.SetScene(this);
            tower1.SetColor(Color.Orange);
            tower1.SetSize(64, 64);
            tower1.SetPosition((int)(ForegroundLayer.Width*0.5), (int)(ForegroundLayer.Height * 0.5));
            ForegroundLayer.AddSprite(tower1.Sprite);

            _towers.Add(tower1);

            var tower2 = new Tower("Tower1", 20, 300);
            tower2.SetScene(this);
            tower2.SetColor(Color.Orange);
            tower2.SetSize(64, 64);
            tower2.SetPosition((int)(ForegroundLayer.Width * 0.7), (int)(ForegroundLayer.Height * 0.7));
            ForegroundLayer.AddSprite(tower2.Sprite);

            _towers.Add(tower2);

            var tower3 = new FreezeTower("Tower1", 15, 300);
            tower3.SetScene(this);
            tower3.SetColor(Color.Cyan);
            tower3.SetSize(64, 64);
            tower3.SetPosition((int)(ForegroundLayer.Width * 0.3), (int)(ForegroundLayer.Height * 0.3));
            ForegroundLayer.AddSprite(tower3.Sprite);

            _towers.Add(tower3);

            //=======================

            //var ennemy1 = new Ennemy("Ennemy1", 1000);
            //ennemy1.SetScene(this);
            //ennemy1.SetColor(Color.Red);
            //ennemy1.SetSize(24, 24);
            //ennemy1.SetSpeedMax(100);
            //ennemy1.SetPosition(100, 100);
            //ForegroundLayer.AddSprite(ennemy1.Sprite);

            //var animation1 = new MoveAnimation(new Vector2(100, 100), new Vector2(100, 600));
            //var animation2 = new MoveAnimation(new Vector2(100, 600), new Vector2(600, 600));
            //var animation3 = new MoveAnimation(new Vector2(600, 600), new Vector2(600, 100));
            //var animation4 = new MoveAnimation(new Vector2(600, 100), new Vector2(900, 100));
            //var animation5 = new MoveAnimation(new Vector2(900, 100), new Vector2(900, 600));

            //var animSequence = new AnimationSequence();
            //animSequence.AddAnimation(animation1);
            //animSequence.AddAnimation(animation2);
            //animSequence.AddAnimation(animation3);
            //animSequence.AddAnimation(animation4);
            //animSequence.AddAnimation(animation5);

            //ennemy1.AttachAnimation(animSequence);

            //this.AnimationManager.AddAnimation(animSequence);

            //_ennemies.Add(ennemy1);

            //var test = (AnimationSequence)animSequence.Clone();

            ////=====

            //var ennemy2 = new Ennemy("Ennemy1", 1000);
            //ennemy2.SetScene(this);
            //ennemy2.SetColor(Color.Red);
            //ennemy2.SetSize(24, 24);
            //ennemy2.SetSpeedMax(100);
            //ennemy2.SetPosition(100, 90);
            //ForegroundLayer.AddSprite(ennemy2.Sprite);

            //var animation21 = new MoveAnimation(new Vector2(100, 100), new Vector2(100, 600));
            //var animation22 = new MoveAnimation(new Vector2(100, 600), new Vector2(600, 600));
            //var animation23 = new MoveAnimation(new Vector2(600, 600), new Vector2(600, 100));
            //var animation24 = new MoveAnimation(new Vector2(600, 100), new Vector2(900, 100));
            //var animation25 = new MoveAnimation(new Vector2(900, 100), new Vector2(900, 600));

            //var animSequence2 = new AnimationSequence();
            //animSequence2.AddAnimation(animation21);
            //animSequence2.AddAnimation(animation22);
            //animSequence2.AddAnimation(animation23);
            //animSequence2.AddAnimation(animation24);
            //animSequence2.AddAnimation(animation25);

            //ennemy2.AttachAnimation(animSequence2);

            //this.AnimationManager.AddAnimation(animSequence2);

            //_ennemies.Add(ennemy2);


            var spawn = new Animation();
            spawn.SetCallback(SpawnEnnemy);
            spawn.SetRepeat(true);
            spawn.SetTimeAnimation(2);

            this.AnimationManager.AddAnimation(spawn);
        }

        public void SpawnEnnemy(Animation animation, GameTime gameTime)
        {
            var ennemy2 = new Ennemy("Ennemy1", 1000);
            ennemy2.SetScene(this);
            ennemy2.SetColor(Color.Red);
            ennemy2.SetSize(24, 24);
            ennemy2.SetSpeedMax(100);
            ennemy2.SetPosition(100, 100);
            ForegroundLayer.AddSprite(ennemy2.Sprite);

            var animation21 = new MoveAnimation(new Vector2(100, 100), new Vector2(100, 600));
            var animation22 = new MoveAnimation(new Vector2(100, 600), new Vector2(600, 600));
            var animation23 = new MoveAnimation(new Vector2(600, 600), new Vector2(600, 100));
            var animation24 = new MoveAnimation(new Vector2(600, 100), new Vector2(900, 100));
            var animation25 = new MoveAnimation(new Vector2(900, 100), new Vector2(900, 600));

            var animSequence2 = new AnimationSequence();
            animSequence2.AddAnimation(animation21);
            animSequence2.AddAnimation(animation22);
            animSequence2.AddAnimation(animation23);
            animSequence2.AddAnimation(animation24);
            animSequence2.AddAnimation(animation25);

            ennemy2.AttachAnimation(animSequence2);

            this.AnimationManager.AddAnimation(animSequence2);

            _ennemies.Add(ennemy2);
        }

        private void LoadUILayer()
        {
            _debug = new TextDisplay("Test", new Vector2(10, 10));
            _debug.SetColor(Color.Yellow);
            UILayer.AddText(_debug);
        }

        public List<Ennemy> GetEnnemies()
        {
            return new List<Ennemy>(_ennemies);
        }

        public void AddBullet(Bullet bullet)
        {
            if(Started)
            {
                bullet.LoadAnimations();
            }
            _bullets.Add(bullet);
        }

        public void AddEnnemy(Ennemy ennemy)
        {
            if (Started)
            {
                ennemy.LoadAnimations();
            }
            _ennemies.Add(ennemy);
        }

        public void AddTower(Tower tower)
        {
            if (Started)
            {
                tower.LoadAnimations();
            }
            _towers.Add(tower);
        }
    }
}

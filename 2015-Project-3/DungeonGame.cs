using _2015_Project_3.Scenes;
using Dungeon.Game.Components;
using Dungeon.Game.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _2015_Project_3
{
    public class DungeonGame
    {
        GameManager game;

        private StartScene _startScene;
        private GameScene _gameScene;

        public DungeonGame()
        {
            _startScene = new StartScene();
            _gameScene = new GameScene();
        }

        public void Start()
        {
            game = new GameManager();
            

            game.AddScene(_gameScene);
            game.ChangeScene(_gameScene.Name);
            _gameScene.SetVisible(true);

            game.Run();

            //var thread = new Thread(new ThreadStart(game.Run));
            //thread.Start();

            //Console.WriteLine("tutu");
            //Console.ReadKey();
        }
    }
}

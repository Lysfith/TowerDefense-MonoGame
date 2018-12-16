using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dungeon.Game.Managers
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameManager : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public static double ElapsedTime;

        private Dictionary<string, Scene> _scenes;
        private Scene _currentScene;

        public GameManager()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = 1366;
            Graphics.PreferredBackBufferHeight = 768;
            this.Window.AllowAltF4 = true;
            this.Window.AllowUserResizing = true;
            IsMouseVisible = true;

            Content.RootDirectory = "Content";

            _scenes = new Dictionary<string, Scene>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.SetContentManager(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var sw = new Stopwatch();
            sw.Start();
            if (_currentScene != null && _currentScene.Visible)
            {
                _currentScene.Update(gameTime);
            }

            sw.Stop();

            ElapsedTime = sw.Elapsed.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            if (_currentScene != null && _currentScene.Visible)
            {
                _currentScene.Draw(gameTime, SpriteBatch);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        public void AddScene(Scene scene)
        {
            if(_scenes.ContainsKey(scene.Name))
            {
                throw new Exception("Impossible d'ajouter la scène, une autre porte déjà le même nom");
            }

            _scenes.Add(scene.Name, scene);
        }

        public void RemoveScene(string name)
        {
            if (!_scenes.ContainsKey(name))
            {
                throw new Exception("Impossible de supprimer la scène, elle n'existe pas");
            }

            if (_currentScene != null && _currentScene.Name == name)
            {
                throw new Exception("Impossible de supprimer la scène, elle est actuellement utilisée");
            }

            _scenes.Remove(name);
        }

        public void ChangeScene(string name)
        {
            if (!_scenes.ContainsKey(name))
            {
                throw new Exception("Impossible de changer la scène, " + name + " n'existe pas");
            }

            if (_currentScene != null && _currentScene.Visible)
            {
                throw new Exception("Impossible de changer la scène, la scène actuelle est visible");
            }

            if(_currentScene != null)
            {
                _currentScene.End();
            }
            _currentScene = _scenes[name];
            _currentScene.Start(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
        }
    }
}

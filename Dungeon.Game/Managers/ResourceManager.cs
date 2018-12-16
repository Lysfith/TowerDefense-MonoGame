using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Managers
{
    public class ResourceManager
    {
        #region Static
        private static ResourceManager _instance;

        public static ResourceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceManager();
                }

                return _instance;
            }
        }
        #endregion

        private ContentManager _content;
        private Dictionary<string, SpriteFont> _fonts;
        private Texture2D _spriteSheet;
        private Dictionary<string, Rectangle> _regions;

        public ResourceManager()
        {

            
        }

        public void SetContentManager(ContentManager content)
        {
            _content = content;

            LoadContents();

        }

        private void LoadContents()
        {
            _regions = new Dictionary<string, Rectangle>();

            LoadFont();

            LoadSpriteSheet();

            LoadSprites();
        }

        private void LoadSpriteSheet()
        {
            _spriteSheet = _content.Load<Texture2D>("Images/spritesheet");
        }

        private void LoadSprites()
        {
            _regions = new Dictionary<string, Rectangle>();

            _regions.Add("blank", new Rectangle(0, 0, 64, 64));
        }

        public Rectangle GetRegion(string name)
        {
            if(_regions.ContainsKey(name))
                return _regions[name];

            throw new Exception("La région " + name + " n'existe pas");
        }

        public Texture2D GetSpriteSheet()
        {
            if (_spriteSheet == null)
                throw new Exception("La spriteSheet n'a pas été chargée");

            return _spriteSheet;
        }

        private void LoadFont()
        {
            _fonts = new Dictionary<string, SpriteFont>();

            var font = _content.Load<SpriteFont>("Fonts/Segoe UI Mono");
            _fonts.Add("Segoe UI Mono", font);
        }

        public SpriteFont GetFont(string fontName)
        {
            if (_fonts.ContainsKey(fontName))
            {
                return _fonts[fontName];
            }
            return null;
        }
    }
}

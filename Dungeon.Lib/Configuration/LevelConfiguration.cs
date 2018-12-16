using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Lib.Configuration
{
    public class LevelConfiguration
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public bool BossArea { get; set; }
        public bool TraderArea { get; set; }
        public bool MagicianArea { get; set; }
    }
}

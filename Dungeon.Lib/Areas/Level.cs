using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Lib.Areas
{
    public class Level
    {
        public Dictionary<Guid, Area> Areas { get; }

        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        public Level()
        {
            Areas = new Dictionary<Guid, Area>();
        }

        public void AddArea(Area area)
        {
            Areas.Add(area.Id, area);
        }

        public Area GetArea(Guid id)
        {
            if(Areas.ContainsKey(id))
            {
                return Areas[id];
            }
            return null;
        }

        public void Generate()
        {
            
        }
    }
}

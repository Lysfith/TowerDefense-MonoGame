using Dungeon.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Lib.Areas
{
    public class Area
    {
        public Guid Id { get; }
        public int Width { get; }
        public int Height { get; }
        public bool IsSimpleEntrance { get; }
        public Direction EntranceDirection { get; }

        public Area(int width, int height, bool isSimpleEntrance = true, Direction entranceDirection = Direction.SOUTH)
        {
            Id = Guid.NewGuid();
            Width = width;
            Height = height;
            IsSimpleEntrance = isSimpleEntrance;
            EntranceDirection = entranceDirection;
        }
    }
}

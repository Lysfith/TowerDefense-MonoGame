using Dungeon.Game.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Animations
{
    public interface IAnimation
    {
        void Update(GameTime gameTime);
        bool IsEnded();
        void Reset();
    }
}

﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon.Game.Components
{
    public interface IUpdatable
    {
        void Update(GameTime gameTime);
    }
}

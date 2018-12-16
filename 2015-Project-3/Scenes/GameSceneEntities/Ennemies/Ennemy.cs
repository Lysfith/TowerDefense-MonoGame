using Dungeon.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2015_Project_3.Scenes.GameSceneEntities.Ennemies
{
    public class Ennemy : Entity
    {
        public string Name { get; protected set; }
        

        public Ennemy(string name, int life)
        {
            Name = name;
            LifeMax = life;
            Life = life;
        }

        public void Update()
        {

        }

       
    }
}

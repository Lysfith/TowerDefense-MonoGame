using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Lib
{
    public class DungeonManager
    {
        #region Static
        private static DungeonManager _instance;

        public static DungeonManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DungeonManager();
                }

                return _instance;
            }
        }
        #endregion

        public DungeonManager()
        {

        }

        public void CreateLevel()
        {

        }
    }
}

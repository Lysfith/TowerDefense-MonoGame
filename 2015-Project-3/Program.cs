﻿using System;

namespace _2015_Project_3
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var game = new DungeonGame();

            game.Start();
        }
    }
#endif
}

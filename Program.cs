﻿using System;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ScreenBroadcast());
            Application.Run(new Aforge());
        }
    }
}

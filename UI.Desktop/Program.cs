﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formLogin login = new formLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new formMenuPrincipal());
            }
            else
            { 
                Application.Exit();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CatMan
{
    public class CatMan
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();  //c언어 함수 가져옴

        //좌표 함수
        public static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void catman() 
        { 
            MainGame mainGame = new MainGame();
            int clear = mainGame.Progress();
            
        }
    }
}

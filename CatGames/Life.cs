using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class Life
    {
        
        public static int Ix = 81;
        public static int Iy = 2;
        public void Upgame()
        {
            Console.SetCursorPosition(Life.Ix, Life.Iy);
            Console.Write("♥");
            CatGames.GameManager.SnakeStart();
            if (false)
            {
                Console.SetCursorPosition(Life.Ix - 1, Life.Iy);
                Console.Write("♡");
            }


        }
    }
}
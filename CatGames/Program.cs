using June_team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();
        


        static void Main(string[] args)
        {
            Life life = new Life(); 
            Fiid fild = new Fiid();
            Move move = new Move();
            Collision collision = new Collision();
            Draw draw = new Draw();

            
            if (!CatGames.GameManager.IsPlayMiniGame)
            {
                
                fild.print();
                move.M_move();
               
            }
            else if(!Music.re)
            {
                fild.print();
                move.M_move();

            }
            else if (!CatMan.MainGame.res)
            {
                fild.print();
                move.M_move();

            }
            else if (!Dowoon.FishGame.resu)
            {
                fild.print();
                move.M_move();


            }
        }
    }
}

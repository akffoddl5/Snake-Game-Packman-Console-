using June_team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{

    public class Collision
    {
        Draw draw = new Draw();
        Fiid fild = new Fiid();

        //public int gotoxy2(int x, int y)
        //{
        //    int[,] a = new int[y, x];
        //    return a[y, x];
        //}
        //public int gotoxy3(int x, int y)
        //{
        //    Console.SetCursorPosition(x, y);
        //    return x;
        //    return y;
        //}
        public void collinder()
        {
            

            bool up = false;
            bool down = false;
            bool left = false;
            bool right = false;
            Fiid fild = new Fiid();

            for (int i = 0; i <=28; i++)
            {

                if (Player.n_catX == 1 && Player.n_catY == i)
                {
                    left = true;

                    Console.SetCursorPosition(0, 0);

                    
                    CatGames.GameManager.IsPlayMiniGame = true;
                    Player.n_catX =25;
                    Player.n_catY =8;
                    CatGames.GameManager.SnakeStart();
                    CatGames.GameManager.IsPlayMiniGame = false;
                    CatGames.GameManager.SetWindowSize();
                    Console.SetCursorPosition(0, 0);
                    fild.print();
                    
                }
                else if (Player.n_catX  >= 63 && Player.n_catY == i)
                {
                    right = true;

                    Console.SetCursorPosition(0, 0);
                    
                     Music.re = true;
                    Player.n_catX = 25;
                    Player.n_catY = 8;
                    CatGames.GameManager.MusicStart();
                    Music.re = false;
                    CatGames.GameManager.SetWindowSize();
                    Console.SetCursorPosition(0, 0);
                    fild.print();
                   

                }
            }
            for (int j = 0; j <= 63; j++)
            {

                if (Player.n_catX == j && Player.n_catY == 1)
                {
                up = true;

                    Console.SetCursorPosition(0, 0);
                    
                    CatMan.MainGame.res=true;
                    Player.n_catX = 25;
                    Player.n_catY = 8;
                    CatGames.GameManager.CatManStart();
                    CatMan.MainGame.res  = false;
                    CatGames.GameManager.SetWindowSize();
                    Console.SetCursorPosition(0, 0);
                    fild.print();

                }
                 else if (Player.n_catX== j && Player.n_catY>= 28)
                {
                    down = true;

                    Console.SetCursorPosition(0, 0);
                   
                    Dowoon.FishGame.resu = true;
                    Player.n_catX = 25;
                    Player.n_catY = 8;
                    Console.Clear();
                    CatGames.GameManager.FishStart();
                    Dowoon.FishGame.resu = false;
                    CatGames.GameManager.SetWindowSize();
                    Console.SetCursorPosition(0, 0);
                    fild.print();

                }

            }
     
        }
        
    

    //앵커좌포값확인
            public void collision()
             {
               
               Console.SetCursorPosition(0, 0);
            Console.Write(Player.n_catX+" ");
            Console.Write(Player.n_catY);

             }
    }
}

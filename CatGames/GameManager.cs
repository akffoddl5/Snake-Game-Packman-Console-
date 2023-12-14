using Dowoon;
using June_team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class GameManager
    {
        Fiid fild = new Fiid();
        Move move = new Move();
        Collision collision = new Collision();
        Draw draw = new Draw();

        public static bool IsPlayMiniGame;
        

        public void life()
        {

        }
        public void manager()
        {
            fild.print();
            move.M_move();
        }


        
        public static void SetWindowSize()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;
        }


        public static bool SnakeStart()
        {Console.Clear();
           
            //GameManager 만드시고 Progress 받으시고 1받으면 성공 2받으면 실패
            SnakeGame.GameManager gm = new SnakeGame.GameManager();
            //gm.Fail();
            gm.Init();
            int result = gm.Progress();

            Console.WriteLine(result);

            if (result == 1)
                return true;
            else return false;
        }


        public static bool MusicStart()
        {   
            Console.Clear();


            Music music = new Music();
            music.music();
            bool result;
            result =Music.re;
            if (result)
            return true;
            else return  false;
        }

        public static bool CatManStart()
        {


           
            CatMan.CatMan catman = new CatMan.CatMan();
            catman.catman();
            bool result;
            result = CatMan.MainGame.res;
            if (result)
                return true;
            else return false;
        }
        public static bool FishStart()
        {

;

            Dowoon.FishGame fish = new Dowoon.FishGame();
          
           
            bool result;
            result = FishingGame.PlayGame();
            Console.Clear();
            if (result)
                return true;
            else return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;




namespace Dowoon
{
    public class FishingGame
    {
  
        public static void RendererClear(int x, int y, int startX, int startY)
        {
            for (int i = startX; i < x; ++i)
            {
                for (int j = startY; j < y; ++j)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        public static bool PlayGame()
        {
            int Curr = Environment.TickCount;

            Console.SetBufferSize(100, 80);
            Console.SetWindowSize(100, 80);

            Console.Clear();
            FishingCat cat = new FishingCat();
            GoldFish[] goldFishArr = new GoldFish[5];
            for (int i = 0; i < goldFishArr.Length; i++)
            {
                goldFishArr[i] = new GoldFish();
                goldFishArr[i].InitializeFish();
            }
            Map.InitializeMap();

            while (true)
            {
                Map.RenderMap();
                cat.Play();
                //    cat.GuageButtoninput();
                for (int i = 0; i < goldFishArr.Length; i++)
                {
                    goldFishArr[i].Swim();
                    goldFishArr[i].Render();

                }
                bool b = false;
                if (cat.chance <= 0 || cat.catchFish >= cat.needFish)
                {

                    b = cat.CheckGameEnd();


                    return b;
                }

            }
        }
    }
}

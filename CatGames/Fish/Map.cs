using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dowoon
{
    public class Map
    {
        public static int nRow = 30;
        public static int nCol = 30;
        public static int offsetX = 10;
        public static int offsetY = 7;
       public static char[ , ] map_2d = new char[30, 30];
        public static Fish[,] map_2d_fish = new Fish[40, 40];
        System.Timers.Timer aTimer;
        public static void InitializeMap()
        {
            for(int i=0; i< nCol; ++i)
            {
                for(int j=0; j < nRow; ++j)
                {
                    if(i == 0)
                    {
                        
                        map_2d[i, j] = '~';
                    }

                    if( j == 0 || j == nCol-1 || i== nRow-1)
                    {
                     
                        map_2d[i, j] = '▣';

                    }


                    if (map_2d[i, j] != '~' && map_2d[i, j] != '▣')
                        map_2d[i,j] = ' ';

                }
            }
           
        }

        public static void RenderMap()
        {
           
          
          
            for(int i=0; i< nCol; ++i)
            {

                for (int j = 0; j < nRow; ++j)
                {
                    Console.SetCursorPosition(offsetX + j, offsetY + i);

                    if (i == 0)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    if (map_2d[i,j] != ' ')
                    Console.Write(map_2d[i, j]);

                }
            }

            Console.ForegroundColor = ConsoleColor.White;
           
        }

        /// <summary>
        /// 인덱스로 좌표를 찾아서, 그 좌표에 다른 오브젝트가 있는지 체크 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool SearchToIndex(int x,int y)
        {

            if (map_2d[x,y] == ' ' )
            {
                return false;
            }

            return true;

           
        }

        public static  void SetFishPosition(Fish fish, int x, int y) 
        {
            var offx= x - offsetX;
            var offy = y - offsetY;

            for(int i=0; i< nCol; ++i)
            {
                for(int j= 0; j< nRow; ++j)
                {
                    if (map_2d_fish[x, y] == fish)
                        map_2d_fish[x,y ] = null;
                }
            }

     
            map_2d_fish[x, y] = fish;
         

            if (map_2d_fish[x, y] != null)
            {
                return;
            }


        }



        public static bool GetIsFishExist_InMap(int x, int y)
        {
            x -= offsetX;
            y -= offsetY;

            if (map_2d_fish[x, y] == null)
                return false;
     

                return true;
        }
        public static Fish GetFish_InMap(int x, int y)
        {
            int xx; xx = x -offsetX;
            int yy; yy = y - offsetY;

            if (xx >= 0 && yy >= 0)
            {
        
                if (map_2d_fish[xx, yy] != null && !map_2d_fish[xx,yy].isDead)
                    return map_2d_fish[xx, yy];



            }


            return null;
        }
    }
}

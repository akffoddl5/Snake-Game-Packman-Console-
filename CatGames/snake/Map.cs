using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Map
    {
        public string[] p1 = { "^ ^", "ㅇㅇ", "ㅇ>", "<ㅇ" };
        public string[] p2 = { "ㅇㅇ", "vv", "ㅇ>", "<ㅇ" };



        //public enum Dir
        //{
        //    UP = 0,
        //    DOWN = 1,
        //    RIGHT= 2,
        //    LEFT = 3
        //}
        public void BaseMap()
        {
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
            Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣ ");

            //3,2 오른쪽 머리
            PrintIndexHead(3, 2);

            //for(int i = 0; i < 10; i++)
            //{
            //    for(int j=0; j < 7; j++)
            //    {
            //        PrintIndexHead(i, j);

            //    }

            //}
        }

        public void PrintIndexHead(int i, int j)
        {
            int x = 6 * i + 3;
            int y = 3 * j + 1;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(x, y);
            Console.Write("▲▲");//≥ ≤
            Console.SetCursorPosition(x - 1, y + 1);
            Console.Write(".>ω<");
            Console.ResetColor();
            Console.SetCursorPosition(40, 25);
        }

        public void PrintIndexHead(Cord cord)
        {
            int x = 6 * cord.x + 3;
            int y = 3 * cord.y + 1;


            Console.SetCursorPosition(x, y);
            Console.Write("▲▲");//≥ ≤
            Console.SetCursorPosition(x - 1, y + 1);
            Console.Write(".>ω<");
            Console.SetCursorPosition(40, 25);
        }
        //
        public void PrintIndexHeadTurn(int i, int j, Dir dir)
        {
            int x = 6 * i + 3;
            int y = 3 * j + 1;

            //머리에 회전주려 했으나 안이뻐서 패스
            //Console.SetCursorPosition(x, y);
            //Console.Write(p1[(int)dir]);//≥ ≤
            //Console.SetCursorPosition(x, y+1);
            //Console.Write(p2[(int)dir]);
            //Console.SetCursorPosition(40, 25);

        }

        public void PrintIndexBody(int i, int j)
        {
            int x = 6 * i + 3;
            int y = 3 * j + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("▲▲");//≥ ≤
            Console.SetCursorPosition(x - 1, y + 1);
            Console.Write(".=ω=");
            Console.SetCursorPosition(40, 25);
        }

        public void PrintIndexBody(Cord cord)
        {
            int x = 6 * cord.x + 3;
            int y = 3 * cord.y + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("▲▲");//≥ ≤
            Console.SetCursorPosition(x - 1, y + 1);
            Console.Write(".=ω=");
            Console.SetCursorPosition(40, 25);
        }

        public void PrintIndexEmpty(int i, int j)
        {
            int x = 6 * i + 3;
            int y = 3 * j + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("    ");//≥ ≤
            Console.SetCursorPosition(x, y + 1);
            Console.Write("    ");
            Console.SetCursorPosition(40, 25);
        }

        public void PrintIndexEmpty(Cord cord)
        {
            int x = 6 * cord.x + 3;
            int y = 3 * cord.y + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("    ");//≥ ≤
            Console.SetCursorPosition(x, y + 1);
            Console.Write("    ");
            Console.SetCursorPosition(40, 25);
        }

        public void PrintItem(Cord cord)
        {
            int x = 6 * cord.x + 3;
            int y = 3 * cord.y + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("  ");//≥ ≤
            Console.SetCursorPosition(x, y + 1);
            Console.Write(" ♣");
            Console.SetCursorPosition(40, 25);
        }

        public void PrintItem(int i, int j )
        {
            int x = 6 * i + 3;
            int y = 3 * j + 1;

            Console.SetCursorPosition(x, y);
            Console.Write("  ");//≥ ≤
            Console.SetCursorPosition(x, y + 1);
            Console.Write(" ♣");
            Console.SetCursorPosition(40, 25);
        }

        
    }
}
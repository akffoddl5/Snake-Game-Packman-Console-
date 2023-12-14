using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dowoon
{
    public class FishGame
    {
        public static bool resu;


        public  void fish()
        {
            resu = FishingGame.PlayGame();
            if (resu)
            {  // 성공했을 때
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(10, 60);
                Console.WriteLine(" _____  _  ");
                Console.SetCursorPosition(10, 61);
                Console.WriteLine("/  __ \\| |   ");
                Console.SetCursorPosition(10, 62);
                Console.WriteLine("| /  \\/| |  ___   __ _  _ __ ");
                Console.SetCursorPosition(10, 63);
                Console.Write("| |    | | / _ \\ / _` || '__|");
                Console.SetCursorPosition(10, 64);
                Console.WriteLine("| \\__/\\| ||  __/| (_| || |   ");
                Console.SetCursorPosition(10, 65);
                Console.WriteLine(" \\____/|_| \\___| \\__,_||_|  ");
                Console.ResetColor();
                Thread.Sleep(1500);
                Console.Clear();
            }
            else // 실패했을 때
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;


                Console.SetCursorPosition(10, 60);
                Console.Write(",------. ,---.  ,--.,--.                   ");
                Console.SetCursorPosition(10, 61);
                Console.Write("|  .--- '/  O / |    |                   ");
                Console.SetCursorPosition(10, 62);
                Console.Write("|  --,|  .-.  ||  ||  |                 ");
                Console.SetCursorPosition(10, 63);
                Console.Write("|  |  |  | |     '--.                 ");
                Console.SetCursorPosition(10, 64);
                Console.Write("--'   --' --'--'`-----'               ");
                Console.ResetColor();
                Thread.Sleep(1500);
                Console.Clear();
            }




          



        }


        
    }
}

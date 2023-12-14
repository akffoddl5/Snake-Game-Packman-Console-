using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace SnakeGame
{
    public class Cord
    {
        public int x;
        public int y;

        public Cord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


    }

    public enum Dir
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3,
    }
    public class GameManager
    {
        Map mp = new Map();
        public int[,] player_arr = new int[10, 7];
        public int[,] item_arr = new int[10, 7];
        public List<Cord> player_list = new List<Cord>();
        public List<Cord> item_list = new List<Cord>();
        Dir current_dir;
        int item_max;
        public bool isGameOver;
        int[] p1 = { 0, 0, -1, 1 };
        int[] p2 = { -1, 1, 0, 0 };

        [DllImport("msvcrt")]
        static extern int _getch();
        [DllImport("msvcrt")]
        static extern int _kbhit();

        public void Init()
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.SetBufferSize(80, 80);
            //Console.SetWindowSize(80, 40);

            //맵 그리고
            mp.BaseMap();

            //아이템 갯수 설정
            item_max = 5;
            for (int i = 0; i < item_max; i++)
            {
                Item_add();
            }

            //3,2부터 오른쪽으로 시작
            current_dir = Dir.RIGHT;
            player_list.Add(new Cord(3, 2));
            player_list.Add(new Cord(3, 2));
            player_list.Add(new Cord(3, 2));
            


        }

        public void Fail()
        {
            isGameOver = true;
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.SetCursorPosition(3, 3);
            Console.WriteLine(",------. ,---.  ,--.,--.                   ");
            Console.WriteLine("|  .--- '/  O / |  ||  |                   ");
            Console.WriteLine("|  `--,|  .-.  ||  ||  |                 ");
            Console.WriteLine("|  |`  |  | |  ||  || '--.                 ");
            Console.WriteLine("`--'   `--' `--'`--'`-----'               ");
            


            Console.SetCursorPosition(10, 10);
            Console.Write(",------. ,---.  ,--.,--.                   ");
            Console.SetCursorPosition(10, 11);
            Console.Write("|  .--- '/  O / |  ||  |                   ");
            Console.SetCursorPosition(10, 12);
            Console.Write("|  `--,|  .-.  ||  ||  |                 ");
            Console.SetCursorPosition(10, 13);
            Console.Write("|  |`  |  | |  ||  || '--.                 ");
            Console.SetCursorPosition(10, 14);
            Console.Write("`--'   `--' `--'`--'`-----'               ");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void Clear()
        {
            isGameOver = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("  ______  __       _______     ___      .______ ");
            Console.WriteLine(" /      ||  |     |   ____|   /   \\     |   _  \\     ");
            Console.WriteLine("|  ,----'|  |     |  |__     /  ^  \\    |  |_)  | ");
            Console.WriteLine("|  `----.|  `----.|  |____ /  _____  \\  |  |\\  \\----.");
            Console.WriteLine(" \\______||_______||_______/__/     \\__\\ | _| `._____|");

 


            Console.SetCursorPosition(10, 10);
            Console.WriteLine("  ______  __       _______     ___      .______ ");
            Console.SetCursorPosition(10, 11);
            Console.WriteLine(" /      ||  |     |   ____|   /   \\     |   _  \\     ");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("|  ,----'|  |     |  |__     /  ^  \\    |  |_)  | ");
            Console.SetCursorPosition(10, 13);
            Console.Write("|  |`  |  | |  ||  || '--.                 ");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("|  `----.|  `----.|  |____ /  _____  \\  |  |\\  \\----.");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public bool Bound_check(Dir dir)
        {
            //머리의 넥스트만 검사 하면됨.
            int next_X = player_list[0].x + p1[(int)dir];
            int next_Y = player_list[0].y + p2[(int)dir];
            if (next_X < 0 || next_Y < 0 || next_X > 9 || next_Y > 6)
            {
                return false;
            }

            for (int i = 0; i < player_list.Count; i++)
            {
                if (player_list[i].x == next_X && player_list[i].y == next_Y)
                {
                    return false;
                }
            }



            return true;
           
        }

        public void Move_player(Dir dir)
        {
            current_dir = dir;
            int next_X = player_list[0].x + p1[(int)dir];
            int next_Y = player_list[0].x + p2[(int)dir];

            //바운드, 몸닿기 검사
            if (!Bound_check(dir))
            {
                Fail();
                return;
            }

            //아이템 판별 and 먹기 and 리스트 추가
            CheckItem(dir);

            //사과 싹다 그리기 리셋
            PrintItemAll();

            //마지막 그림 없애고 이동하는 머리 그림 없애고 추가하고     (중간에 인덱스 1번짜리 머리-> 몸으로 바꿔야될듯 한다면 꼬리 없애기 전 첫번쨰로 해야함)
            mp.PrintIndexEmpty(player_list[player_list.Count - 1]);
            mp.PrintIndexEmpty(player_list[0]);
            mp.PrintIndexBody(player_list[0]);

            mp.PrintIndexHead(player_list[0].x + p1[(int)dir], player_list[0].y + p2[(int)dir]);
            //이동하고
            Pull_player(dir);
            //아이템 판별 한번더?
            CheckItem(dir);
            //꼬리그리고
            mp.PrintIndexBody(player_list[player_list.Count - 1]);

        }

        public void PrintItemAll()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < item_list.Count; i++)
            {
                mp.PrintItem(item_list[i]);
            }
            Console.ResetColor();
        }

        public void CheckItem(Dir dir) {
            int next_X = player_list[0].x + p1[(int)dir];
            int next_Y = player_list[0].y + p2[(int)dir];
            int checked_idx = -1;
            for (int i = 0; i < item_list.Count; i++)
            {
                if (next_X == item_list[i].x && next_Y == item_list[i].y)
                {
                    checked_idx = i;
                }
            }
            

            if (checked_idx >= 0)
            {
                item_list.RemoveAt(checked_idx);
                player_list.Add(new Cord(player_list[player_list.Count - 1].x, player_list[player_list.Count - 1].y));
                //Console.WriteLine()
            }

            if (item_list.Count < item_max)
            {
                Item_add();
            }
        }

        public void Item_add()
        {
            Random a = new Random();
            
            int t = 200;
            int random_x = -1;
            int random_y = -1;
            bool success = false;
            
            while (t > 0)
            {
                t--;
                random_x = a.Next(0, 9);
                random_y = a.Next(0, 6);
                //일단 플레이어랑 겹치면 안댐
                //그리고 지금 아이템이랑 겹치면 안댐
                bool need_contue = false;
                for (int i = 0; i < item_list.Count; i++)
                {
                    if (item_list[i].x == random_x && item_list[i].y == random_y) need_contue = true;
                }

                for (int i = 0; i < player_list.Count; i++)
                {
                    if (player_list[i].x == random_x && player_list[i].y == random_y)
                    {
                        need_contue = true;
                    }
                }

                if (need_contue) continue;

                success = true;
                break;

            }

            if (t > 0 && success && random_x >= 0 && random_y >= 0)
            {
                item_list.Add(new Cord(random_x, random_y));

            }
        }

        public void Pull_player(Dir dir)
        {
            for (int i = player_list.Count - 1; i > 0; i--)
            {
                player_list[i].x = player_list[i - 1].x;
                player_list[i].y = player_list[i - 1].y;
            }

            player_list[0].x += p1[(int)dir];
            player_list[0].y += p2[(int)dir];


        }

        public int IsGameClear()
        {
            if (player_list.Count == 70)
            {
                Clear();
                return 1;
            } else if (isGameOver) {
                return 2;
            }
            return 3;
        }

        public int Progress()
        {
            int cur_timer = Environment.TickCount;
            
            while (true)
            {
                int game_state = IsGameClear();
                if (game_state == 1)
                {
                    return 1;
                } else if (game_state == 2) {
                    return 2;
                }
                

                if (cur_timer + 200 > Environment.TickCount)
                {
                    continue;
                }
                else
                {
                    cur_timer = Environment.TickCount;
                }
                int input;
                if (_kbhit() != 0)
                {
                    input = _getch();
                    if (input == 224)//음... 방향키 누르면 224먼저 입력받드라구여 2개 받음
                    {
                        input = _getch();
                    }

                    switch (input)
                    {
                        case 72:
                            Move_player(Dir.UP);
                            break;
                        case 80:
                            Move_player(Dir.DOWN);
                            break;
                        case 75:
                            Move_player(Dir.LEFT);
                            break;
                        case 77:
                            Move_player(Dir.RIGHT);
                            break;

                    }

                }
                else
                {
                    Move_player(current_dir);
                }

                


            }

        }

    }
}
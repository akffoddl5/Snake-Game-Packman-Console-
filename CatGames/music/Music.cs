using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Xml;

namespace June_team
{
   
    public class Music
    {

        public static bool re;


        public  void music()
        {
            Source Source = new Source(); // 소스 객체 생성
            Arrow arrow = new Arrow(); //화살표 객체 생성
            Console.Clear();
            Source.opening(); // 오프닝 출력


            Console.Clear();
            Console.WriteLine("난이도를 선택해주세요");
            Console.WriteLine("======================================");
            Console.WriteLine("1: 초급    2: 중급   3: 고급   4: 초월");
            Console.WriteLine("======================================");
            int Level = 500; // 레벨에 따라서 출력 속도 달리함.
            int GameRepeat = 0; //while문이 한번 반복 될 때 마다 출력 횟수 증가
            int LevelInput = int.Parse(Console.ReadLine());
            if (LevelInput == 1)
                Level = 1200;
            if (LevelInput == 2)
                Level = 800;
            if (LevelInput == 3)
                Level = 400;
            if (LevelInput == 4)
                Level = 100;
            Random random = new Random();
            while (true)
            {

                List<int> list = new List<int>();
                {

                }



                GameRepeat += 1;
                for (int i = 0; i < GameRepeat; i++) // 문제 출력
                {
                    Console.Clear();

                    int j = random.Next(1, 4);

                    list.Add(j);
                    if (list[i] == 1)
                    {
                        Console.WriteLine(arrow.up);
                        Console.Beep(262, 200);

                    }
                    else if (list[i] == 2)
                    {
                        Console.WriteLine(arrow.down);
                        Console.Beep(294, 200);

                    }
                    else if (list[i] == 3)
                    {
                        Console.WriteLine(arrow.left);
                        Console.Beep(330, 200);

                    }
                    else if (list[i] == 4)
                    {
                        Console.WriteLine(arrow.right);
                        Console.Beep(349, 200);

                    }
                    Thread.Sleep(Level);
                }

                Console.Clear();

                Console.WriteLine("go!");



                List<int> list2 = new List<int>();
                {
                }
                ConsoleKeyInfo c;
                do
                {
                    c = Console.ReadKey();
                    Console.Clear();
                    switch (c.Key)
                    {
                        case ConsoleKey.UpArrow:
                            list2.Add(1);
                            Console.WriteLine(arrow.up);
                            Console.Beep(262, 200);
                            break;
                        case ConsoleKey.DownArrow:
                            list2.Add(2);
                            Console.WriteLine(arrow.down);
                            Console.Beep(294, 200);
                            break;
                        case ConsoleKey.LeftArrow:
                            list2.Add(3);
                            Console.WriteLine(arrow.left);
                            Console.Beep(330, 200);
                            break;
                        case ConsoleKey.RightArrow:
                            list2.Add(4);
                            Console.WriteLine(arrow.right);
                            Console.Beep(349, 200);
                            break;
                    }

                } while (c.Key != ConsoleKey.Enter);


                bool result = Enumerable.SequenceEqual(list, list2);

                Console.Clear();
                Console.WriteLine("정답? " + result);
                Thread.Sleep(1000);
                Console.Clear();

                if (GameRepeat > 5)
                {
                    Console.WriteLine("GAME CLEAR!");
                    Console.WriteLine("잠시 후 메인 화면으로 돌아갑니다.");
                    Thread.Sleep(2000);
                    re = true;
                    break;

                }

                if (result == true)
                {
                    Console.WriteLine("정답입니다!");
                    Thread.Sleep(1000);
                    Console.WriteLine("다음 문제~~");
                    continue;
                }

                else if (result == false)
                {
                    re = result;
                    break;

                }

            }









        }
        //public int Progress()
        //{
        //    while (true)
        //    {
        //        int game_state = IsGameClear();
        //        if (game_state == 1)
        //        {
        //            return 1;
        //        }
        //        else if (game_state == 2)
        //        {
        //            return 2;
        //        }


        //        if (cur_timer + 200 > Environment.TickCount)
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            cur_timer = Environment.TickCount;
        //        }
        //    }

        //}

        //public int IsGameClear()
        //{
        //    if (player_list.Count == 70)
        //    {
        //        Clear();
        //        return 1;
        //    }
        //    else if (isGameOver)
        //    {
        //        return 2;
        //    }
        //    return 3;
        //}
    }
}
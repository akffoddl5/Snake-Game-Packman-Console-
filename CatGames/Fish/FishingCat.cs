using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



// To do 
// Fishing Rod 클래스를 만들어서 분리시키기
// m_isThrowRod 일 떄 [갈고리가 물고기와 닿지 않았다면 -> 맵 배열을 가져와서 이동할좌표에 물고기가 있는지 체크]  
// 잡았으면 거기서 스탑, 일정 시간 뒤 다시 isFishingAble 상태 ,  

namespace Dowoon
{
    public enum State
    {
        Idle,
        Fishing,
        Minigame,

    }



    public class FishingCat
    {
        private static System.Timers.Timer aTimer;
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        public int m_posX = 0, m_posY = 3;

        public int m_RodX = 12, m_RodY = 3, m_RodLength = 1, m_RodThrowPos = 0, m_RodHookYPos;
        public int m_maxGauge = 10, m_gauge = 0;

        public bool m_isFishingAble = true, m_isThrowRod, m_isUp = false;
        public bool m_isMaxGuage = false;
        public bool m_isStartFishingMinigame = false;
 
        public int chance = 7; // << 찬스를 chance = 7; 다시 돌려놓기
        public int catchFish = 0;
        public int needFish = 5;
        int curr = Environment.TickCount;
        State state = State.Idle;
        Fish targetFish = null;




        public void Play()
        {
            CleanScreen();
            DownRod();
            MoveRod();
            DrawRod();     
            GuageButtoninput();
    
            if (m_isStartFishingMinigame)
            {
                Minigame();
            }


            switch(state)
            {
                case State.Idle:
                    RenderIdle();
                    break;
                case State.Fishing:
                     RenderThrow();
                    CollideCheck();
                    break;
                case State.Minigame:
                    RenderMiniGame();
                    break; ;
            }

            Console.SetCursorPosition(20, 0);
            Console.Write(" 남은 기회: 【{0}】", chance);
            Console.SetCursorPosition(20, 1);
            Console.Write(" 잡은 물고기 수: 【{0}】", catchFish);

        }



        public void GetArmPosition(out int x, out int y)
        {
            x = m_posX + 3;
            y = m_posY + 3;
        }

        
       public bool CheckGameEnd()
        {
            
                if (catchFish >= needFish)
                    return true;
             

                    return false;
   
        }

        void RenderIdle()
        {

            if (m_isFishingAble)
                RenderGauge();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(m_posX, m_posY);
            Console.WriteLine("    ∧_∧  ");
            Console.SetCursorPosition(m_posX, m_posY + 1);
            Console.WriteLine("  ( ´A`) ____");
            Console.SetCursorPosition(m_posX, m_posY + 2);
            Console.WriteLine("   つ つ/   |");
            Console.SetCursorPosition(m_posX, m_posY + 3);
            Console.WriteLine("   し`Ｊ    ¿");
            Console.SetCursorPosition(m_posX, m_posY + 4);
            Console.WriteLine("■■■■■■■■■■");

            Console.ForegroundColor = ConsoleColor.White;
        }
        void RenderMiniGame()
        {


            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(m_posX, m_posY);
            Console.Write("    ∧_∧  ");
            Console.SetCursorPosition(m_posX, m_posY + 1);
            Console.Write("  (｀A´ ) ____");


            for (int i = 0; i < m_gauge; ++i)
            {
                Console.Write("__");
            }

            Console.SetCursorPosition(m_posX, m_posY + 2);
            Console.Write("   つ つ/   ");

            Console.SetCursorPosition(m_posX, m_posY + 3);
            Console.Write("   し`Ｊ    ");

            Console.SetCursorPosition(m_posX, m_posY + 4);
            Console.Write("■■■■■■■■■■");

            Console.ForegroundColor = ConsoleColor.White;
        }
        void CleanScreen()
        {

            Console.SetCursorPosition(m_posX, m_posY - 1);
            Console.Write("                                          ");
            Console.SetCursorPosition(m_posX, m_posY);
            Console.Write("                                         ");
            Console.SetCursorPosition(m_posX, m_posY + 1);
            Console.Write("                                           ");
            Console.SetCursorPosition(m_posX, m_posY + 2);
            Console.Write("                                          ");
            Console.SetCursorPosition(m_posX, m_posY + 3);
            Console.Write("                                          ");


        }

        void RenderThrow()
        {
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(m_posX, m_posY);
            Console.Write("    ∧_∧  ");
            Console.SetCursorPosition(m_posX, m_posY + 1);
            Console.Write("  ( ´A` ) ____");


            for (int i = 0; i < m_gauge; ++i)
            {
                Console.Write("__");
            }

            Console.SetCursorPosition(m_posX, m_posY + 2);
            Console.Write("   つ つ/   ");

            Console.SetCursorPosition(m_posX, m_posY + 3);
            Console.Write("   し`Ｊ    ");

            Console.SetCursorPosition(m_posX, m_posY + 4);
            Console.Write("■■■■■■■■■■");

            Console.ForegroundColor = ConsoleColor.White;


        }


        void RenderGauge()
        {

            if (m_isFishingAble)
            {
                Console.SetCursorPosition(m_posX, m_posY - 1);
                Console.Write("【");

                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < m_gauge; ++i)
                {
                    Console.Write("■");
                }
                Console.SetCursorPosition(m_posX + 12, m_posY - 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" 】");


                if (m_isMaxGuage)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(m_posX + 15, m_posY - 1);
                    Console.Write(" Max!!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public void MoveRod()
        {
            if (m_isThrowRod)
            {
                int nKey = 0;
                FishingGame.RendererClear(m_RodThrowPos + 2, 35, m_RodThrowPos - 2, 0);
                if (Console.KeyAvailable)
                {
                    nKey = _getch();

                    switch (nKey)
                    {
                        case 75:
                            if (m_gauge > 0)
                                m_gauge -= 1;
                            break;
                        case 77:
                            if (m_gauge <= 10)
                                m_gauge += 1;
                            break;
                        default:
                            break;

                    }

                }
            }

        }
        public void GuageButtoninput()
        {
            if (m_isFishingAble)
            {
                int nKey = 0;

                if (Console.KeyAvailable)
                {
                    nKey = _getch();

                    if (nKey == 13)
                    {
                        if (m_gauge != m_maxGauge)
                        {
                            m_gauge += 1;

                            if (m_gauge >= m_maxGauge)
                            {
                                m_isMaxGuage = true;
                                m_isThrowRod = true;
                                m_isFishingAble = false;
                                m_RodThrowPos = m_RodX + (m_gauge * 2);
                                state = State.Fishing;
                            }
                        }


                    }

                    if (nKey == 101 || nKey == 69)
                    {
                        m_isThrowRod = true;
                        m_isFishingAble = false;
                        m_RodThrowPos = m_RodX + (m_gauge * 2);
                        state = State.Fishing;
                    }
                }
            }

        }

        public void DownRod()
        {
            

            if (m_isThrowRod)
            {
                if (curr + 100 < Environment.TickCount)
                {
                    curr = Environment.TickCount;
                    m_RodThrowPos = m_RodX + m_gauge * 2;
                    FishingGame.RendererClear(m_RodThrowPos + 2, 37, m_RodThrowPos - 2, 0);


                    if (m_RodLength <= 38 && !m_isUp)
                    {
                        m_RodLength++;

                        if (m_RodLength >= 38)
                        {
                            m_RodLength = 38;
                            m_isUp = true;
                        }

                    }

                    if (m_isUp && m_RodLength >= 1)
                    {
                        m_RodLength--;

                        if (m_RodLength <= 4)
                        {

                            m_isThrowRod = false;
                            m_isMaxGuage = false;
                            m_gauge = 0;
                            m_isFishingAble = true;
                            m_isUp = false;
                            state = State.Idle;
                            chance -= 1;
                        }


                    }
                }
            }
        }

        public void DrawRod()
        {
            if (m_isThrowRod || m_isStartFishingMinigame)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                FishingGame.RendererClear(m_RodThrowPos + 1, 37, m_RodThrowPos - 1, 0);
                for (int i = m_RodY + 2; i < m_RodLength; ++i)
                {
                    m_RodThrowPos = m_RodX + m_gauge * 2;
                    Console.SetCursorPosition(m_RodThrowPos, i);
                    Console.Write(" l");
                    if (i == m_RodLength - 1)
                    {
                        Console.SetCursorPosition(m_RodThrowPos, i);
                        m_RodHookYPos = i;
                        Console.Write(" ¿");
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;





            }
        }

        //public void FishingGauge()
        //{
        //    int nKey = 0;

        //    if (Console.KeyAvailable)
        //    {
        //        nKey = _getch();

        //        if (nKey == 13)
        //        {
        //            if (m_gauge != m_maxGauge)
        //            {
        //                m_gauge += 1;

        //                if (m_gauge >= m_maxGauge)
        //                {
        //                    m_isMaxGuage = true;
        //                    m_isThrowRod = true;
        //                    m_isFishingAble = false;
        //                    m_RodThrowPos = m_RodX + (m_gauge * 2);
        //                    state = State.Fishing;
        //                }
        //            }


        //        }
        //        else if (nKey == 69 || nKey == 101)
        //        {
                 
        //            m_isThrowRod = true;
        //            m_isFishingAble = false;
        //            m_RodThrowPos = m_RodX + (m_gauge * 2);
        //            state = State.Fishing;
        //        }
        //    }
        //}

        public  void CollideCheck()
        {
            Fish _target = null;
            if (m_isThrowRod)
            _target =  Map.GetFish_InMap(m_RodThrowPos  , m_RodHookYPos + Map.offsetY);

            if (_target != null)
            {
           
                targetFish = _target;
                m_isStartFishingMinigame = true;
                state = State.Minigame;
                m_isThrowRod = false;


                    targetFish.direction = Direction.Up;
                    FishingGame.RendererClear(targetFish.m_posX + 5, targetFish.m_posY + 2,
                        targetFish.m_posX - 5, targetFish.m_posY - 2);

                targetFish.m_posX = m_RodThrowPos;
                targetFish.m_posY = m_RodHookYPos;
                
                    targetFish.isCatched = true;
                

            }
        }

        public void Minigame()
        {
        

           
            int nKey = 0;
            if (Console.KeyAvailable)
            {
                nKey = _getch();

                switch (nKey)
                {

                    case 'e':                
                    case 'E':
                        m_RodLength--;
                        targetFish.m_posY--;
                        FishingGame.RendererClear(m_RodThrowPos + 2, 35, m_RodThrowPos - 2, 0);

                        if(targetFish.m_posY <= 7)
                        {
                            targetFish.m_posX = 666;
                            targetFish.m_posY = 666;
                            targetFish.isDead = true;
                            targetFish = null;
                            state = State.Idle;
                            m_isFishingAble = true;
                            m_isStartFishingMinigame = false;
                            m_gauge = 0;
                            m_isThrowRod = false;
                            m_isMaxGuage = false;
                            catchFish++;
                            chance--;


                        }
                        break;
                    default:
                        break;

                }

            }
        }

    }



}
    


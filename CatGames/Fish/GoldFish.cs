using Dowoon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dowoon
{
     
    public class GoldFish : Fish
    {
        public override void Swim()
        {
          //  FishingGame.RendererClear(40,40,10,10);
          
            

            if (curr + 100 < Environment.TickCount && !isCatched )
            {
                curr = Environment.TickCount;
                switch (direction)
                {
                    case Direction.Left:
                        for (int i = 0; i < tale_LEFT.Length + 1; ++i)
                        {
                            Console.SetCursorPosition(m_posX + i, m_posY);
                            Console.Write(" ");
                        }
                        m_posX -= 1;
                    
                        if (m_posX <= Map.offsetX)
                        { 
                            m_posX += tale_RIGHT.Length+1;
                            direction = Direction.Right;
                        }
                     
                        break;
                    case Direction.Right:
                        for (int i = 0; i < tale_RIGHT.Length + 1; ++i)
                        {
                            Console.SetCursorPosition(m_posX - i, m_posY);
                            Console.Write(" ");
                        }
                        m_posX += 1;
                    
                        if (m_posX >=Map.nRow +7)
                        {            
                            m_posX -= tale_LEFT.Length-1;
                            direction = Direction.Left;
                        }
            
                        break;

                }
               

            }
        }

        //<*)◁
        public override void SetTale()
        {
            tale_LEFT = new char[3];
            tale_RIGHT = new char[3];
            tale_UP = new char[3];

            tale_LEFT[0] = '*';
           tale_LEFT[1] = ')';
           tale_LEFT[2] = '▷';

         
            tale_RIGHT[0] = '*';
            tale_RIGHT[1] = '(';
            tale_RIGHT[2] = '◁';

            tale_UP[0] = '*';
            tale_UP[1] = '⌒';
            tale_UP[2] = '▽';
         



        }

    }
}

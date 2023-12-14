using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dowoon
{
    public enum Direction
    {
        Right,
        Left,
        Up,
    }
    public abstract class Fish
    {
        public Direction direction = Direction.Right;
        public Fish instance_self;
        public int m_posX, m_posY;
        public char[] tale_LEFT;
        public char[] tale_RIGHT;
        public char[] tale_UP;
        public int curr = Environment.TickCount;
        public bool isCatched = false;
        public bool isDead = false;

        public abstract void Swim();


        public virtual void Render()
        {
            //  <*)◁
            if (!isDead)
            {
                var offSetX = m_posX;
                var offSetY = m_posY;
                if (tale_LEFT.Length > 0 && tale_RIGHT.Length > 0)
                {

                    switch (direction)
                    {
                        case Direction.Right:
                            Console.SetCursorPosition(offSetX, offSetY);
                            Console.Write(">");
                            Map.SetFishPosition(this, m_posX, m_posY);
                            for (int i = 0; i < tale_RIGHT.Length; i++)
                            {
                                offSetX -= 1;
                                Console.SetCursorPosition(offSetX, offSetY);

                                Console.Write(tale_RIGHT[i]);
                            }
                            break;
                        case Direction.Left:
                            Console.SetCursorPosition(offSetX, offSetY);
                            Console.Write("<");
                            Map.SetFishPosition(this, m_posX, m_posY);
                            for (int i = 0; i < tale_LEFT.Length; i++)
                            {
                                offSetX += 1;
                                Console.SetCursorPosition(offSetX, offSetY);

                                Console.Write(tale_LEFT[i]);
                            }

                            break;
                        case Direction.Up:
                            Console.SetCursorPosition(offSetX, offSetY);
                            Console.Write("▲");

                            Map.SetFishPosition(this, m_posX, m_posY);
                            for (int i = 0; i < tale_UP.Length; i++)
                            {
                                offSetY += 1;
                                Console.SetCursorPosition(offSetX, offSetY);

                                Console.Write(tale_UP[i]);
                            }
                            break;

                    }


                }
            }
        }

        public abstract void SetTale();

        public virtual void InitializeFish()
        {
            instance_self = this;


            Random random = new Random();
            direction = random.Next(0, 2) == 0 ? Direction.Left : Direction.Right;
            SetTale();

            int tmpX = random.Next(13, Map.nRow);
            int tmpY = random.Next(10, Map.nCol + 5);

            m_posX = tmpX;
            m_posY = tmpY;
            Map.SetFishPosition(this, m_posX, m_posY);


        }


    }
}
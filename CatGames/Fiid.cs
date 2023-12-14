using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class Fiid
    {
        
            public int i = 1;
            public int j = 0;
            public string t = "0";
            public bool s = true;

            public void bundery()
            {
                Console.Write("┌");


                for (i = 0; i <= 80; i++)
                {
                    if ((i > 0 && i < 30) || (i > 50 && i < 80))
                    {
                        Console.Write("─");

                    }
                    else if (i > 30 & i < 50)
                    {
                        Console.Write("ω");
                    }
                    else if (i == 80)
                    {
                        Console.WriteLine("┐");

                    }

                }
            }
            public void bundery1()
            {
                for (j = 0; j < 80; j++)
                {
                    if (j == 0)
                        Console.Write("│");
                    else if (j == 78)
                        Console.Write("│");

                    else if (j > 0 && j < 80)
                    {
                        Console.Write(" ");
                    }

                }
            }
            public void bundery2()
            {
                for (j = 0; j < 80; j++)
                {
                    if (j == 0)
                        Console.Write("ω");
                    else if (j == 78)
                        Console.Write("ω");

                    else if (j > 0 && j < 80)
                    {
                        Console.Write(" ");
                    }

                }

                Console.Write("\n");


            }
            public void bundery3()
            {
                for (i = 0; i < 81; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("└");

                    }

                    else if ((i > 0 && i < 30) || (i > 50 && i < 80))
                    {
                        Console.Write("─");

                    }
                    else if (i > 30 & i < 50)
                    {
                        Console.Write("ω");
                    }
                    else if (i == 80)
                    {
                        Console.WriteLine("┘");
                    }
                }

            }

            public string print()
            {
                
               bundery();

                for (i = 0; i < 30; i++)
                {
                    if ((i >= 0 && i < 10) || (i > 20 && i <= 30))
                    {
                        bundery1();
                        Console.Write("\n");
                    }
                    else if (i >= 10 && i <= 20)
                        bundery2();
                }
               bundery3();
                return t;
            }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class Draw
    {
        
        

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            


        }
        


        public string cleanconsole()
        {


            int i;
            int j;



            for (j = 0; j <= 29; j++)
            {
                gotoxy(1, j + 1);
                Console.WriteLine("+");
                for (i = 0; i <= 76; i++)
                {
                    gotoxy(i + 1, j + 1);


                    Console.WriteLine(" ");
             
                }


            }
            return " ";
                   
        }
        public void D_move()
        {

            int input;


          //  while (true)
            //{

                
                //if (Console.KeyAvailable)
                //{
                //    input = Program._getch();
                //    if (input == 224)
                //    {
                       

                //        input = Program._getch();

                //    }


                //    switch (input)
                //    {
                //        case 72:

                //            Player.n_catY -= 1;

                            


                //            break;
                //        case 80:
                //            Player.n_catY += 1;




                //            break;

                //        case 75:
                //            Player.n_catX -= 2;





                //            break;

                //        case 77:
                //            Player.n_catX += 2;




                //            break;

                //        default:
                //            break;

                //    }




                //}

            //}
        }
    

    public void stop()
        {
            
            

            cleanconsole();
                
            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("      ^   ▼▼    ^");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("      (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("      ∪     ▼    ∪");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("      (    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("      ∪          ∪   ");
            Thread.Sleep(100);

        }
    //    public static void C_position()
    //    {
    //        Draw draw = new Draw();
    //        draw.D_move();
            
    //        int n_catX = 25 + nX;
    //        int n_catY = 8 + nY;
            

    //}
    public void Up()
        {
           


            cleanconsole();
            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("      ^   ▼▼   ∩ ^");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("      (       □  )");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("      ∩     ■    ∩");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("      (      □   )");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("      ∪          ∪   ");
            Thread.Sleep(100);
            
        }
        public void Down()
        {
           
            cleanconsole();
            gotoxy(Player.n_catX, Player.n_catY); ;
            Console.Write("∩      ^  ▼▼   ^");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write(" □     (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + +2);
            Console.Write("  ■    つ     ▼   つ");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("     □│    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("       つ         つ   ");
            Thread.Sleep(100);
         

        }
        public void Run()
        {
            

            cleanconsole();

           


            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("  ∩  ^  ▼▼   ^");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  □  (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  ■  ⊂     ▼   つ");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("    □│    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("      ∪       つ   ");


            Thread.Sleep(100); ;
            cleanconsole();

            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  ∩  ^  ▼▼   ^");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  □  (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  ■  ⊂     ▼   つ");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("    □│    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 5);
            Console.Write("      ∪        ∪   ");



            Thread.Sleep(100);
            cleanconsole();

            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("  ∩  ^  ▼▼   ^");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  □  (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  ■  ⊂     ▼   つ");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("    □│    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("      つ        ∪   ");


            Thread.Sleep(100);
            cleanconsole();

            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  ∩  ^  ▼▼   ^");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  □  (= Φ  ω Φ =)");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  ■  ⊂     ▼   つ");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("    □│    ＊    )");
            gotoxy(Player.n_catX, Player.n_catY + 5);
            Console.Write("      ∪        ∪   ");


            Thread.Sleep(100);
           



        }
        public void RunBack()
        {


            cleanconsole();

           

            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("     ^  ▼▼   ^  ∩");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  (= Φ  ω Φ =)  □");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  ⊂     ▼   ∪   ■");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  (    ＊    │ □ ");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("   ⊂        ∪    ");




            Thread.Sleep(100);
            cleanconsole();

            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("     ^  ▼▼   ^  ∩");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  (= Φ  ω Φ =)  □");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  ⊂     ▼   ∪   ■");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("  (    ＊    │ □ ");
            gotoxy(Player.n_catX, Player.n_catY + 5);
            Console.Write("   ∪        ∪    ");



            Thread.Sleep(100);
            cleanconsole();

            gotoxy(Player.n_catX, Player.n_catY);
            Console.Write("     ^  ▼▼   ^  ∩");
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("  (= Φ  ω Φ =)  □");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  ⊂     ▼   ∪   ■");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  (    ＊    │ □ ");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("   ∪        ⊂    ");



            Thread.Sleep(100);
            cleanconsole();
            gotoxy(Player.n_catX, Player.n_catY + 1);
            Console.Write("     ^  ▼▼   ^  ∩");
            gotoxy(Player.n_catX, Player.n_catY + 2);
            Console.Write("  (= Φ  ω Φ =)  □");
            gotoxy(Player.n_catX, Player.n_catY + 3);
            Console.Write("  ⊂     ▼   ∪   ■");
            gotoxy(Player.n_catX, Player.n_catY + 4);
            Console.Write("  (    ＊    │ □ ");
            gotoxy(Player.n_catX, Player.n_catY + 5);
            Console.Write("   ∪        ∪    ");



            Thread.Sleep(100);
           


        }

    }
    
}


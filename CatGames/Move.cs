using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGames
{
    public class Move
    {

        Draw draw = new Draw();
        Collision collision = new Collision();
        //public void M_Position(int R_x,  int L_x, int D_y, int U_y)
        //{
        //    R_x += 2;   
        //    L_x -= 2;
        //    D_y += 1;
        //    U_y -= 1;
        //    draw.gotoxy(0,8+D_y);
        //} //x=25,y=8초기화값
       
        public void M_move()
        { 
           

            int input;


            while (true)
            {
                
               
                if (Console.KeyAvailable)
                {
                    
                        input = Program._getch();
                    if (input == 224)
                    {


                        input = Program._getch();

                    }
                    

                    switch (input)
                    {
                        case 72:

                            
                            draw.Up();
                            Player.n_catY -= 1;
                            collision.collinder();
                            break;

                        case 80:
                            
                            draw.Down();
                            draw.stop();
                            Player.n_catY += 1;
                            collision.collinder();
                            break;

                        case 75:
                           
                            draw.RunBack();
                            Player.n_catX -= 4;
                            collision.collinder();
                            break;

                        case 77:
                            
                            draw.Run();
                            Player.n_catX += 4;
                            collision.collinder();
                            break ;

                        default:
                            draw.stop();
                            collision.collinder();
                            break;


                    }

                    
                }
               
            }
        }
    }
}


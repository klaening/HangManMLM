using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.GFX
{
    public class ASCII
    {
        public static void WelcomeScreen()
        {
            Console.SetWindowSize(153, 30);

            Helpers.Colors.Grey(@"
 HHHHHHHHH     HHHHHHHHH                                                             MMMMMMMM               MMMMMMMM                          
 H:::::::H     H:::::::H                     "); Console.Write("Welcome to"); Helpers.Colors.Grey(@"                              M:::::::M             M:::::::M                           
 H:::::::H     H:::::::H                                                             M::::::::M           M::::::::M                                 
 HH::::::H     H::::::HH                                                             M:::::::::M         M:::::::::M                                
   H:::::H     H:::::H    aaaaaaaaaaaaa   nnnn  nnnnnnnn       ggggggggg   ggggg     M::::::::::M       M::::::::::M  aaaaaaaaaaaaa   nnnn  nnnnnnnn    
   H:::::H     H:::::H    a::::::::::::a  n:::nn::::::::nn    g:::::::::ggg::::g     M:::::::::::M     M:::::::::::M  a::::::::::::a  n:::nn::::::::nn  
   H::::::HHHHH::::::H    aaaaaaaaa:::::a n::::::::::::::nn  g:::::::::::::::::g     M:::::::M::::M   M::::M:::::::M  aaaaaaaaa:::::a n::::::::::::::nn 
   H:::::::::::::::::H             a::::a nn:::::::::::::::ng::::::ggggg::::::gg     M::::::M M::::M M::::M M::::::M           a::::a nn:::::::::::::::n
   H:::::::::::::::::H      aaaaaaa:::::a   n:::::nnnn:::::ng:::::g     g:::::g      M::::::M  M::::M::::M  M::::::M    aaaaaaa:::::a   n:::::nnnn:::::n
   H::::::HHHHH::::::H    aa::::::::::::a   n::::n    n::::ng:::::g     g:::::g      M::::::M   M:::::::M   M::::::M  aa::::::::::::a   n::::n    n::::n
   H:::::H     H:::::H   a::::aaaa::::::a   n::::n    n::::ng:::::g     g:::::g      M::::::M    M:::::M    M::::::M a::::aaaa::::::a   n::::n    n::::n
   H:::::H     H:::::H  a::::a    a:::::a   n::::n    n::::ng::::::g    g:::::g      M::::::M     MMMMM     M::::::Ma::::a    a:::::a   n::::n    n::::n
 HH::::::H     H::::::HHa::::a    a:::::a   n::::n    n::::ng:::::::ggggg:::::g      M::::::M               M::::::Ma::::a    a:::::a   n::::n    n::::n
 H:::::::H     H:::::::Ha:::::aaaa::::::a   n::::n    n::::n g::::::::::::::::g      M::::::M               M::::::Ma:::::aaaa::::::a   n::::n    n::::n
 H:::::::H     H:::::::H a::::::::::aa:::a  n::::n    n::::n  gg::::::::::::::g      M::::::M               M::::::M a::::::::::aa:::a  n::::n    n::::n
 HHHHHHHHH     HHHHHHHHH  aaaaaaaaaa  aaaa  nnnnnn    nnnnnn    gggggggg::::::g      MMMMMMMM               MMMMMMMM  aaaaaaaaaa  aaaa  nnnnnn    nnnnnn
                                                                        g:::::g                                                                      
                                                            gggggg      g:::::g                                                                       
                                                            g:::::gg   gg:::::g                "); Console.Write("Created by: Mattis, Lorin and Mikael"); Helpers.Colors.Grey(@"               
                                                             g::::::ggg:::::::g                                                                      
                                                              gg:::::::::::::g                                                                         
                                                                ggg::::::ggg                                                                            
                                                                   gggggg

");
Helpers.Colors.Green("                                                                    Press Enter to start");

            Display.EnterToStart();
            Console.Clear();
            Console.SetWindowSize(44, 25);
        }

        public static void TenLivesLeft()
        {
            Console.WriteLine(@"











");
        }
        public static void NineLivesLeft()
        {
            Console.WriteLine(@"








        ____________________________
     __/                            \__
  __/                                  \__
");
        }
        public static void EightLivesLeft()
        {
            Console.WriteLine(@"
                __
               |  |
               |  |
               |  |
               |  |
               |  |
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void SevenLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  |
               |  |
               |  |
               |  |
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void SixLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //
               |  |//
               |  |/
               |  |
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void FiveLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //    |
               |  |//     |
               |  |/
               |  |
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void FourLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //    |
               |  |//     |
               |  |/      Q
               |  |
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void ThreeLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //    |
               |  |//     |
               |  |/      Q
               |  |       []
               |  |
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void OneLifeLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //    |
               |  |//     |
               |  |/      Q
               |  |      /[]\
               |  |     ´    `
               |  |
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }

        public static void ZeroLivesLeft()
        {
            Console.WriteLine(@"
                __ ________
               |  |________|
               |  | //    |
               |  |//     |
               |  |/      Q
               |  |      /[]\
               |  |     ´ || `
               |  |       ''
        _______|__|_________________
     __/                            \__
  __/                                  \__
");
        }
    }
}

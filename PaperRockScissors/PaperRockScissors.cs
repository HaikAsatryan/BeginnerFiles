using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginnerFiles
{
    class PaperRockScissors
    {
        
        static string TranslateBot(int translate)
        {
            string translation;
            
            switch(translate)
            {
                case 0:
                    translation = "p";
                    break;
                case 1:
                    translation = "r";
                    break;
                case 2:
                    translation = "s";
                    break;
                default:
                    translation = "Invalid randomizer";
                    break;
            }
            return translation;
        }
        static string BotChoice()
        {
            Random rnd = new Random();
            
            return TranslateBot(rnd.Next(3));
        }
        static int WinCheck(string botMove, string playerMove)
        { 
            if (botMove == "p" && playerMove == "r")
            {
                return 1; //bot wins
            }
            else if (botMove == "r" && playerMove == "s")
            {
                return 1; //bot wins
            }
            else if (botMove == "s" && playerMove == "p")
            {
                return 1; //bot wins
            }
            else if (botMove == "r" && playerMove == "p")
            {
                return 2; //player wins
            }
            else if (botMove == "s" && playerMove == "r")
            {
                return 2; //player wins
            }
            else if (botMove == "p" && playerMove == "s")
            {
                return 2; //player wins
            } else
            {
                return 0; //draw
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is Haik's first mini-game in C#");
            Console.WriteLine("\n\nDo you want start playing paper-rock-scissors");
            int userScore = 0;
            int botScore = 0;
            string [] possibleOptions = {"p", "r", "s" };
            
            while(true)
            {
                Console.Write("Do you want start/continue playing? (y/n): ");
                string playOption = Console.ReadLine();
                if (playOption.ToLower() == "y")
                {
                    while (true)
                    {
                        Console.Write("Please choose \"p\" for paper, \"r\" for rock, \"s\" for scissors and \"q\" for quiting the game: ");
                        string userInput = Console.ReadLine();
                        if (possibleOptions.Contains(userInput))
                        {
                            while (true)
                            {
                                int gameStatus = WinCheck(BotChoice(), userInput);

                                if (gameStatus == 0)
                                {
                                    string drawMsg = "It is draw! \nBot total score is " + botScore + "! Your total score is " + userScore + "!";
                                    Console.WriteLine(drawMsg);
                                    break;
                                }
                                else if (gameStatus == 1)
                                {
                                    botScore++;
                                    string botWinMsg = "Unfortunately, you lost! \nBot total score is " + botScore + "! Your total score is " + userScore + "!";
                                    Console.WriteLine(botWinMsg);
                                    break;
                                }
                                else if (gameStatus == 2)
                                {
                                    userScore++;
                                    string userWinMsg = "Congrats, you won! \nBot total score is " + botScore + "! Your total score is " + userScore + "!";
                                    Console.WriteLine(userWinMsg);
                                    break;
                                }
                                else 
                                {
                                    Console.WriteLine("Error occured during game status check!");
                                    Environment.Exit(0);
                                }
                            }
                        }
                        else if (userInput == "q")
                        {
                            string quitMsg = "Bot total score is " + botScore + "! Your total score is " + userScore + "!";
                            Console.WriteLine(quitMsg);
                            Console.WriteLine("Cya my Friend!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, please try again by following below instructions!");
                            continue;
                        }
                    }
                }
                else if(playOption.ToLower() == "n")
                {
                    Console.WriteLine("Cya my Friend!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please input \"y\" or \"n\" ONLY!");
                    continue;
                }
            }
        }
        
    }
}
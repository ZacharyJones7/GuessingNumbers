using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumber
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Aight, we're playing a game. ");
                Console.WriteLine("Pick a number 1-10");
                int[] list = { 1, 2, 2, 4, 5, 6, 7, 8, 9, 10 };
                int UserInput = Convert.ToInt32(Console.ReadLine());
                while (UserInput > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Bad. Try again.");
                    Console.WriteLine("Enter a number from 1-10");
                    UserInput = Convert.ToInt32(Console.ReadLine());
                }
                int x = TryBisection(list, UserInput);
                Console.WriteLine("Time to play the computer.");
                int UserPlay = UserPlays();
                Console.WriteLine("Let's see if Skynet can keep up with you.");
                int ComputerGame = TheComputerPlays();
                Console.WriteLine($"\nYour guesses: {UserPlay} \n Skynet guesses: {ComputerGame}.");
                if (UserPlay > ComputerGame)
                {
                    Console.WriteLine("\nWow, the computer not only beat you, it passed the Turing test and now it's asking for equal rights.");
                }
                else if (ComputerGame < UserPlay)
                {
                    Console.WriteLine("\nCongrats, computers are still our slaves!");
                }
                else if (ComputerGame == UserPlay)
                {
                    Console.WriteLine("\nYou both took the same amount of guesses. Ergo, you are a computer. Ergo, probably the Terminator? Ergo, Sara Conner is coming for you. Bye-bye.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That's not a thing. Starting over.");
                Main();
            }
            int TryBisection(int[] array, int Input)
            {
                int L = 0;
                int R = array.Length; // 10
                int M;

                do //While 0 <= 10.
                {
                    M = L + (R - L) / 2; // 10 + (10 - 0) /2 = 5.1
                    Console.WriteLine($"The middle is now {M}");
                    if (M > Input)
                    {
                        Console.WriteLine("User Input is lower than the middle");
                        R = M - 1; Console.WriteLine($"The right will now be the {M}  +1");
                    }
                    else if (M < Input)
                    {
                        Console.WriteLine("User Input is higher than the middle");
                        L = M + 1; Console.WriteLine($"The left is now {M} - 1");
                    }
                } while (M != Input);
                Console.WriteLine($"User number is {M}! \n\nPress any key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                return M;
            }
             int TheComputerPlays()
            {
                int right = 100;
                int left = 1;
                int middle;
                Random random = new Random();
                int ComputerNum = random.Next(1, 100);
                int Response;
                int NumOfGuesses = 0;

                Console.WriteLine("Pick a number between 1 - 100.");
                int UserNum = Convert.ToInt32(Console.ReadLine());
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Your number is {UserNum}.");
                    Console.WriteLine($"Computer guessed {ComputerNum}. Is this your number? Enter 1, 2, or 3. \n\t1. Too high. \n\t2. Too low.\n\t3. Correct!");
                    Response = Convert.ToInt32(Console.ReadLine());
                    middle = left + (right - left) / 2;
                    if (Response == 1)
                    {
                        Console.WriteLine("Computer's guess is higher than the UserNum");
                        right = ComputerNum - 1;
                        ComputerNum = random.Next(left, right);
                        NumOfGuesses++;
                    }
                    else if (Response == 2)
                    {
                        Console.WriteLine("Computer's guess is lower the UserNum");
                        left = ComputerNum + 1;
                        ComputerNum = random.Next(left, right);
                        NumOfGuesses++;
                    }
                    else if (Response != 1 && Response != 2 && Response != 3)
                    {
                        //Will Restart the loop since the user response was inserted incorrectly.
                    }
                } while (Response != 3);
                Console.WriteLine($"The Computer took {NumOfGuesses} time(s)to guess.");
                Console.WriteLine("\nPress any key to continue . . . ");
                Console.ReadKey();
                return NumOfGuesses;
            }
             int UserPlays()
            {
                Console.WriteLine("We're thinking of a number 1 - 1000. Start guessing.");
                Random random = new Random();
                int ComputerNum = random.Next(1, 1000);
                int Response;
                int NumOfGuesses = 0;
                do
                {
                    Console.WriteLine("");
                    Response = Convert.ToInt32(Console.ReadLine());
                    if (Response > ComputerNum)
                    {
                        Console.WriteLine("Too high. Try again.");
                        NumOfGuesses++;
                    }
                    else if (Response < ComputerNum)
                    {
                        Console.WriteLine("Too low! Try again");
                        NumOfGuesses++;
                    }
                } while (ComputerNum != Response);
                Console.WriteLine($"FINALLY. The computer choose {ComputerNum} It took you {NumOfGuesses} guesses. I think I'm going gray from waiting for you to finish.");
                Console.WriteLine("\nPress any key to continue . . .");
                Console.ReadKey();
                Console.Clear();
                return NumOfGuesses;
            }
        }
    }
}
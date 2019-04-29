using System;

namespace Mastermind
{
    class Mastermind
    {
        private Random rand = new Random();
        private int[] answer = new int[4];

        public Mastermind()
        {
            Intro();
            Play();
        }

        static void Main(string[] args)
        {
            Mastermind test = new Mastermind();
        }

        public void Intro()
        {
          Console.WriteLine("----------Mastermind----------\n"+
          "A 4-digit number is randomly generated using between 1 and 6\n"+
          "for each digit.  You have 10 attempts to guess the number.\n"+
          "After each attempt, a '-' will be displayed in the position\n"+
          " where a digit is correct but in the wrong position, a '+' where\n"+
          "a digit is correct and in the correct spot, and nothing if the digit\n"+
          "is not correct at all.\n\n");
        }
        public void Play()
        {
            string input;
            bool win;
            int ctr = 0;

            for (int i = 0; i < 4; i++)
                answer[i] = rand.Next(1, 7);

            string output = "";
            foreach (int i in answer)
                output += i + " ";
            //Console.WriteLine("Answer: {0}", output);

            do
            {
                input = GetInput();
                win = CheckForWin(input);
                ctr++;
            }
            while (!win && ctr != 9);

            if (ctr == 9)
            {
                Console.WriteLine("GAME OVER!");
            }
            if (win)
            {
                Console.WriteLine("YOU WIN!");
            }
        }

        private string GetInput()
        {
            bool valid;
            string input;

            do
            {
                Console.WriteLine("Please enter a combination to guess: \n");
                input = Console.ReadLine();
                valid = ValidInput(input);
            }
            while (!valid);

            return input;
        }

        private bool ValidInput(string input)
        {
            bool valid;

            do
            {
                if (input.Length != 4)
                {
                    //Console.WriteLine("\nInput length: {0}", input.Length);
                    Console.WriteLine("\nThat is not a valid guess.");
                    valid = false;
                    return valid;
                }
                else
                {
                    valid = true;
                    return valid;
                }
            }
            while (!valid);
            
        }

        private bool CheckForWin(string input)
        {
            string[] correct = new string[4];
            bool hasWon;

            for (int i = 0; i < input.Length; i++)
            {
                if (Array.Exists(answer, s => s.ToString() == input[i].ToString()))
                {
                    correct[i] = "-";

                    if (input[i].ToString() == answer[i].ToString())
                    {
                        correct[i] = "+";
                    }
                }
                else
                {
                    correct[i] = " ";
                }
            }

            string result = "";
            foreach (string i in correct)
            {
                result += i;
            }

            hasWon = Win(correct);

            Console.WriteLine("{0}\n{1}", input, result);
            return hasWon;
        }

        private bool Win(string[] result)
        {
            int correct = 0;

            for(int i = 0; i < result.Length; i++)
            {
                if (result[i] == "+")
                {
                    correct++;
                }
            }

            if (correct == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

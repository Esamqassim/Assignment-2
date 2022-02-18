using System;
using System.Collections;
using System.Text;

namespace HangManGame2
{
    class Program


    {

        private static string[] books = { "HI", "HOW", "BOOK", "COMPLETE", "FINE", "SUCCESSFULLY", "MORNING" };
        static int MAX_ATTEMPTS = 10;
        static Random random = new Random();
        static string wordSelected;//word selected randdomly
        static char[] charWordSelected;//Temprory array to store each corrected entered letter

        static int letterAttempt;



        static void Main(string[] args)
        {


            StartGame();
            PlayGame();

            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
        }//end Main

        private static string SelectNextWord()
        {

            int x = books.Length;
            return books[random.Next(x)];
        }//SelectNextWord

        private static void StartGame()
        {

            letterAttempt = 0; //Uppdate no. of errors


            wordSelected = SelectNextWord();//word selected randomly            
            charWordSelected = new char[wordSelected.Length];//Get size of charWordSelected array

            for (int i = 0; i < charWordSelected.Length; i++)
            {
                charWordSelected[i] = '_';
                Console.Write(" " + charWordSelected[i]);
            }
            Console.WriteLine("");
        }//End SelectNextWord

        private static bool CheckWord() //Check weather char array identical with wordselected
        {

            return wordSelected.Contains(new String(charWordSelected));
        }//End CheckWord

        private static String UppdatedWordArray() //Create mutable array
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < charWordSelected.Length; i++)
            {
                builder.Append(charWordSelected[i]);
                if (i < charWordSelected.Length - 1)
                    builder.Append(" ");
            }

            return builder.ToString();
        }//End UppdatedWordArray

        private static void WordEnter(string ch)
        {


            if (wordSelected.Contains(ch))
            {
                int index = wordSelected.IndexOf(ch);

                while (index >= 0)
                {
                    charWordSelected[index] = Convert.ToChar(ch.Substring(0));
                    index = wordSelected.IndexOf(ch, index + 1);
                }
            }
            else
            {
                letterAttempt++;
            }



        }//End WordEnter

        static void PlayGame()
        {
            while (letterAttempt < MAX_ATTEMPTS)
            {
                Console.WriteLine("Enter a letter OR guess word : ");
                String guess = Console.ReadLine();

                //check word

                if (guess == wordSelected)
                {
                    Console.WriteLine(" You are winner!");
                    break;
                }

                //check letter
                WordEnter(guess);

                Console.WriteLine("-------STATUS------");//Show the current state
                Console.WriteLine(" Trys left : " + (MAX_ATTEMPTS - letterAttempt));
                Console.WriteLine("Reveald letters:");
                Console.WriteLine(" " + UppdatedWordArray());//Show the current state

                if (!wordSelected.Contains(guess))
                {
                    Console.WriteLine("Wrong letter :" + guess);
                }

                else
                {
                    Console.WriteLine("Wrong letter :");
                }

                if (CheckWord())
                {
                    Console.WriteLine(" You are winner!");
                    break;
                }


                if (letterAttempt == MAX_ATTEMPTS)
                {
                    // user losed
                    Console.WriteLine(" You are loser!");
                    Console.WriteLine(" Word to find was : " + wordSelected);
                }

            }//End while

        }//End PlayGame






    }//End Program class
}//End Namespace

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace HangTheManBurger
{
    class Program
    {
        static string[] bank = { "mcchicken", "mcnuggets", "bigmac", "icecream", "happymeal", 
            "quarterpounder", "eggmcmuffin", "fries", "mcrib", "filetofish", "mcflurry", "soda" , "cheeseburger"};
        static ArrayList wordList = new ArrayList(bank);
        static void Main(string[] args)
        {
            string compuResponse = "";
            do
            {
                Console.Write("*A Mcdonalds employee aproaches you* \n Hello welcome to a game of hanging a man, guess the menu items or else someone get hung \n (1. OPEN THE GAME 2.EXIT) ");
                compuResponse = Console.ReadLine();
                switch (compuResponse)
                {
                    case "1":
                        BurgerTime();
                        break;
                    case "2":
                        break;
                }
            } while (compuResponse != "2");
        }
        static void BurgerTime()
        {
            Random randomItem = new Random((int)DateTime.Now.Ticks);
            string CorrectItem = wordList[randomItem.Next(0, wordList.Count)].ToString();
            string correctwUpper = CorrectItem.ToUpper();
            StringBuilder displayed = new StringBuilder(CorrectItem.Length);
            for (int i = 0; i < CorrectItem.Length; i++)
                displayed.Append('_');
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            string textline;
            int revealedItem = 0;
            int attempts = 5;
            char MenuItemGuessed;
            bool winner = false;

            while (!winner && attempts > 0)
            {
                Console.Write("CHOOSE A LETTER: ");
                textline = Console.ReadLine().ToUpper();
                MenuItemGuessed = textline[0];

                if (correctwUpper.Contains(MenuItemGuessed))
                {
                    correctGuesses.Add(MenuItemGuessed);

                    for (int i = 0; i < CorrectItem.Length; i++)
                    {
                        if (correctwUpper[i] == MenuItemGuessed)
                        {
                            displayed[i] = CorrectItem[i];
                            revealedItem++;
                        }
                    }
                    if (revealedItem == CorrectItem.Length)
                        winner = true;
                }
                else
                {
                    incorrectGuesses.Add(MenuItemGuessed);
                    Console.WriteLine("That letter, '{0}' is not in the menu item, choose better this time", MenuItemGuessed);
                    attempts--;
                }
                Console.WriteLine(displayed.ToString());
            }
            if (winner)
                Console.WriteLine("Congrats sir you are now the burger master");
            else
                Console.WriteLine("You chose the wrong letters! \n a person died because of you! \n '{0}' was the correct word,\n try again, we got another person to hang" , CorrectItem);
            Console.ReadLine();
        }
    }

}
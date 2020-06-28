using System;
using System.Linq;
using System.Threading;

namespace Hangman
{
    class Program
    {
        static void Main()
        {
            string wordToGuess = "Guess".ToUpper();
            char[] maskWordToGuess = new string('*', wordToGuess.Length).ToCharArray();
            string guessedChars = "";
            string currentGuessChar = "";

            string[] messages = {
                @" ____  ____       _       ____  _____   ______  ____    ____       _       ____  _____ 
|_   ||   _|     / \     |_   \|_   _|.' ___  ||_   \  /   _|     / \     |_   \|_   _|
  | |__| |      / _ \      |   \ | | / .'   \_|  |   \/   |      / _ \      |   \ | |  
  |  __  |     / ___ \     | |\ \| | | |   ____  | |\  /| |     / ___ \     | |\ \| |  
 _| |  | |_  _/ /   \ \_  _| |_\   |_\ `.___]  |_| |_\/_| |_  _/ /   \ \_  _| |_\   |_ 
|____||____||____| |____||_____|\____|`._____.'|_____||_____||____| |____||_____|\____|",
                @"   ______                                ___                          
 .' ___  |                             .'   `.                        
/ .'   \_|  ,--.   _ .--..--.  .---.  /  .-.  \ _   __  .---.  _ .--. 
| |   ____ `'_\ : [ `.-. .-. |/ /__\\ | |   | |[ \ [  ]/ /__\\[ `/'`\]
\ `.___]  |// | |, | | | | | || \__., \  `-'  / \ \/ / | \__., | |    
 `._____.' \'-;__/[___||__||__]'.__.'  `.___.'   \__/   '.__.'[___]",
                @"   ______                                         _            __          _    _                            
 .' ___  |                                       / |_         [  |        / |_ (_)                           
/ .'   \_|  .--.   _ .--.   .--./) _ .--.  ,--. `| |-'__   _   | |  ,--. `| |-'__   .--.   _ .--.   .--.     
| |       / .'`\ \[ `.-. | / /'`\;[ `/'`\]`'_\ : | | [  | | |  | | `'_\ : | | [  |/ .'`\ \[ `.-. | ( (`\]    
\ `.___.'\| \__. | | | | | \ \._// | |    // | |,| |, | \_/ |, | | // | |,| |, | || \__. | | | | |  `'.'.  _ 
 `.____ .' '.__.' [___||__].',__` [___]   \'-;__/\__/ '.__.'_/[___]\'-;__/\__/[___]'.__.' [___||__][\__) ))_/
                          ( ( __))                                                                           ",
                @"                                                         _  _  _ 
                                                        | || || |
  _   __   .--.   __   _    _   _   __   .--.   _ .--.  | || || |
 [ \ [  ]/ .'`\ \[  | | |  [ \ [ \ [  ]/ .'`\ \[ `.-. | | || || |
  \ '/ / | \__. | | \_/ |,  \ \/\ \/ / | \__. | | | | | |_||_||_|
[\_:  /   '.__.'  '.__.'_/   \__/\__/   '.__.' [___||__](_)(_)(_)
 \__.'                                                           
"
            };

            string[] counting =
            {
                @" __ 
/_ |
 | |
 | |
 | |
 |_|",
                @" ___  
|__ \ 
   ) |
  / / 
 / /_ 
|____|",
                @" ____  
|___ \ 
  __) |
 |__ < 
 ___) |
|____/ ",
                @" _  _   
| || |  
| || |_ 
|__   _|
   | |  
   |_| ",
                @" _____ 
| ____|
| |__  
|___ \ 
 ___) |
|____/ ",
            };

            int guessingTries = wordToGuess.Length * 2;

            bool gameOver = false;

            Console.CursorVisible = false;

            for (int i = counting.Length; i > 0; i--)
            {
                Console.WriteLine(messages[0]);
                Console.WriteLine(counting[i - 1]);
                Thread.Sleep(1000);
                Console.Clear();
            }

            while (!gameOver)
            {
                Console.WriteLine(messages[0]);
                Console.WriteLine();
                Console.WriteLine($"The word to guess is: {new string(maskWordToGuess)}");
                Console.WriteLine($"Guessed characters: {guessedChars}");
                Console.WriteLine($"You've got: {guessingTries} tries left.");
                Console.WriteLine();

                Console.Write("Your next quess is: ");

                currentGuessChar = Console.ReadLine().ToUpper();
                guessedChars += currentGuessChar + ", ";              

                if (wordToGuess.Contains(currentGuessChar))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == Convert.ToChar(currentGuessChar))
                        {
                            maskWordToGuess[i] = Convert.ToChar(currentGuessChar);
                        }
                    }
                }

                guessingTries--;

                Console.Clear();

                if (guessingTries == 0)
                {
                    gameOver = true;
                    Console.WriteLine(messages[1]);
                }
                else if (!new string(maskWordToGuess).Contains("*"))
                {
                    gameOver = true;
                    Console.WriteLine(messages[2]);
                    Console.WriteLine(messages[3]);
                }
            }
        }



    }
}

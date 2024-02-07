/* Grading rubric
 * Missing class comment block: -5
 * Missing method comment block: -5
 * Missing validation of sStoryNumber numeric: -10
 * Missing validation of sStoryNumber range (1-nLineCount): -5
 * Missing subtracing 1 from nStoryNumber: -5
 * Program doesn't run: -25
 * Incorrect logic to build resultString: -25
 */



using System;
using System.IO;


namespace PE7_MadLibs
{
    // Class: Program
    // Author: David Schuh
    // Purpose: Contains the Mad Libs app
    // Restrictions: None
    static class Program
    {
        // Method: Main
        // Purpose: Mad Lib application
        // Restrictions: c:/templates/MadLibsTemplate.txt must be accessible
        static void Main(string[] args)
        {
            Console.Write("Welcome! Do you want play Mad Libs? (yes/no): ");

            string sPlayGame = null;
            string sUserName = null;

            // Validate responses to only "(y)es" and "(n)o". Display an error if not
            do
            {
                sPlayGame = Console.ReadLine();

                if (!sPlayGame.ToLower().StartsWith("y") && !sPlayGame.ToLower().StartsWith("n"))
                {
                    Console.Write("Please enter either (y)es or (n)o: ");
                }
                else
                {
                    break;
                }
            } while (true);


            if (sPlayGame.ToLower().StartsWith("y"))
            {
                // Read text from the mad libs template
                StreamReader sr = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

                // Count the number of lines in the template
                int nLineCount = 0;
                while (sr.ReadLine() != null)
                {
                    nLineCount++;
                }

                sr.Close();

                // Read text from the mad libs template
                sr = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

                // Populate an array with each line
                string[] aMadLibs = new string[nLineCount];
                string sCurrentLine = null;
                int nCurrentLineNum = 0;

                while ((sCurrentLine = sr.ReadLine()) != null)
                {
                    aMadLibs[nCurrentLineNum] = sCurrentLine;
                    nCurrentLineNum++;
                }

                sr.Close();

                // Ask the user's name
                Console.Write("What is your name? ");
                sUserName = Console.ReadLine();

         start:
                // Collect a number between 1 and the amount of lines. Display an error if incorrect input
                Console.Write($"{sUserName}, choose a story between 1 and {nLineCount}: ");

                string sStoryNumber;
                int nStoryNumber;

                do
                {
                    sStoryNumber = Console.ReadLine();

                    if (!int.TryParse(sStoryNumber, out nStoryNumber) || (nStoryNumber > nLineCount) || (nStoryNumber < 1))
                    {
                        Console.Write($"Error! Enter a whole number between 1 and {nLineCount}: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);


                string resultString = "";

                string[] words = aMadLibs[nStoryNumber - 1].Split(' ');

                foreach (string word in words)
                {
                    // convert newline token "\\n" to newline special character "\n"
                    if (word == "\\n")
                    {
                        resultString += "\n";
                    }
                    else if (word.StartsWith("{"))
                    {
                        // Create the prompt by removing the braces and underscores
                        string sPrompt = word.Replace("{", "").Replace("}", "").Replace("_", " ");

                        Console.Write($"Enter a(n) {sPrompt}: ");
                        resultString += " " + Console.ReadLine();
                    }
                    else
                    {
                        resultString += " " + word;
                    }
                }

                Console.WriteLine(resultString);
                Console.WriteLine();

                Console.Write($"{sUserName}, would you like to play again? ");

                do
                {
                    sPlayGame = Console.ReadLine();

                    if (!sPlayGame.ToLower().StartsWith("y") && !sPlayGame.ToLower().StartsWith("n"))
                    {
                        Console.Write("Please enter either (y)es or (n)o: ");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                if (sPlayGame.ToLower().StartsWith("y"))
                {
                    goto start;
                }
            }

            Console.WriteLine($"Goodbye {sUserName}!");
        }
    }
}

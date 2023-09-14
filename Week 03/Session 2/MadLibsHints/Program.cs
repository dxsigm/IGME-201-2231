using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Madlibs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            string finalStory = "";

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");
            //input = new StreamReader("c:/templates/MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            // prompt the user for which Mad Lib they want to play (nChoice)

            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' ');

            foreach (string word in words)
            {
                // if word is a placeholder
                if (word[0] == '{')
                {
                    string replaceWord = word.Replace("{", "").Replace("}", "").Replace("_", " ");
                    // prompt the user for the replacement
                    Console.Write("Input a {0}: ", replaceWord);
                    // and append the user response to the result string
                    finalStory += Console.ReadLine();
                }
                // else append word to the result string
                else
                {
                    finalStory += word;
                }
            }
        }
    }
}

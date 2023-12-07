using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

// be sure to add the System.Web assembly as a reference
using System.Web;

namespace _20Questions
{
    class BTNode
    {
        // message will either be an object or a question
        // if noNode and yesNode are null then message is an object and this node is a leaf of the tree
        // if noNode and yesNode are not null then message is a question and there are child nodes
        public string message;
        public BTNode noNode;
        public BTNode yesNode;

        public BTNode(string nodeMessage)
        {
            message = nodeMessage;
            yesNode = null;
            noNode = null;
        }

        public void Query()
        {
            if (noNode != null && yesNode != null)
            {
                Console.WriteLine(message);
                Console.Write("Yes or No: ");

                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("y"))
                {
                    yesNode.Query();
                }
                else
                {
                    noNode.Query();
                }
            }
            else
            {
                OnQueryObject();
            }
        }


        public void OnQueryObject()
        {
            Console.Write("Are you thinking of " + message + "? : ");
            string input = Console.ReadLine().ToLower();

            if (input.StartsWith("y"))
            {
                Console.WriteLine("The computer wins!");
                Console.WriteLine();
            }
            else
            {
                UpdateTree();
            }
        }

        public void UpdateTree()
        {
            Console.WriteLine();
            Console.Write("You won!  What were you thinking of?  : ");
            string userObject = Console.ReadLine();

            Console.Write("Please enter a yes/no question to distinguish " + message +
                " from " + userObject + " :  ");
            string userQuestion = Console.ReadLine();

            Console.Write("If you were thinking of " + userObject + ", what would the answer to that question be? : ");
            string input = Console.ReadLine().ToLower();

            if( input.StartsWith("y"))
            {
                this.noNode = new BTNode(message);
                this.yesNode = new BTNode(userObject);
            }
            else
            {
                this.yesNode = new BTNode(message);
                this.noNode = new BTNode(userObject);
            }

            message = userQuestion;

            Console.WriteLine("Thank you, my knowledge has increased!");
            Console.WriteLine();
        }
    }

    static class Program
    {
        static BTNode root = null;

        static void Main(string[] args)
        {
            string s;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;
            string url;


            Console.WriteLine("Welcome to 20 Questions!");
            Console.WriteLine();

            try
            {
                url = "http://people.rit.edu/dxsigm/20q.php?get";

                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                // StreamReader reader = new StreamReader("c:/temp/20q.json");
                s = reader.ReadToEnd();
                reader.Close();

                if( s.Length == 0)
                {
                    throw new Exception();
                }


                s = HttpUtility.UrlDecode(s);

                //tree = new BTTree();
                root = JsonConvert.DeserializeObject<BTNode>(s);
            }
            catch
            {
                Console.WriteLine("Enter a yes/no question about an object: ");
                string question = Console.ReadLine();
                Console.Write("Enter a guess if the response is Yes: ");
                string yesGuess = Console.ReadLine();
                Console.Write("Enter a guess if the response is No: ");
                string noGuess = Console.ReadLine();

                root = new BTNode(question);
                root.yesNode = new BTNode(yesGuess);
                root.noNode = new BTNode(noGuess);
            }

            do
            {
                Console.WriteLine();
                root.Query();

                Console.Write("Play again? : ");
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("n"))
                {
                    break;
                }

            } while (true);

            s = JsonConvert.SerializeObject(root);
            //StreamWriter writer = new StreamWriter("c:/temp/20q.json");
            //writer.Write(s);
            //writer.Close();

            s = HttpUtility.UrlEncode(s);

            url = "http://people.rit.edu/dxsigm/20q.php?set=" + s;

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();
        }
    }
}

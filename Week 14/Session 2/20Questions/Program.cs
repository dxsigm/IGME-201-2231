using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (input.StartsWith("y"))
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
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

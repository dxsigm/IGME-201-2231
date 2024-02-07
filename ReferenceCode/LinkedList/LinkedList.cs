using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LinkedListVisualizer;

namespace LinkedList
{
    public partial class LinkedList : Form
    {
        int cntr = 0;
        int maxItems = 0;
        LinkedList<object> gLinkedList;

        public LinkedList()
        {
            InitializeComponent();

            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            button1.Click += new EventHandler(Button1__Click);
            button2.Click += new EventHandler(Button2__Click);
            button3.Click += new EventHandler(Button3__Click);
            button4.Click += new EventHandler(Button4__Click);
            button5.Click += new EventHandler(Button5__Click);
            button6.Click += new EventHandler(Button6__Click);
        }

        /* Linked List Examples        

       1. Create a Linked List of strings
           LinkedList<string> sentence = new LinkedList<string>();

       2. Create a Linked List from an array of strings
           string[] words =
               { "the", "car", "speeds", "away" };
           LinkedList<string> sentence = new LinkedList<string>(words);

       3. Add new strings to the end of the Linked List
           sentence.AddLast("word");

       4. Add the word 'today' to the beginning of the linked list.
           sentence.AddFirst("today");

       5. Move the first node to be the last node.
           LinkedListNode<string> firstNode = sentence.First;
           sentence.RemoveFirst();
           sentence.AddLast(firstNode);

       6. Change the last node to 'yesterday'
           sentence.RemoveLast();
           sentence.AddLast("yesterday");

       7. Move the last node to be the first node.
           LinkedListNode<string> lastNode = sentence.Last;
           sentence.RemoveLast();
           sentence.AddFirst(lastNode);

       8. Find the last occurence of 'the'.
           LinkedListNode<string> target = sentence.FindLast("the");
           if (target == null)
           {
               // "the" is not found
           }
           else
           {
               // Add 'bright' and 'red' after 'the' (the LinkedListNode named target).
               sentence.AddAfter(target, "red");
               sentence.AddAfter(target, "bright");
           }

       9. Find the 'car' node
           LinkedListNode<string> target = sentence.FindLast("car");

       10. Add 'sporty' and 'red' before 'car':
           sentence.AddBefore(target, "sporty");
           sentence.AddBefore(target, "red");

       11. Keep a reference to the 'car' node
       and to the previous node in the list
           carNode = sentence.Find("car");
           LinkedListNode<string> current = carNode.Previous;

       12. The AddBefore method throws an InvalidOperationException
       if you try to add a node that already belongs to a list.
           try
           {
               // try to add carNode before current
               sentence.AddBefore(current, carNode);
           }
           catch (InvalidOperationException ex)
           {
               Console.WriteLine("Exception message: {0}", ex.Message);
           }


       13. Remove the node referred to by carNode, and then add it
       before the node referred to by current.
           sentence.Remove(carNode);
           sentence.AddBefore(current, carNode);


       14. Add the 'current' node after the node referred to by mark2
           sentence.AddAfter(mark2, current);

       15. The Remove method finds and removes the
       first node that that has the specified value.
           sentence.Remove("red");

       16. Create an array with the same number of
       elements as the inked list.
           string[] sArray = new string[sentence.Count];
           sentence.CopyTo(sArray, 0);

       17. Walk through a Linked List in forward order
           LinkedListNode<object> linkedListNode = linkedList.First;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Next;
           }

       18. Walk through a Linked List in reverse order
           LinkedListNode<object> linkedListNode = linkedList.Last;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Previous;
           }

       19. Change the Value of a node
           linkedListNode.Value = "new value";

       20. Release all the nodes.
           sentence.Clear();

       */



        private void Button1__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            for(int i = 1; i <= 10; ++i)
            {
                linkedList.AddLast(i);
            }

            // 2. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button2__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            for (int i = 1; i <= 10; ++i)
            {
                linkedList.AddLast(i);
            }

            // 2. copy the linkedList to reverseLinkedList in reverse order
            // so that reverseLinkedList goes from 10 to 1
            LinkedList<object> reverseLinkedList = new LinkedList<object>();
            LinkedListNode<object> linkedListNode;

            linkedListNode = linkedList.Last;

            while (linkedListNode != null)
            {
                reverseLinkedList.AddLast(linkedListNode.Value);
                linkedListNode = linkedListNode.Previous;
            };

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(reverseLinkedList);
        }

        private void Button3__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words
            // "the", "fox", "jumped", "over", "the", "dog"
            LinkedList<object> linkedList;
            LinkedListNode<object> linkedListNode;

            string[] s = { "the", "fox", "jumped", "over", "the", "dog" };

            linkedList = new LinkedList<object>(s);

            // 2. add "quick" and "brown" before "fox"
            linkedListNode = linkedList.Find("fox");
            linkedList.AddBefore(linkedListNode, "quick");
            linkedList.AddBefore(linkedListNode, "brown");

            // 3. add "lazy" after the last "the"
            linkedListNode = linkedList.FindLast("the");
            linkedList.AddAfter(linkedListNode, "lazy");

            // 4. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button4__Click(object sender, EventArgs e)
        {
            // create a LinkedList which contains the words
            // Because I'm sad Clap along if you feel like a room without a roof
            // Because I'm sad Clap along if you feel like sadness is the truth sad
            LinkedList<object> linkedList;
            LinkedListNode<object> linkedListNode;
            string[] s = {
              "Because", "I'm", "sad", "Clap", "along", "if", "you", "feel", "like", "a", "room", "without", "a", "roof",
            "Because", "I'm", "sad", "Clap", "along", "if", "you", "feel", "like", "sadness", "is", "the", "truth", "sad"
            };
            linkedList = new LinkedList<object>(s);

            // replace "sad" with "happy"
            // and "sadness with "happiness"
            // note that because Value is an object 
            // you will have to cast Value as a string as follows:
            //     if( (string)linkedListNode.Value == "sad"
            linkedListNode = linkedList.First;

            while (linkedListNode != null)
            {
                if( (string)linkedListNode.Value == "sad" )
                {
                    linkedListNode.Value = "happy";
                }

                if ((string)linkedListNode.Value == "sadness")
                {
                    linkedListNode.Value = "happiness";
                }

                linkedListNode = linkedListNode.Next;
            }

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button5__Click(object sender, EventArgs e)
        {
            // create a LinkedList which contains the following words
            // The Spain in rain falls plain on the mainly
            LinkedList<object> linkedList;
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;
            string[] s = {
                "The", "Spain", "in", "rain", "falls", "plain", "on", "the", "mainly"
            };
            linkedList = new LinkedList<object>(s);

            // manipulate the list using Remove() and AddBefore() or AddAfter() to result in
            // "The rain in Spain falls mainly on the plain"
            linkedListNode1 = linkedList.Find("falls");
            linkedListNode2 = linkedList.Find("Spain");
            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("in");
            linkedListNode2 = linkedList.Find("rain");
            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("on");
            linkedListNode2 = linkedList.Find("mainly");
            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("plain");
            linkedList.Remove(linkedListNode1);
            linkedList.AddLast(linkedListNode1);

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button6__Click(object sender, EventArgs e)
        {
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;

            string[] letters = { "D", "O", "R", "M", "I", "T", "O", "R", "Y" };
            LinkedList<object> anagram = new LinkedList<object>(letters);

            // rearrange the Nodes to spell "DIRTYROOM"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls
            linkedListNode1 = anagram.Find("O");
            linkedListNode2 = anagram.Find("I");
            anagram.Remove(linkedListNode2);
            anagram.AddBefore(linkedListNode1, linkedListNode2);
            //DIORMTORY

            linkedListNode1 = anagram.Find("O");
            linkedListNode2 = anagram.Find("R");
            anagram.Remove(linkedListNode2);
            anagram.AddBefore(linkedListNode1, linkedListNode2);
            //DIROMTORY

            linkedListNode1 = anagram.Find("O");
            linkedListNode2 = anagram.Find("T");
            anagram.Remove(linkedListNode2);
            anagram.AddBefore(linkedListNode1, linkedListNode2);
            //DIRTOMORY

            linkedListNode1 = anagram.Find("O");
            linkedListNode2 = anagram.Find("Y");
            anagram.Remove(linkedListNode2);
            anagram.AddBefore(linkedListNode1, linkedListNode2);
            //DIRTYOMOR

            linkedListNode1 = anagram.Find("O");
            linkedListNode2 = anagram.FindLast("R");
            anagram.Remove(linkedListNode2);
            anagram.AddBefore(linkedListNode1, linkedListNode2);
            //DIRTYROMO

            linkedListNode1 = anagram.Find("M");
            anagram.Remove(linkedListNode1);
            anagram.AddLast(linkedListNode1);
            //DIRTYROOM

            // Your code here
            //foreach ( char c in "DIRTYROOM")
            //{
            //    linkedListNode1 = anagram.Find(c.ToString());
            //    anagram.Remove(linkedListNode1);
            //    anagram.AddLast(linkedListNode1);
            //}

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(anagram);
        }

    }
}

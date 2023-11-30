using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    /// 
    ///  Our Binary Tree Class
    ///
    public class BTree
    {
        //////////////////////////////////////////////////////////
        ///  The most important 3 fields of any Binary Search Tree

        // the "less than" branch off of this node
        public BTree ltChild;

        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        // the data contained in this node
        public object data;
        //////////////////////////////////////////////////////////


        // a boolean to indicate if this is actual data or seed data to prime the tree
        public bool isData;

        // internal counter which is needed by the visualizer
        public int id;

        // access to Form1 to write to the RichTextBox
        public static BTreeForm bTreeForm;

        // keep track of last counter to set this.id
        private static int nLastCntr;


        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree
        public BTree(object nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // set internal id which is used by the visualizer
            this.id = nLastCntr;
            ++nLastCntr;

            PrintThisNode(this);

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int or string data
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data == (string)b.data);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age == bp.age);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data != (string)b.data);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age != bp.age);
                }
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) < 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age < bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) > 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age > bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) >= 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age >= bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) <= 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age <= bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            // if the new node >= the tree node
            if (newNode >= treeNode)
            {
                // if there is not a child node greater than or equal to this tree node
                if (treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise try to add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                // the new node < this tree node
                if (treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise try to add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Delete a node from a tree or branch
        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode)
        {
            // base case: we reached the end of the tree
            if (treeNode == null)
            {
                return treeNode;
            }

            // traverse the tree to find the target node
            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                // this is the node to be deleted  

                // case #1: treeNode has no children
                // case #2: treeNode has one child
                // set treeNode to it's non-null child (if there is one)
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild;
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                // case #3: treeNode has two children
                // Get the in-order successor (smallest value  
                // in the "greater than or equal to" branch)  

                // step to the next greater value
                BTree nextValNode = treeNode.gteChild;

                // while not at the end of the branch
                while (nextValNode != null)
                {
                    // replace this "deleted" node with the next sequential data value
                    treeNode.data = nextValNode.data;

                    // walk to next lower value
                    nextValNode = nextValNode.ltChild;
                }

                // delete the in-order successor (which was copied to the "deleted" node)  
                nodeToDelete.data = treeNode.data;
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Print the contents of this node
        public static void PrintThisNode(BTree node)
        {
            string thisString = null;

            if (node.data.GetType() == typeof(int) ||
                node.data.GetType() == typeof(string))
            {
                thisString = node.data.ToString();
            }

            if (node.data.GetType() == typeof(Person))
            {
                Person person = (Person)node.data;
                thisString = $"{person.age:D03}:{person.name}";
            }

            bTreeForm.richTextBox.Text += " " + thisString;
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        public static void TraverseAscending(BTree node)
        {
            if( node != null)
            {
                TraverseAscending(node.ltChild);

                if( node.isData)
                {
                    PrintThisNode(node);
                }

                TraverseAscending(node.gteChild);
            }
        }
        //////////////////////////////////////////////////////////
        

        //////////////////////////////////////////////////////////
        // Print the tree in descending order
        public static void TraverseDescending(BTree node)
        {
            if (node != null)
            {
                TraverseDescending(node.gteChild);

                if (node.isData)
                {
                    PrintThisNode(node);
                }

                TraverseDescending(node.ltChild);
            }
        }
        //////////////////////////////////////////////////////////
    }

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}

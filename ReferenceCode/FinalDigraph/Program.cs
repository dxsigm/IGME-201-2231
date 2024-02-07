using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UT3_ColorDigraph
{
    enum EColor
    {
    red,
    blue,
    yellow,
    cyan,
    gray,
    purple,
    orange,
    green
    }

    // Class: Node
    // Author: Ajay Ramnarine (orignal code by David Schuh)
    // Purpose: Contains a list of edges belonging to the node as well as a minimum cost to the start and the nearest node to the start
    // Restrictions: None
    public class Node : IComparable<Node>
    {
        public int nColor;

        public List<Edge> edges = new List<Edge>();

        public LinkedListNode<Node> colorLLNode;

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nColor)
        {
            this.nColor = nColor;
            this.minCostToStart = int.MaxValue;
        }

        // Method: AddEdge
        // Purpose: Add an edge based on the connected Nodes and its respective cost
        // Restrictions: None
        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        // Method: CompareTo
        // Purpose: Compares nodes and returns 0, -1, or <0 based on their minCostToStart
        // Restrictions: None
        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    // Class: Edge
    // Author: Ajay Ramnarine (original code by David Schuh)
    // Purpose: Contains the cost and connective Nodes for each Node
    //          Used for Djikstra Shortest Path
    // Restrictions: None
    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        // Method: CompareTo
        // Purpose: Comapre the edges based on their cost
        // Restrictions: None
        public int CompareTo(Edge edge)
        {
            return this.cost.CompareTo(edge.cost);
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create an adjacency matrix and adjacency list for the color digraph from UT3
    //          Use DFS and Dijkstra Shortest Path methods to traverse the digraph
    // Restrictions: None
    static class Program
    {
        // Adjacency Matrix
        // The colors will be written as comments in the matrix and represented by single letters
        // RED = r, BLUE = b, YELLOW = y, CYAN = c, NEUTRAL GRAY = n,  PURPLE = p, ORANGE = o, GREEN = g
        // The numbers in the matrix will represent the edge weight, or the cost it takes to get from one color to the next
        // -1 represents that it is not possible to move from the occupied color (row) to another color (column)
        static int[,] colorMGraph = new int[,]
        {
                        /*r*/   /*b*/   /*y*/   /*c*/   /*n*/   /*p*/   /*o*/   /*g*/
            /*r*/   {    -1,      1,     -1,     -1,      5,     -1,     -1,     -1 },
            /*b*/   {    -1,     -1,      8,      1,     -1,     -1,     -1,     -1 },
            /*y*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,      6 },
            /*c*/   {    -1,      1,     -1,     -1,      0,     -1,     -1,     -1 },
            /*n*/   {    -1,     -1,     -1,      0,     -1,     -1,      1,     -1 },
            /*p*/   {    -1,     -1,      1,     -1,     -1,     -1,     -1,     -1 },
            /*o*/   {    -1,     -1,     -1,     -1,     -1,      1,     -1,     -1 },
            /*g*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1 }
        };

        // Adjacency List
        // Two parallel lists
        // The first list represents the colors and which colors can be traveled to based on position in the list
        // The second list represents the weights associated with moving to another color from the current color
        // The colors will be written as comments in the list and represented by single letters (same letter usage as the Adjacency Matrix above)
        // Since green is not able to travel to another color, its value will be null
        static int[][] colorLGraph = new int[][]
        {
            /*r*/   new int[] {(int)EColor.blue, (int)EColor.gray},
            /*b*/   new int[] {2, 3},
            /*y*/   new int[] {7},
            /*c*/   new int[] {1, 4},
            /*n*/   new int[] {3, 6},
            /*p*/   new int[] {2},
            /*o*/   new int[] {5},
            /*g*/   null
        };

        static int[][] colorWGraph = new int[][]
        { 
            /*r*/   new int[] {1, 5},
            /*b*/   new int[] {8, 1},
            /*y*/   new int[] {6},
            /*c*/   new int[] {1, 0},
            /*n*/   new int[] {0, 1},
            /*p*/   new int[] {1},
            /*o*/   new int[] {1},
            /*g*/   null
        };

        // int for starting color which will start at red
        static EColor eColor = EColor.red;

        // list of Nodes
        static List<Node> colorNodes = new List<Node>();

        // Method: Main
        // Purpose: Call the DFS of the digraph
        //          Call Dijkstra Shortest Path for the digraph from red to green
        //          Create a linked list version of the color digraph
        // Restrictions: None
        static void Main(string[] args)
        {
            string s = EColor.red.ToString();

            /*********************************************************** DFS *****************************************************************************/

            // call the depth first search
            Console.WriteLine("Depth First Search");

            DFS(eColor);

            // create a space between the DFS and Dijkstra Shortest Path
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            /*********************************************************************************************************************************************/

            /***************************************************** DIJKSTRA SHORTEST PATH ****************************************************************/

            // node variable to be used to create the node strucutre based on colorLGraph
            Node node;

            // dynamically create node structure based on colorLGraph
            for (int i = 0; i < colorLGraph.Length; ++i)
            {
                node = new Node(i);
                colorNodes.Add(node);
            }

            // attach the edges to the nodes created in the previous for loop
            for (int i = 0; i < colorLGraph.Length; ++i)
            {
                // point to the neighbors of the current element of colorLGraph
                int[] currentColor = colorLGraph[i];

                // point to the weight of those neighbors from the current color
                int[] currentCosts = colorWGraph[i];

                // if the currentColor is null, then we've reached the last node
                // therefore we run this section as long as currentColor is not null
                if (currentColor != null)
                {
                    // attach the neighbors to the current Node/element of colorLGraph as Edges
                    for (int costCounter = 0; costCounter < currentColor.Length; ++costCounter)
                    {
                        colorNodes[i].AddEdge(currentCosts[costCounter], colorNodes[currentColor[costCounter]]);
                    }

                    // sort the edges of the list
                    colorNodes[i].edges.Sort();
                }
            }

            // call the method to get the shortest path using the Dijkstra method
            List<Node> shortestPath = GetShortestPathDijkstra();

            // print the shortest path to the console
            Console.WriteLine("Dijkstra Shortest Path");

            for (int i = 0; i < shortestPath.Count; ++i)
            {
                Console.Write(NumToColor(shortestPath[i].nColor) + " ");
            }

            Console.WriteLine(" ");

            /*********************************************************************************************************************************************/

            /***************************************************************** LINKED LIST ***************************************************************/

            // create a linked list of nodes for the color digraph
            LinkedList<Node> colorDigraph = new LinkedList<Node>();

            Node color;

            // create the nodes for the linked list through a for loop
            for (int i = 0; i < shortestPath.Count; ++i)
            {
                // create a new node for each color per loop based on the shortest path from Dijkstra
                // this will make sure that the nodes are connected properly in the list
                color = new Node(shortestPath[i].nColor);

                // add that color to the linkedlist of nodes
                colorDigraph.AddLast(color);
            }

            // loop through the colorDigraph to attach secondary nodes 
            LinkedListNode<Node> colorNode = colorDigraph.First;
            LinkedListNode<Node> currentNode = colorDigraph.First;

            while (colorNode != null)
            {
                // check to see if we are at the end of the list
                if (colorLGraph[colorNode.Value.nColor] != null)
                {
                    // check to see if the nodes are already attched in the linked list based on colorLGraph
                    foreach (int colorConnect in colorLGraph[colorNode.Value.nColor])
                    {
                        // checks to see if nodes are already connected
                        if (colorConnect == colorNode.Next.Value.nColor)
                        {
                            continue;
                        }

                        // Continue through the currentNode to find the node with a value equal to colorConnect
                        while (currentNode.Value.nColor != colorConnect && currentNode != null)
                        {
                            currentNode = currentNode.Next;
                        }

                        // if they are not connected then it should connect them via colorLLNode
                        colorNode.Value.colorLLNode = currentNode;
                    }
                }

                // reset currentNode to be the first node for the next part of the while loop
                currentNode = colorDigraph.First;

                // move on to the next node in colorNode
                colorNode = colorNode.Next;
            }

            /*********************************************************************************************************************************************/
        }

        // Method: NumToColor
        // Purpose: Converts the "color" the user is currently located from a number to a string of the color
        // Restrictions: None
        static string NumToColor(int num)
        {
            // color to be returned
            string color = null;

            // set color to a string of the color based on the matrix and list above
            if (num == 0)
            {
                color = "red";
            }
            else if (num == 1)
            {
                color = "blue";
            }
            else if (num == 2)
            {
                color = "yellow";
            }
            else if (num == 3)
            {
                color = "cyan";
            }
            else if (num == 4)
            {
                color = "gray";
            }
            else if (num == 5)
            {
                color = "purple";
            }
            else if (num == 6)
            {
                color = "orange";
            }
            else if (num == 7)
            {
                color = "green";
            }

            // return the color
            return color;
        }


        /***************************************************** DEPTH FIRST SEARCH *********************************************************************/

        // Method: DFS
        // Purpose: Apply the Depth First Search to the created digraph
        // Restrictions: None
        static void DFS(EColor color)
        {
            // boolean to check for colors that have been visited
            bool[] visitedColors = new bool[colorLGraph.Length];

            // call recursive helper method to traverse digraph and to check if visited node or not
            DFSUtil(color, ref visitedColors);
        }

        // Method: DFSUtil
        // Purpose: Will recurse through the graph and visit every node in the graph in a depth first approach
        // Restrictions: None
        static void DFSUtil(EColor nCurrentVertex, ref bool[] visitedColors)
        {
            // set the current vertex to visited in the bool array
            visitedColors[(int)nCurrentVertex] = true;

            // write out what the current state is
            //string currentColor = NumToColor(nCurrentVertex);
            Console.Write(nCurrentVertex.ToString() + " ");

            // recurse for each vertex neighboring the color vertex that was passed in
            int[] thisColorList = colorLGraph[(int)nCurrentVertex];

            // check to see if reached the end of the graph at which the value will be null
            if (thisColorList != null)
            {
                foreach (int n in thisColorList)
                {
                    // if the user has not visited the color, then recursively call DFSUtil passing in the vertex and the referenced bool array
                    if (!visitedColors[n])
                    {
                        DFSUtil((EColor)n, ref visitedColors);
                    }
                }
            }
        }

        /**************************************************************************************************************************************************/


        /****************************************************** DIJKSTRA SHORTEST PATH *******************************************************************/

        /*
            Dijkstra algorithm by Edsger Dijkstra (1959)
        
            1. From start node, add all connected nodes to a queue
            2. Sort the queue by lowest cost and make the first node the current node.
               For every child node, select the best that leads to the shortest path to the start
               When all edges have been investigated from the node, that node is "visited" and you don't need to go there again.
            3. Add each child node connected to the current node to the priority queue
            4. Go to step 2 until the queue is empty
            5. Recursively create a list of each nodes node that leads the shortest path from end to start
            6. Reverse the list and that will be the shortest path
        */

        // Method: GetShortestPathDijkstra
        // Purpose: Returns the shortest path from one node to the other (red to green in this case)
        // Restrictions: None
        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();

            // define shortest path
            List<Node> shortestPath = new List<Node>();

            // add the final node to that path (the green node)
            shortestPath.Add(colorNodes[7]);

            // build the shortest path
            BuildShortestPath(shortestPath, colorNodes[7]);

            // reverse the shortest path to make the shortest path go from start to end
            shortestPath.Reverse();

            // return the path
            return (shortestPath);
        }

        // Method: BuildShortestPath
        // Purpose: Create the path given the list of nodes and the target node
        // Restrictions: None
        static public void BuildShortestPath(List<Node> shortestPath, Node node)
        {
            // check if we are at the starting node
            if (node.nearestToStart == null)
            {
                return;
            }

            // add the node that is nearest to start to the shortestPath list
            shortestPath.Add(node.nearestToStart);

            // recursively call the method
            BuildShortestPath(shortestPath, node.nearestToStart);
        }

        // Method: DijkstraSearch
        // Purpose: Run through the Dijkstra Search method
        // Restrictions: None
        static public void DijkstraSearch()
        {
            // starting at the red node
            Node start = colorNodes[0];

            // we're already at the red node so there is no cost when we start
            start.minCostToStart = 0;

            // create a queue of nodes
            List<Node> priorityQueue = new List<Node>();

            // add starting node to the queue
            priorityQueue.Add(start);

            // sort the queue based on the minimum cost to start
            do
            {
                // sort the queue in place
                priorityQueue.Sort();

                // return copy of priorityQueue based on value chosen to order by
                priorityQueue = priorityQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();

                // set current node to the first element of the queue
                Node node = priorityQueue.First();

                // remove that node from the queue
                priorityQueue.Remove(node);

                // look at each edge attached to that node
                foreach (Edge cnn in node.edges)
                {
                    // set pointer to each of those connected nodes
                    Node childNode = cnn.connectedNode;

                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue || node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;

                        // child nodes link to the start is the current node we are on
                        childNode.nearestToStart = node;

                        // add the child node to the queue if it is not already in the queue
                        if (!priorityQueue.Contains(childNode))
                        {
                            priorityQueue.Add(childNode);
                        }
                    }
                }

                // set node visited to true after going through the edges
                node.visited = true;

                // return once we have reached green, which should be the last color node
                if (node == colorNodes[7])
                {
                    return;
                }
            } while (priorityQueue.Any());

        }

        /**************************************************************************************************************************************************/

    }
}
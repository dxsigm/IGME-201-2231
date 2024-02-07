/// enabled which adjacency test to use: matrix or list
//#define USE_MATRIX

// represent game as directed graph (for AI version) or not (for human player)
//#define DIGRAPH


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;

namespace CoinFlip
{
    static class Program
    {

#if DIGRAPH
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        {
           { false   , true    , false   , false   , true    , false   , false   , false },
           { false   , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , true    , false   , false }
        };

        static int[][] lGraph = new int[][]
        {
            new int[] { 1, 4 },
            new int[] { 3 },
            new int[] { 0 },
            new int[] { 7 },
            new int[] { 6 },
            null,
            new int[] { 7 },
            new int[] { 5 }
        };
#else
        // the adjacency values for the non-directed graph version.  
        // Allow all possible paths
        static bool[,] mGraph = new bool[,]
        {
           { false   , true    , true    , false   , true    , false   , false   , false },
           { true    , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , true    , false   , false   , false   , false   , false   , true  },
           { true    , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , true  },
           { false   , false   , false   , false   , true    , false   , false   , true  },
           { false   , false   , false   , true    , false   , true    , true    , false }
        };

        static int[][] lGraph = new int[][]
        {
            new int[] { 1, 2, 4 },
            new int[] { 0, 3 },
            new int[] { 0 },
            new int[] { 1, 7 },
            new int[] { 0, 6 },
            new int[] { 7 },
            new int[] { 4, 7 },
            new int[] { 3, 5, 6 }
        };
#endif

        static List<Node> game = new List<Node>();

        static bool bWaitingForMove = false;

        // the current numeric representation of the coin state
        static int nState = 0;

        // the user-entered string representation of the desired coin state
        static string sUserState;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;

            node = new Node(0);
            game.Add(node);

            node = new Node(1);
            game.Add(node);

            node = new Node(2);
            game.Add(node);

            node = new Node(3);
            game.Add(node);

            node = new Node(4);
            game.Add(node);

            node = new Node(5);
            game.Add(node);

            node = new Node(6);
            game.Add(node);

            node = new Node(7);
            game.Add(node);

            game[0].AddEdge(1, game[1]);
            game[0].AddEdge(2, game[2]);
            game[0].AddEdge(4, game[4]);
            game[0].edges.Sort();

            game[1].AddEdge(1, game[0]);
            game[1].AddEdge(3, game[3]);
            game[1].edges.Sort();

            game[2].AddEdge(2, game[0]);
            game[2].edges.Sort();

            game[3].AddEdge(3, game[1]);
            game[3].AddEdge(7, game[7]);
            game[3].edges.Sort();

            game[4].AddEdge(4, game[0]);
            game[4].AddEdge(6, game[6]);
            game[4].edges.Sort();

            game[5].AddEdge(7, game[7]);
            game[5].edges.Sort();

            game[6].AddEdge(6, game[4]);
            game[6].AddEdge(7, game[7]);
            game[6].edges.Sort();

            game[7].AddEdge(7, game[3]);
            game[7].AddEdge(7, game[5]);
            game[7].AddEdge(7, game[6]);
            game[7].edges.Sort();

            List<Node> shortestPath = GetShortestPathDijkstra();

            // the current string representation of the coin state
            string sState;
            
            // the user-entered numeric representation of the desired coin state
            int nUserState;

            // count how many moves to win
            int nMoves = 0;

            // start with a random state that is not HTH (the goal)
            while (true)
            {
                nState = rand.Next(0, 8);

                // don't start with HTH
                if (nState != 5)
                {
                    break;
                }
            }

            Thread t = new Thread(DFS);
            t.Start();

            // while not a winner
            while (nState != 5)
            {
                // convert the current numeric state to a string
                sState = NState2SState(nState);

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                //sUserState = Console.ReadLine().ToUpper();

                bWaitingForMove = true;
                while (bWaitingForMove) ;

                nUserState = SState2NState(sUserState);
                Console.WriteLine(sUserState);

#if USE_MATRIX
                if (mGraph[nState, nUserState])
                {
                    nState = nUserState;
                    ++nMoves;
                }
                else
                {
                    Console.WriteLine("That is an invalid move.");
                }
#else
                int[] thisStateList = lGraph[nState];
                bool valid = false;

                if (thisStateList != null)
                {
                    foreach (int n in thisStateList)
                    {
                        if (n == nUserState)
                        {
                            valid = true;
                            nState = nUserState;
                            ++nMoves;
                            break;
                        }
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("That is an invalid move.");
                }
#endif
            }

            Console.WriteLine($"You won in {nMoves} moves!");
            t.Abort();
        }

        // convert the string to the equivalent 2-based integer
        static int SState2NState(string sState)
        {
            int nState = 0;

            // HHT should be converted to 6
            for(int i = 0; i < 3; ++i )
            {
                if( sState[i] == 'H')
                {
                    nState += (1 << (2 - i));
                }
            }

            return (nState);
        }

        // convert the 2-based integer to the equivalent string
        static string NState2SState( int nState)
        {
            string r = null;

            // 6 should be HHT
            for (int i = 0; i < 3; ++i)
            {
                if( (nState & (1 << (2 - i))) != 0 )
                {
                    r += "H";
                }
                else
                {
                    r += "T";
                }
            }

            return (r);
        }

        // A function used by DFS 
        static void DFSUtil(int v, bool[] visited)
        {
            while (!bWaitingForMove) ;

            // Mark the current node as visited 
            // and print it 
            visited[v] = true;

            sUserState = NState2SState(v);
            //Console.Write(v + " ");

            bWaitingForMove = false;

            // Recur for all the vertices 
            // adjacent to this vertex 
            int[] thisStateList = lGraph[v];
            foreach (int n in thisStateList)
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }

        // The function to do DFS traversal. 
        // It uses recursive DFSUtil() 
        static void DFS( )
        {
            // Mark all the vertices as not visited 
            // (set as false by default in c#) 
            bool[] visited = new bool[lGraph.Length];

            // Call the recursive helper function 
            // to print DFS traversal 
            DFSUtil(nState, visited);
        }
        
        /****************************************************************************************
        The Dijkstra algorithm was discovered in 1959 by Edsger Dijkstra.
        This is how it works:
        
        1. From the start node, add all connected nodes to a priority queue.
        2. Sort the priority queue by lowest cost and make the first node the current node.
           For every child node, select the best that leads to the shortest path to start.
           When all edges have been investigated from a node, that node is "Visited" 
           and you don´t need to go there again.
        3. Add each child node connected to the current node to the priority queue.
        4. Go to step 2 until the queue is empty.
        5. Recursively create a list of each nodes node that leads the shortest path 
           from end to start.
        6. Reverse the list and you have found the shortest path
        
        In other words, recursively for every child of a node, measure its distance to the start. 
        Store the distance and what node led to the shortest path to start. When you reach the end 
        node, recursively go back to the start the shortest way, reverse that list and you have the 
        shortest path.
        ******************************************************************************************/

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[5]);
            BuildShortestPath(shortestPath, game[5]);
            shortestPath.Reverse();
            return( shortestPath );
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = game[2];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place
                // and uses the overloaded Node.CompareTo() method
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // to indicate which field to sort by
                // the next 5 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart ).ToList();
                prioQueue = prioQueue.OrderBy( n => n.minCostToStart ).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                //.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }
                      
                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == game[5])
                {
                    return;
                }
            } while (prioQueue.Any());
        }
    }

    public class Node : IComparable<Node>
    {
        public int nState;
        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }
}

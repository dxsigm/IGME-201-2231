/// enabled which adjacency test to use: matrix or list
//#define USE_MATRIX

// represent game as directed graph (for AI version) or not (for human player)
#define DIGRAPH


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;

namespace CoinFlip
{
    enum ECoinState
    {
        TTT,
        TTH,
        THT,
        THH,
        HTT,
        HTH,
        HHT,
        HHH
    }

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
            new int[] { (int)ECoinState.TTH,(int)ECoinState.HTT },
            new int[] { (int)ECoinState.THH },
            new int[] { (int)ECoinState.TTT },
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HHT },
            null,
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HTH }
        };
#else
        // the adjacency values for the non-directed graph version.  
        // Allow all possible paths
        static bool[,] mGraph = new bool[,]
        {
                   // "TTT"     "TTH"    THT       THH       HTT      HTH        HHT       HHH
         /* TTT */  { false   , true    , true    , false   , true    , false   , false   , false },
         /* TTH */  { true    , false   , false   , true    , false   , false   , false   , false },
         /* THT */  { true    , false   , false   , false   , false   , false   , false   , false },
         /* THH */  { false   , true    , false   , false   , false   , false   , false   , true  },
         /* HTT */  { true    , false   , false   , false   , false   , false   , true    , false },
         /* HTH */  { false   , false   , false   , false   , false   , false   , false   , true  },
         /* HHT */  { false   , false   , false   , false   , true    , false   , false   , true  },
         /* HHH */  { false   , false   , false   , true    , false   , true    , true    , false }
        };

        static int[][] lGraph = new int[][]
        {
            /* TTT */ new int[] { (int)ECoinState.TTH, (int)ECoinState.THT, (int)ECoinState.HTT },
            /* TTH */ new int[] { (int)ECoinState.TTT, (int)ECoinState.THH },
            /* THT */ new int[] { (int)ECoinState.TTT },
            /* THH */ new int[] { (int)ECoinState.TTH, (int)ECoinState.HHH },
            /* HTT */ new int[] { (int)ECoinState.TTT, (int)ECoinState.HHT },
            /* HTH */ new int[] { (int)ECoinState.HHH },
            /* HHT */ new int[] { (int)ECoinState.HTT, (int)ECoinState.HHH },
            /* HHH */ new int[] { (int)ECoinState.THH, (int)ECoinState.HTH, (int)ECoinState.HHT }
        };

        static int[][] wGraph = new int[][]
        {
            /* TTT */ new int[] { 1, (int)ECoinState.THT, (int)ECoinState.HTT },
            /* TTH */ new int[] { (int)ECoinState.TTT, (int)ECoinState.THH },
            /* THT */ new int[] { (int)ECoinState.TTT },
            /* THH */ new int[] { (int)ECoinState.TTH, (int)ECoinState.HHH },
            /* HTT */ new int[] { (int)ECoinState.TTT, (int)ECoinState.HHT },
            /* HTH */ new int[] { (int)ECoinState.HHH },
            /* HHT */ new int[] { (int)ECoinState.HTT, (int)ECoinState.HHH },
            /* HHH */ new int[] { (int)ECoinState.THH, (int)ECoinState.HTH, (int)ECoinState.HHT }
        };
#endif

        static List<Node> game = new List<Node>();

        // variable to request DFS() AI for next move
        static bool bWaitingForMove = false;

        // the current numeric representation of the coin state
        static int nState = 0;

        // the user-entered string representation of the desired coin state
        static string sUserState;

        // mutex (mutual exclusive lock) which will give exclusive access to bWaitingForMove
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;

            node = new Node((int)ECoinState.TTT);
            game.Add(node);
            
            node = new Node((int)ECoinState.TTH);
            game.Add(node);
            
            node = new Node((int)ECoinState.THT);
            game.Add(node);
            
            node = new Node((int)ECoinState.THH);
            game.Add(node);
            
            node = new Node((int)ECoinState.HTT);
            game.Add(node);
            
            node = new Node((int)ECoinState.HTH);
            game.Add(node);
            
            node = new Node((int)ECoinState.HHT);
            game.Add(node);
            
            node = new Node((int)ECoinState.HHH);
            game.Add(node);
            
            game[(int)ECoinState.TTT].AddEdge(1, game[(int)ECoinState.TTH]);
            game[(int)ECoinState.TTT].AddEdge(2, game[(int)ECoinState.THT]);
            game[(int)ECoinState.TTT].AddEdge(4, game[(int)ECoinState.HTT]);
            game[(int)ECoinState.TTT].edges.Sort();
            
            game[(int)ECoinState.TTH].AddEdge(1, game[(int)ECoinState.TTT]);
            game[(int)ECoinState.TTH].AddEdge(3, game[(int)ECoinState.THH]);
            game[(int)ECoinState.TTH].edges.Sort();
            
            game[(int)ECoinState.THT].AddEdge(2, game[(int)ECoinState.TTT]);
            game[(int)ECoinState.THT].edges.Sort();
            
            game[(int)ECoinState.THH].AddEdge(3, game[(int)ECoinState.TTH]);
            game[(int)ECoinState.THH].AddEdge(7, game[(int)ECoinState.HHH]);
            game[(int)ECoinState.THH].edges.Sort();
            
            game[(int)ECoinState.HTT].AddEdge(4, game[(int)ECoinState.TTT]);
            game[(int)ECoinState.HTT].AddEdge(6, game[(int)ECoinState.HHT]);
            game[(int)ECoinState.HTT].edges.Sort();
            
            game[(int)ECoinState.HTH].AddEdge(7, game[(int)ECoinState.HHH]);
            game[(int)ECoinState.HTH].edges.Sort();
            
            game[(int)ECoinState.HHT].AddEdge(6, game[(int)ECoinState.HTT]);
            game[(int)ECoinState.HHT].AddEdge(7, game[(int)ECoinState.HHH]);
            game[(int)ECoinState.HHT].edges.Sort();
            
            game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.THH]);
            game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.HTH]);
            game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.HHT]);
            game[(int)ECoinState.HHH].edges.Sort();
            
            List<Node> shortestPath = GetShortestPathDijkstra();

            foreach( Node spNode in shortestPath )
            {
                Console.WriteLine((ECoinState)spNode.nState);
            }

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
                if (nState != (int)ECoinState.HTH)
                {
                    break;
                }
            }

            // create thread running DFS() for AI fetching the next move
            Thread t = new Thread(DFS);
            t.Start();

            // while not a winner
            while (nState != (int)ECoinState.HTH)
            {
                // convert the current numeric state to a string
                sState = ((ECoinState)nState).ToString();

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                sUserState = Console.ReadLine().ToUpper();

                // set mutex to give exclusice access to changing shared variable
                lock(lockObject)
                { 
                    // lock acquired, change the variable to indicate we are waiting for next move
                    bWaitingForMove = true;
                }
                
                // wait until bWaitingForMove is set to false by DFS()
                while (bWaitingForMove) ;

                nUserState = (int)Enum.Parse(typeof(ECoinState),sUserState);
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


        // A function used by DFS 
        static void DFSUtil(int v, bool[] visited)
        {
            // wait for the request for the next move
            while (!bWaitingForMove) ;
            //while (bWaitingForMove == false) ;

            // Mark the current node as visited 
            visited[v] = true;

            sUserState = ((ECoinState)v).ToString();

            // print the current node 
            Console.Write(v + " ");

            // lock the mutex to change the shared boolean variable
            lock (lockObject)
            {
                // no longer waiting for move
                bWaitingForMove = false;
            }

            // Recur for all the vertices 
            // adjacent to this vertex if there are any
            int[] thisStateList = lGraph[v];
            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, visited);
                    }
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
           For every child node, select the shortest path to start.
           When all edges have been investigated from a node, that node is "Visited" 
           and you don´t need to go there again.
        3. Add each child node connected to the current node to the priority queue.
        4. Go to step 2 until the queue is empty.
        5. Recursively create a list of each node that defines the shortest path 
           from end to start.
        6. Reverse the list and you have found the shortest path
        
        In other words, recursively for every child of a node, measure its distance to the start. 
        Store the distance and what node led to the shortest path to start. When you reach the end 
        node, recursively go back to the start the shortest way, reverse that list and you have the 
        shortest path.
        ******************************************************************************************/

        static public List<Node> GetShortestPathDijkstra()
        {
            // set up all distances from every vertex to the start vertex
            DijkstraSearch();

            // the list of nodes that will be the shortest path from the start
            List<Node> shortestPath = new List<Node>();

            // add the target node
            shortestPath.Add(game[(int)ECoinState.HTH]);

            // populate the List of nodes from the target node back to the start
            BuildShortestPath(shortestPath, game[(int)ECoinState.HTH]);

            // reverse the List to give the path from the start to the finish
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
            Node start = game[(int)ECoinState.THT];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            // next 2 lines are equivalent
            //Func<Node, int> nodeOrderBy = new Func<Node, int>(NodeOrderBy);
            Func<Node, int> nodeOrderBy = NodeOrderBy;

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // the next 5 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(nodeOrderBy).ToList();
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart ).ToList();
                prioQueue = prioQueue.OrderBy( n => n.minCostToStart ).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                // if we do not sort each list of edges after populating them for a node,
                // we can create a temporary sorted list for this loop
                //foreach (Edge cnn in node.edges.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    // look at the neighbor connected to this edge
                    Node neighborNode = cnn.connectedNode;
                    if (neighborNode.visited)
                    {
                        // skip if we already visited this neighbor
                        continue;
                    }
                      
                    // if this neighbor has not been evaluated yet or
                    // it is closer than the current path to start
                    if (neighborNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < neighborNode.minCostToStart)
                    {
                        // update the cost to start
                        neighborNode.minCostToStart = node.minCostToStart + cnn.cost;

                        // set the node heading back to start from this neighbor to the 
                        // node we got here by
                        neighborNode.nearestToStart = node;

                        // if we don't have this neighbor in our queue
                        if (!prioQueue.Contains(neighborNode))
                        {
                            // add it
                            prioQueue.Add(neighborNode);
                        }
                    }
                }

                // set this node as visited
                node.visited = true;

                // if we reached the target node
                if (node == game[(int)ECoinState.HTH])
                {
                    // we're done!
                    return;
                }

            // stay in this loop while there are any items left in our queue
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chutes_And_Ladders
{
    public class Cell
    {
        // each Cell for each space on the gameboard
        // can have a link to another node in the LinkedList 
        // (the result of there being a chute or ladder on this space)
        public LinkedListNode<Cell> shortcut;

        // booleans for whether this cell has a powerup or penalty on it
        public bool hasPowerUp;
        public bool hasPenalty;

        // internal reference id or index
        public int nNumber;
    }

    public class Player
    {
        // each player has the LinkedList Node of the current gameboard cell they are occupying
        public LinkedListNode<Cell> currentCell;

        // and a score
        public int score;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            bool bGameOver = false;

            int level = 1;
            int nLadders;
            int nChutes;
            int nPenalties;
            int nPowerUps;

            Player player1 = new Player();
            Player player2 = new Player();

            while (!bGameOver)
            {
                // create our game board
                LinkedList<Cell> board = new LinkedList<Cell>();

                // Lists to hold the list of id's of the cells to contain game artifacts
                List<int> lLadders = new List<int>();
                List<int> lChutes = new List<int>();
                List<int> lPowerUps = new List<int>();
                List<int> lPenalties = new List<int>();

                // dictionaries to link cell id's to nodes of our linked list
                // so that we can access the cells connected by chutes and ladders to set their shortcut field
                Dictionary<int, LinkedListNode<Cell>> dLadders = new Dictionary<int, LinkedListNode<Cell>>();
                Dictionary<int, LinkedListNode<Cell>> dChutes = new Dictionary<int, LinkedListNode<Cell>>();

                Cell cell = null;

                // number of game artifacts based on the current level
                nPenalties = level + 1;
                nPowerUps = level + 1;
                nLadders = level + 1;
                nChutes = level;

                // analysing the board layout to deduce a formula to calculate the "upstairs" cell
                // of 2 cells connected by a ladder or chute (0 is the starting cell, 22 is the finish):
                //   15 16 17 18 19 20 21 22
                //   14 13 12 11 10  9  8
                // 0  1  2  3  4  5  6  7
                //  
                // upstairs cell id = 2 * ((n + 7) / 7) * 7 - (n - 1)

                // populate our Ladders list of cell id's
                // no ladder on the cells with stairs (multiples of 7)
                while (nLadders > 0)
                {
                    int thisEl = rand.Next(1, (level + 1) * 7);
                    if (thisEl % 7 == 0 || lLadders.Contains(thisEl))
                    {
                        continue;
                    }

                    lLadders.Add(thisEl);
                    --nLadders;
                }

                // add the "upstairs" cell for each cell id in our list
                int nLength = lLadders.Count;
                for( int i = 0; i < nLength; ++i)
                {
                    lLadders.Add(2 * ((lLadders[i] + 7) / 7) * 7 - (lLadders[i] - 1));
                }

                // populate our Chutes list of cell id's
                // no chute on the cells with ladders or stairs (multiples of 7)
                while (nChutes > 0)
                {
                    int thisEl = rand.Next(1, (level + 1) * 7);
                    if (thisEl % 7 == 0 || lLadders.Contains(thisEl) || lChutes.Contains(thisEl))
                    {
                        continue;
                    }

                    lChutes.Add(thisEl);
                    --nChutes;
                }

                // add the "upstairs" cell for each cell id in our list
                nLength = lChutes.Count;
                for (int i = 0; i < nLength; ++i)
                {
                    lChutes.Add(2 * ((lChutes[i] + 7) / 7) * 7 - (lChutes[i] - 1));
                }

                // populate our Powerups list of cell id's
                // powerups can be on any cell
                while (nPowerUps > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPowerUps.Contains(thisEl))
                    {
                        continue;
                    }

                    lPowerUps.Add(thisEl);
                    --nPowerUps;
                }

                // populate our Penalties list of cell id's
                // penalties can be on any cell without powerups
                while (nPenalties > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPenalties.Contains(thisEl) || lPowerUps.Contains(thisEl))
                    {
                        continue;
                    }

                    lPenalties.Add(thisEl);
                    --nPenalties;
                }


                // insert starting cell
                cell = new Cell();
                cell.nNumber = 0;
                board.AddLast(cell);

                int cntr = 0;

                // number of gamespaces is a multiple of 7 based on the level
                for (cntr = 1; cntr < (level + 2) * 7 + 1; ++cntr)
                {
                    // create a new cell for each game space
                    cell = new Cell();
                    cell.nNumber = cntr;

                    // if this cell index is in the list of powerups
                    if( lPowerUps.Contains(cntr))
                    {
                        // set the flag
                        cell.hasPowerUp = true;
                    }

                    // if this cell index is in the list of penalties
                    if ( lPenalties.Contains(cntr))
                    {
                        // set the flag
                        cell.hasPenalty = true;
                    }

                    // add the cell to the board
                    board.AddLast(cell);

                    // if this cell has a reference to a ladder (either the bottom or top)
                    if( lLadders.Contains(cntr) )
                    {
                        // add this Node (the Last one we added) to the dictionary using this cell id
                        // we need to reference it later to set the Cell.shortcut
                        dLadders[cntr] = board.Last;
                    }

                    // if this cell has a reference to a chute (either the bottom or top)
                    if (lChutes.Contains(cntr))
                    {
                        // add this Node (the Last one we added) to the dictionary using this cell id
                        // we need to reference it later to set the Cell.shortcut
                        dChutes[cntr] = board.Last;
                    }
                }

                // look at each cell id in our list of ladders
                foreach( int nBottomEl in lLadders )
                {
                    // calculate the "upstairs" cell at the top of the ladder
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs cell id is also in our list
                    if ( dLadders.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the bottom cell to link to the upstairs Node
                        // Value is the Cell contained in this LinkedListNode
                        Cell bottomCell = dLadders[nBottomEl].Value;
                        bottomCell.shortcut = dLadders[nTopEl];
                        // this could also have been written as:
                        //     dLadders[nBottomEl].Value.shortcut = dLadders[nTopEl];
                    }
                }

                // look at each cell id in our list of chutes
                foreach (int nBottomEl in lChutes)
                {
                    // calculate the "upstairs" cell at the top of the chute
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs cell id is also in our list
                    if (dChutes.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the top cell to link to the bottom Node
                        // Value is the Cell contained in this LinkedListNode
                        Cell topCell = dChutes[nTopEl].Value;
                        topCell.shortcut = dChutes[nBottomEl];
                    }
                }

                // add the finish cell
                cell = new Cell();
                cell.nNumber = cntr;
                board.AddLast(cell);

                // set both players to start at the start of the board
                player1.currentCell = board.First;
                player2.currentCell = board.First;

                // thisPlayer is the current player
                Player thisPlayer = player1;

                // while neither player won yet
                while (player1.currentCell != board.Last &&
                       player2.currentCell != board.Last)
                {
                    // print the board
                    Console.WriteLine();
                    PrintBoard(board, player1, player2);

                    // ask the current player for their desired direction (default to +)
                    if( thisPlayer == player1)
                    {
                        Console.Write("Player 1: Which direction to move (-/+): ");
                    }
                    else
                    {
                        Console.Write("Player 2: Which direction to move (-/+): ");
                    }

                    string sDirection = Console.ReadLine();

                    // default to "+"
                    if( sDirection.Length == 0 )
                    {
                        sDirection = "+";
                    }

                    // roll the die
                    int nRoll = rand.Next(1, 7);
                    Console.WriteLine("You rolled a " + nRoll);

                move:
                    // while we have spaces to move and our player is on a valid Node of the LinkedList
                    while( nRoll > 0 && thisPlayer.currentCell != null)
                    {
                        // moving forward
                        if( sDirection == "+" )
                        {
                            // if there is a Next cell
                            if( thisPlayer.currentCell.Next != null )
                            {
                                // move the player to the next Node in the LinkedList
                                thisPlayer.currentCell = thisPlayer.currentCell.Next;
                            }
                            else
                            {
                                // otherwise we are at an end of the board
                                break;
                            }
                        }
                        else
                        {
                            // else moving backwards
                            // if there is a Previous Node
                            if(thisPlayer.currentCell.Previous != null)
                            {
                                // move the player to the Previous Node
                                thisPlayer.currentCell = thisPlayer.currentCell.Previous;
                            }
                            else
                            {
                                // otherwise we are at an end of the board
                                break;
                            }
                        }

                        // decrease the number of spaces left to move
                        --nRoll;
                    }

                    // the current player is now on the final destination
                    if(thisPlayer.currentCell.Value.hasPenalty )
                    {
                        // if the current cell has a penalty
                        // clear the penalty flag
                        thisPlayer.currentCell.Value.hasPenalty = false;

                        // print the new state of the board
                        PrintBoard(board, player1, player2);

                        // set die and direction to move the player back 2 spaces
                        nRoll = 2;
                        sDirection = "-";

                        // go back to move to move the player again
                        goto move;
                    }

                    if (thisPlayer.currentCell.Value.hasPowerUp)
                    {
                        // if the current cell has a powerup
                        // clear the penalty flag
                        thisPlayer.currentCell.Value.hasPowerUp = false;

                        // print the new state of the board
                        PrintBoard(board, player1, player2);

                        // set die and direction to move the player forward 2 spaces and increment the player's score
                        nRoll = 2;
                        sDirection = "+";
                        ++thisPlayer.score;

                        // go back to move to move the player again
                        goto move;
                    }

                    // if there is a shortcut for the cell attached to the current Node of the player's position
                    if(thisPlayer.currentCell.Value.shortcut != null)
                    {
                        // print the board
                        PrintBoard(board, player1, player2);

                        // set the player's current cell to the shortcut Node value
                        thisPlayer.currentCell = thisPlayer.currentCell.Value.shortcut;

                        // no more spaces to move, but since the position has changed loop back to check for powerups and penalties
                        nRoll = 0;
                        goto move;
                    }

                    // switch player
                    if ( thisPlayer == player1)
                    {
                        thisPlayer = player2;
                    }
                    else
                    {
                        thisPlayer = player1;
                    }
                }

                // if we get here, there is a winner!
                if( player1.currentCell == board.Last)
                {
                    Console.WriteLine("Player 1 you Won!!!");
                }
                else
                {
                    Console.WriteLine("Player 2 you Won!!!");
                }

                // Level Up!
                ++level;
                Console.WriteLine("Moving up to Level " + level);
            }
        }

        public static void PrintBoard(LinkedList<Cell> board, Player player1, Player player2 )
        {
            LinkedListNode<Cell> linkedListNode = board.First;

            while( linkedListNode != null )
            {
                Cell thisCell = linkedListNode.Value;
                Cell thisShortcut = null;
                if (thisCell.shortcut != null)
                {
                    thisShortcut = thisCell.shortcut.Value;
                }
                
                Console.Write($"[{thisCell.nNumber}" +
                    $"{(player1.currentCell == linkedListNode ? "^P1^":"")}" +
                    $"{(player2.currentCell == linkedListNode ? "^P2^" : "")}" +
                    $"{(thisCell.hasPowerUp ? "$":"")}" +
                    $"{(thisCell.hasPenalty ? "!" : "")}" + 
                    $"{(thisShortcut != null ? "=>" + thisShortcut.nNumber : "")}]");

                linkedListNode = linkedListNode.Next;
            }

            Console.WriteLine();
        }
    }
}

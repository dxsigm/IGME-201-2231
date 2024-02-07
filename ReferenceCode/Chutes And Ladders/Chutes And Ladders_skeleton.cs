using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chutes_And_Ladders
{
    public class Space
    {
        // each Space for each space on the gameboard
        // can have a link to another node in the LinkedList 
        // (the result of there being a chute or ladder on this space)
        public LinkedListNode<Space> shortcut;

        // booleans for whether this space has a powerup or penalty on it
        public bool hasPowerUp;
        public bool hasPenalty;

        // internal reference id or index
        public int nNumber;
    }

    public class Player
    {
        // each player has the LinkedList Node of the current gameboard space they are occupying
        public LinkedListNode<Space> currentSpace;

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
                LinkedList<Space> board = new LinkedList<Space>();

                // Lists to hold the list of id's of the spaces to contain game artifacts
                List<int> lLadders = new List<int>();
                List<int> lChutes = new List<int>();
                List<int> lPowerUps = new List<int>();
                List<int> lPenalties = new List<int>();

                // dictionaries to link space id's to nodes of our linked list
                // so that we can access the spaces connected by chutes and ladders to set their shortcut field
                Dictionary<int, LinkedListNode<Space>> dLadders = new Dictionary<int, LinkedListNode<Space>>();
                Dictionary<int, LinkedListNode<Space>> dChutes = new Dictionary<int, LinkedListNode<Space>>();

                Space space = null;

                // number of game artifacts based on the current level
                nPenalties = level + 1;
                nPowerUps = level + 1;
                nLadders = level + 1;
                nChutes = level;

                // analysing the board layout to deduce a formula to calculate the "upstairs" space
                // of 2 spaces connected by a ladder or chute (0 is the starting space, 22 is the finish):
                //   15 16 17 18 19 20 21 22
                //   14 13 12 11 10  9  8
                // 0  1  2  3  4  5  6  7
                //  
                // upstairs space id = 2 * ((n + 7) / 7) * 7 - (n - 1)

                // populate our Ladders list of space id's
                // no ladder on the spaces with stairs (multiples of 7)
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

                // add the "upstairs" space for each space id in our list
                int nLength = lLadders.Count;
                for (int i = 0; i < nLength; ++i)
                {
                    lLadders.Add(2 * ((lLadders[i] + 7) / 7) * 7 - (lLadders[i] - 1));
                }

                // populate our Chutes list of space id's
                // no chute on the spaces with ladders or stairs (multiples of 7)
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

                // add the "upstairs" space for each space id in our list
                nLength = lChutes.Count;
                for (int i = 0; i < nLength; ++i)
                {
                    lChutes.Add(2 * ((lChutes[i] + 7) / 7) * 7 - (lChutes[i] - 1));
                }

                // populate our Powerups list of space id's
                // powerups can be on any space
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

                // populate our Penalties list of space id's
                // penalties can be on any space without powerups
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


                // insert starting space
                space = new Space();
                space.nNumber = 0;
                board.AddLast(space);

                int cntr = 0;

                // number of gamespaces is a multiple of 7 based on the level
                for (cntr = 1; cntr < (level + 2) * 7 + 1; ++cntr)
                {
                    // create a new space for each game space
                    space = new Space();
                    space.nNumber = cntr;

                    // if this space index is in the list of powerups
                    if (lPowerUps.Contains(cntr))
                    {
                        // set the flag
                        space.hasPowerUp = true;
                    }

                    // if this space index is in the list of penalties
                    if (lPenalties.Contains(cntr))
                    {
                        // set the flag
                        space.hasPenalty = true;
                    }

                    // add the space to the board
                    board.AddLast(space);

                    // if this space has a reference to a ladder (either the bottom or top)
                    if (lLadders.Contains(cntr))
                    {
                        // add this Node (the Last one we added) to the dictionary using this space id
                        // we need to reference it later to set the Space.shortcut
                        dLadders[cntr] = board.Last;
                    }

                    // if this space has a reference to a chute (either the bottom or top)
                    if (lChutes.Contains(cntr))
                    {
                        // add this Node (the Last one we added) to the dictionary using this space id
                        // we need to reference it later to set the Space.shortcut
                        dChutes[cntr] = board.Last;
                    }
                }

                // look at each space id in our list of ladders
                foreach (int nBottomEl in lLadders)
                {
                    // calculate the "upstairs" space at the top of the ladder
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs space id is also in our list
                    if (dLadders.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the bottom space to link to the upstairs Node
                        // Value is the Space contained in this LinkedListNode
                        Space bottomSpace = dLadders[nBottomEl].Value;
                        bottomSpace.shortcut = dLadders[nTopEl];
                        // this could also have been written as:
                        //     dLadders[nBottomEl].Value.shortcut = dLadders[nTopEl];
                    }
                }

                // look at each space id in our list of chutes
                foreach (int nBottomEl in lChutes)
                {
                    // calculate the "upstairs" space at the top of the chute
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs space id is also in our list
                    if (dChutes.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the top space to link to the bottom Node
                        // Value is the Space contained in this LinkedListNode
                        Space topSpace = dChutes[nTopEl].Value;
                        topSpace.shortcut = dChutes[nBottomEl];
                    }
                }

                // add the finish space
                space = new Space();
                space.nNumber = cntr;
                board.AddLast(space);

                // set both players to start at the start of the board
                player1.currentSpace = board.First;
                player2.currentSpace = board.First;

                // thisPlayer is the current player
                Player thisPlayer = player1;

                while (player1.currentSpace != board.Last &&
                       player2.currentSpace != board.Last)
                {
                    /// print the game board

                    ///    tell player 1 or 2 that it's their turn
                    ///    
                    ///    prompt the player for the direction to move (+ or -) (default should be +)Console.Write("Player 1: Which direction to move (-/+): ");
                    ///    store their answer in string sDirection
                    ///
                    ///    int nRoll to roll the die and output the rolled value

                move:
                    while (nRoll > 0 && thisPlayer.currentSpace != null)
                    {
                        /// if sDirection == "+"
                        ///    then move thisPlayer's currentSpace to the next space in the LinkedList
                        ///    but only if the next space is not null
                        ///    if the next space is null, then break out of the while loop

                        /// else if sDirection == "-"
                        ///    then move thisPlayer's currentSpace to the previous space in the LinkedList
                        ///    but only if the previous space is not null
                        ///    if the previous space is null, then break out of the while loop

                        --nRoll;
                    }

                    ///  if this player's current space has a penalty
                    ///  (notice that the penalty takes precedence over the shortcut)
                    ///  {
                    ///      clear the space's penalty indicator
                    ///      print the board
                    ///      set nRoll = 2
                    ///      set sDirection = "-" to move the player backwards 2 spaces
                    ///      goto move;
                    ///  }


                    ///  if this player's current space has a powerup 
                    ///  (notice that the powerup takes precedence over the shortcut)
                    ///  {
                    ///      clear the space's powerup indicator
                    ///      print the board
                    ///      set nRoll = 2
                    ///      set sDirection = "+" to move the plater forwards 2 spaces
                    ///      incrment the player's score
                    ///      goto move;
                    ///  }


                    ///  if this player's current space has a shortcut because it is a chute or ladder
                    ///  {
                    ///      print the board
                    ///      set thisPlayer's currentSpace = the shortcut
                    ///      set nRoll = 0 to keep the player at the current space but to check for more power ups, penalties and shortcuts
                    ///      goto move;
                    ///  }


                    ///  
                    ///  switch to next player's turn
                }

                ///   display the winning player based on which of their
                ///   current space's is the last node in the linked list

                ++level;
                Console.WriteLine("Moving up to Level " + level);
            }
        }

        public static void PrintBoard(LinkedList<Space> board, Player player1, Player player2)
        {
            LinkedListNode<Space> linkedListNode = board.First;

            while (linkedListNode != null)
            {
                Space thisSpace = linkedListNode.Value;
                Space thisShortcut = null;
                if (thisSpace.shortcut != null)
                {
                    thisShortcut = thisSpace.shortcut.Value;
                }

                Console.Write($"[{thisSpace.nNumber}" +
                    $"{(player1.currentSpace == linkedListNode ? "^P1^" : "")}" +
                    $"{(player2.currentSpace == linkedListNode ? "^P2^" : "")}" +
                    $"{(thisSpace.hasPowerUp ? "$" : "")}" +
                    $"{(thisSpace.hasPenalty ? "!" : "")}" +
                    $"{(thisShortcut != null ? "=>" + thisShortcut.nNumber : "")}]");

                linkedListNode = linkedListNode.Next;
            }

            Console.WriteLine();
        }
    }
}

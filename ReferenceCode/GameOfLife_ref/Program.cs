using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace GameOfLife
{
    public enum EAliveState
    {
        alive,
        dead
    }

    public enum EInfectedState
    {
        infected,
        vaccinated,
        organic
    }

    public enum EDirection
    {
        right,
        down,
        left,
        up
        //    ,
        //topleft,
        //topright,
        //bottomleft,
        //bottomright
    }

    public struct StructCellState
    {
        private EAliveState eAliveState;

        public EAliveState PEAliveState
        {
            get 
            {
                return eAliveState;
            }

            set
            {
                eAliveState = value;

                if (eAliveState == EAliveState.dead )
                {
                    eInfectedState = EInfectedState.organic;
                }
            }
        }

        public EInfectedState eInfectedState;
    }

    static public class Game
    {
        public static bool bExit = false;


        public static Random rand = new Random();

        public static int MAX_ROWS = 30;
        public static int MAX_COLS = 80;

        public static Cell[,] organism;

        public class Cell
        {
            const int MAX_VIRUSES = 50;
            const int MAX_VACCINES = 50;

            public static int MAX_NEIGHBORS = Enum.GetNames(typeof(EDirection)).Length;

            public Cell[] neighbor;
            public Cell nextCell;

            public StructCellState prevCellState;
            public StructCellState currentCellState;
            public StructCellState nextCellState;

            public static int nViruses;
            public static int nVaccines;

            public object gameObject;

            public Cell(int maxCells, int probability = 6)
            {
                neighbor = new Cell[MAX_NEIGHBORS];
                currentCellState.eInfectedState = EInfectedState.organic;
                currentCellState.PEAliveState = EAliveState.dead;

                if (rand.Next(0, probability) == 0)
                {
                    currentCellState.PEAliveState = EAliveState.alive;

                    // if not all viruses infected yet
                    if (nViruses < MAX_VIRUSES)
                    {
                        if (rand.Next(0, maxCells) < maxCells / MAX_VIRUSES)
                        {
                            currentCellState.eInfectedState = EInfectedState.infected;
                            ++nViruses;
                        }
                    }

                    // if not infected yet and not all vaccines administered yet
                    if (currentCellState.eInfectedState == EInfectedState.organic && nVaccines < MAX_VACCINES)
                    {
                        if (rand.Next(0, maxCells) < maxCells / MAX_VACCINES)
                        {
                            currentCellState.eInfectedState = EInfectedState.vaccinated;
                            ++nVaccines;
                        }
                    }
                }
            }

            public void SetNextState()
            {                
                int nAlive = 0;
                int nInfected = 0;
                int nVaccinated = 0;

                for (int nCntr = 0; nCntr < MAX_NEIGHBORS; ++nCntr)
                {
                    Cell neighborCell = neighbor[nCntr];

                    if (neighborCell != null)
                    {
                        if (neighborCell.currentCellState.eInfectedState == EInfectedState.infected)
                        {
                            ++nInfected;
                        }

                        if (neighborCell.currentCellState.eInfectedState == EInfectedState.vaccinated)
                        {
                            ++nVaccinated;
                        }

                        if (neighborCell.currentCellState.PEAliveState == EAliveState.alive)
                        {
                            ++nAlive;
                        }
                    }
                }

                // default to current infected state
                nextCellState.eInfectedState = currentCellState.eInfectedState;

                // if less than 2 or more than 3 contiguous live cells
                if (nAlive < 2 || nAlive > 3)
                {
                    nextCellState.PEAliveState = EAliveState.dead;
                }
                else
                {
                    nextCellState.PEAliveState = EAliveState.alive;
                }

                if (currentCellState.PEAliveState == EAliveState.alive &&
                    nextCellState.PEAliveState == EAliveState.alive)
                {
                    if (nInfected > 0 && nInfected >= nVaccinated &&
                        currentCellState.eInfectedState != EInfectedState.vaccinated)
                    {
                        nextCellState.eInfectedState = EInfectedState.infected;
                    }
                    else if (nVaccinated > 0)
                    {
                        nextCellState.eInfectedState = EInfectedState.vaccinated;
                    }
                }
            }
        }

        //static void Main(string[] args)
        public static void CreateOrganism( int probability = 6)
        {
            organism = new Cell[MAX_ROWS, MAX_COLS];

            for (int row = 0; row < MAX_ROWS; ++row)
            {
                for(int col = 0; col < MAX_COLS; ++col )
                {
                    organism[row,col] = new Cell(MAX_ROWS * MAX_COLS, probability);
                }
            }

            for (int row = 0; row < MAX_ROWS; ++row)
            {
                for (int col = 0; col < MAX_COLS; ++col)
                {
                    Cell nextCell = null;

                    for ( int nCntr = 0; nCntr < Cell.MAX_NEIGHBORS; ++nCntr )
                    {
                        Cell neighborCell = null;

                        switch( nCntr )
                        {
                            case (int)EDirection.right:
                                // right neighbor
                                if( col < MAX_COLS - 1 )
                                {
                                    neighborCell = organism[row,col + 1];
                                    nextCell = organism[row,col + 1];
                                }
                                else if (row < MAX_ROWS - 1)
                                {
                                    nextCell = organism[row + 1,0];
                                }

                                break;

                            case (int)EDirection.down:
                                // bottom neighbor
                                if (row < MAX_ROWS - 1)
                                {
                                    neighborCell = organism[row + 1,col];
                                }
                                break;

                            case (int)EDirection.left:
                                // left neighbor
                                if (col > 0)
                                {
                                    neighborCell = organism[row,col - 1];
                                }
                                break;

                            case (int)EDirection.up:
                                // top neighbor
                                if (row > 0)
                                {
                                    neighborCell = organism[row - 1,col];
                                }
                                break;

                            //case (int)EDirection.topright:
                            //    // topright neighbor
                            //    if (row > 0 && col < MAX_COLS - 1)
                            //    {
                            //        neighborCell = organism[row - 1,col + 1];
                            //    }
                            //
                            //    break;
                            //
                            //case (int)EDirection.bottomright:
                            //    // bottomright neighbor
                            //    if (row < MAX_ROWS - 1 && col < MAX_COLS - 1)
                            //    {
                            //        neighborCell = organism[row + 1,col + 1];
                            //    }
                            //    break;
                            //
                            //case (int)EDirection.topleft:
                            //    // topleft neighbor
                            //    if (col > 0 && row > 0)
                            //    {
                            //        neighborCell = organism[row - 1,col - 1];
                            //    }
                            //    break;
                            //
                            //case (int)EDirection.bottomleft:
                            //    // bottomleft neighbor
                            //    if (row < MAX_ROWS - 1 && col > 0)
                            //    {
                            //        neighborCell = organism[row + 1,col - 1];
                            //    }
                            //    break;
                            //
                        }

                        organism[row,col].neighbor[nCntr] = neighborCell;
                        
                    }

                    organism[row,col].nextCell = nextCell;
                }
            }

            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancel);
            //
            //while ( !bExit )
            //{
            //    PrintOrganism(organism, MAX_ROWS, MAX_COLS);
            //    CalculateNextGeneration(organism[0,0]);
            //    Thread.Sleep(100);
            //}
            //
            //Console.WriteLine("\nPress Enter.");
            //Console.ReadLine();

        }

        public static void ConsoleCancel(object sender, ConsoleCancelEventArgs e )
        {
            bExit = true;
        }

        public static void CalculateNextGeneration( Cell thisCell )
        {
            if (thisCell != null)
            {
                thisCell.SetNextState();
                CalculateNextGeneration(thisCell.nextCell);
                thisCell.currentCellState = thisCell.nextCellState;
            }
        }

        public static void PrintOrganism( Cell[,] organism, int maxRows, int maxCols)
        {
            string output = "----------------------------------------------------------------------------------\n";

            for (int row = 0; row < maxRows; ++row)
            {
                output += "|";
                for (int col = 0; col < maxCols; ++col)
                {
                    Cell thisCell = organism[row,col];
                    if (thisCell.currentCellState.PEAliveState == EAliveState.alive)
                    {
                        switch( (int)thisCell.currentCellState.eInfectedState )
                        {
                            case (int)EInfectedState.organic:
                                output += "\x25cb";
                                break;

                            case (int)EInfectedState.vaccinated:
                                output += "\x25ca";
                                break;

                            case (int)EInfectedState.infected:
                                output += "\x25cf";
                                break;
                        }
                    }
                    else
                    {
                        output += " ";
                    }
                }

                output += "|\n";
            }

            output += "----------------------------------------------------------------------------------";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }
    }
}

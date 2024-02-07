using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Diagnostics;


namespace GameOfLife
{
    public enum EDirection
    {
        topleft,
        up,
        topright,
        left,
        center,
        right,
        bottomleft,
        down,
        bottomright
    }

    static public class Game
    {
        public static bool bExit = false;

        public static Random rand = new Random();

        public static int MAX_ROWS = 30 + 2;
        public static int MAX_COLS = 80 + 2;

        public static int nGenEl = 0;
        public static bool[][][] nextGens = new bool[2][][];
        
                
        public static bool[][] organism;
        public static bool[][] nextGen;

        static bool[] bCell = new bool[9];

        // graph for calculating the next state from the current 9-bit state
        //public static short[] nextStateGraph = new short[(int)Math.Pow(2,9)];

        static void Main(string[] args)
        {
            short i;

            for ( i = 0; i < 2; ++i )
            {
                nextGens[i] = new bool[MAX_ROWS][];

                for( int j = 0; j < MAX_ROWS; ++j)
                {
                    nextGens[i][j] = new bool[MAX_COLS];
                }
            }

            organism = nextGens[nGenEl];

            string[] sInitialState = new string[MAX_ROWS];

            //Console.WriteLine("Enter initial state of the organism (1=alive,0=dead). Blank to end data entry.");

            int nIniRows = 0;

            // calculate all possible state changes
            //for( i = 0; i < 512; ++i )
            //{
            //    nextStateGraph[i] = CalcNextState(i);
            //}

            // Gosper glider gun
            sInitialState[0] = "                         1";
            sInitialState[1] = "                       1 1";
            sInitialState[2] = "             11      11            11";
            sInitialState[3] = "            1   1    11            11";
            sInitialState[4] = " 11        1     1   11";
            sInitialState[5] = " 11        1   1 11    1 1";
            sInitialState[6] = "           1     1       1";
            sInitialState[7] = "            1   1";
            sInitialState[8] = "             11";
            nIniRows = 9;

            for (int row = 1; row < MAX_ROWS - 1; ++row)
            {
                for (int col = 1; col < MAX_COLS - 1; ++col)
                {
                    int probability = 6;

                    if (nIniRows > 0)
                    {
                        if (row - 1 < nIniRows)
                        {
                            if (col - 1 < sInitialState[row - 1].Length)
                            {
                                if (sInitialState[row - 1][col - 1] == '1')
                                {
                                    organism[row][col] = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (rand.Next(0, probability) == 0)
                        {
                            organism[row][col] = true;
                        }
                    }
                }
            }

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancel);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            i = 10000;
            while (i > 0)
            {
                //PrintOrganism(organism, MAX_ROWS, MAX_COLS);
                CalculateNextGeneration();
                //Thread.Sleep(100);
                --i;
            }

            stopwatch.Stop();
            Console.WriteLine("Time for 10,000 generations: {0}ms\n {1} generations per second",
                        stopwatch.ElapsedMilliseconds, 10000000 / stopwatch.ElapsedMilliseconds);
            Console.WriteLine("\nPress Enter.");
            Console.ReadLine();
        }

        public static bool[] IntToGrid(short c)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (((1 << i) & c) != 0)
                {
                    bCell[8 - i] = true;
                }
                else
                {
                    bCell[8 - i] = false;
                }
            }

            return (bCell);
        }

        public static short GridToInt(bool[] g)
        {
            short r = 0;

            for (int i = 0; i < 9; ++i)
            {
                if (g[i])
                {
                    r += (short)(1 << (8 - i));
                }
            }

            return (r);
        }


        public static short CalcNextState(short c)
        {
            short r = 0;
            int nAlive = 0;

            bool[] g = IntToGrid(c);

            for (int i = 0; i < 9; ++i)
            {
                if (i == 4)
                {
                    continue;
                }

                if (g[i])
                {
                    ++nAlive;
                }
            }

            if (nAlive < 2 || nAlive > 3)
            {
                g[4] = false;
            }
            else if (nAlive == 3)
            {
                g[4] = true;
            }

            r = GridToInt(g);

            return (r);
        }

        public static void ConsoleCancel(object sender, ConsoleCancelEventArgs e)
        {
            bExit = true;
        }

        public static void CalculateNextGeneration()
        {
            int nAlive;

            nextGen = nextGens[++nGenEl % 2];

            for (int row = 1; row < MAX_ROWS - 1; ++row)
            {
                for (int col = 1; col < MAX_COLS - 1; ++col)
                {
                    nAlive = 0;

                    //bCell[0] = organism[row - 1,col - 1];
                    //bCell[1] = organism[row - 1,col];
                    //bCell[2] = organism[row - 1,col + 1];
                    //
                    //bCell[3] = organism[row,col - 1];
                    //bCell[4] = organism[row,col];
                    //bCell[5] = organism[row,col + 1];
                    //
                    //bCell[6] = organism[row + 1,col - 1];
                    //bCell[7] = organism[row + 1,col];
                    //bCell[8] = organism[row + 1,col + 1];
                    //
                    //short currentState = GridToInt(bCell);
                    //short nextState = nextStateGraph[currentState];
                    //
                    //bCell = IntToGrid(nextState);
                    //nextGen[row,col] = bCell[4];

                    if (organism[row - 1][col - 1])
                    {
                        ++nAlive;
                    }
                    
                    if (organism[row - 1][col])
                    {
                        ++nAlive;
                    }
                    
                    if (organism[row - 1][col + 1])
                    {
                        ++nAlive;
                    }
                    
                    
                    if (organism[row][col - 1])
                    {
                        ++nAlive;
                    }
                    
                    if (organism[row][col + 1])
                    {
                        ++nAlive;
                    }
                    
                    
                    if (organism[row + 1][col - 1])
                    {
                        ++nAlive;
                    }
                    
                    if (organism[row + 1][col])
                    {
                        ++nAlive;
                    }
                    
                    if (organism[row + 1][col + 1])
                    {
                        ++nAlive;
                    }
                    
                    if (nAlive < 2 || nAlive > 3)
                    {
                        nextGen[row][col] = false;
                    }
                    else if (nAlive == 3)
                    {
                        nextGen[row][col] = true;
                    }
                    else
                    {
                        nextGen[row][col] = organism[row][col];
                    }

                }
            }

            organism = nextGen;
        }

        public static void PrintOrganism(bool[][] organism, int maxRows, int maxCols)
        {
            string output = "----------------------------------------------------------------------------------\n";

            for (int row = 1; row < maxRows - 1; ++row)
            {
                output += "|";
                for (int col = 1; col < maxCols - 1; ++col)
                {
                    if (organism[row][col])
                    {
                        output += "\x25cb";
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

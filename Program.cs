using System.Reflection.Metadata.Ecma335;

namespace FunWith2DArrays;

using System;
using System.Drawing;
using Console = Colorful.Console;

class Program
{
    static void Main(string[] args)
    {
        const int MAX_ROWS = 15;
        const int MAX_COLS = 15;

        const int RANDOM_SYMBOLS_MODE = 1;
        const int SHOW_INDICES_MODE = 2;
        const int ALTERNATING_SYMBOLS_MODE = 3;

        int nRows = 0;
        int nCols = 0;

        bool inputRowCorrect = false;
        while (inputRowCorrect == false)
        {
            Console.WriteLine("Please enter the number of rows and press enter:");
            nRows = Convert.ToInt32(Console.ReadLine());
            if (nRows > MAX_ROWS)
            {
                Console.WriteLine($"Number of rows too high - max is {MAX_ROWS}");
                inputRowCorrect = false;
            }
            else
            {
                inputRowCorrect = true;
            }
        }

        bool inputColCorrect = false;
        while (inputColCorrect == false)
        {
            Console.WriteLine("Please enter the number of columns and press enter:");
            nCols = Convert.ToInt32(Console.ReadLine());
            if (nCols > MAX_COLS)
            {
                Console.WriteLine($"Number of columns too high - max is {MAX_COLS}");
                inputColCorrect = false;
            }
            else
            {
                inputColCorrect = true;
            }
        }

        //Initialize array
        string[,] array2D = new string[nRows, nCols];
        //Declare random
        Random rng = new Random();

        //Let user choose mode
        Console.WriteLine(
            "Please choose an array mode (enter number of the mode and press enter):\n1 random symbols\n2 show indices\n3 alternating symbols");
        int mode = Convert.ToInt32(Console.ReadLine());

        if (mode == RANDOM_SYMBOLS_MODE)
        {
            //Random symbols
            List<string> symbols = new List<string>() { "?", "&", "%", "$", "*" };

            //Populate array
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    int indexRandomSymbol = rng.Next(0, symbols.Count);
                    array2D[row, col] = symbols[indexRandomSymbol];
                }
            }

            //Print array
            Console.Write(string.Concat(Enumerable.Repeat("+---", nCols)));
            Console.Write("+\n");
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    int r = rng.Next(0, 256);
                    int g = rng.Next(0, 256);
                    int b = rng.Next(0, 256);

                    Console.Write("| ");
                    Console.Write(array2D[row, col] + " ", Color.FromArgb(r, g, b));
                }

                Console.Write("|\n");

                Console.Write(string.Concat(Enumerable.Repeat("+---", nCols)));
                Console.Write("+\n");
            }
        }

        if (mode == SHOW_INDICES_MODE)
        {
            //Populate Array
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    array2D[row, col] = row + "," + col;
                }
            }

            //Print array
            Console.Write(string.Concat(Enumerable.Repeat("* ooo ", nCols)), Color.Green);
            Console.Write("*\n", Color.Green);
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    Console.Write("* ", Color.Green);
                    Console.Write(array2D[row, col] + " ", Color.DarkRed);
                }

                Console.Write("o\n", Color.Green);

                Console.Write(string.Concat(Enumerable.Repeat("* ooo ", nCols)), Color.Green);
                Console.Write("*\n", Color.Green);
            }
        }

        if (mode == ALTERNATING_SYMBOLS_MODE)
        {
            //first element
            array2D[0, 0] = "X";

            //first column
            for (int row = 1; row < nRows; row++)
            {
                if (array2D[row - 1, 0] == "X")
                {
                    array2D[row, 0] = "O";
                }
                else
                {
                    array2D[row, 0] = "X";
                }
            }

            //populate rest of array
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 1; col < nCols; col++)
                {
                    if (array2D[row, col - 1] == "X")
                    {
                        array2D[row, col] = "O";
                    }
                    else
                    {
                        array2D[row, col] = "X";
                    }
                }
            }

            //print array
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    Console.Write(array2D[row, col] + " ");
                }

                Console.Write("\n");
            }
        }
    }
}
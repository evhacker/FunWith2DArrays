using System.Reflection.Metadata.Ecma335;

namespace FunWith2DArrays;

using System;
using System.Drawing;
using Console = Colorful.Console;

class Program
{
    static void Main(string[] args)
    {
        const int MAXROWS = 15;
        const int MAXCOLS = 15;

        int nRows = 0;
        int nCols = 0;

        bool inputRowCorrect = false;
        while (inputRowCorrect == false)
        {
            Console.WriteLine("Please enter the number of rows and press enter:");
            nRows = Convert.ToInt32(Console.ReadLine());
            if (nRows > MAXROWS)
            {
                Console.WriteLine($"Number of rows too high - max is {MAXROWS}");
                inputRowCorrect = false;
                continue;
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
            if (nCols > MAXCOLS)
            {
                Console.WriteLine($"Number of columns too high - max is {MAXCOLS}");
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
            "Please choose a mode (enter number of the mode and press enter):\n1 random symbols\n2 show indices\n3 alternating symbols");
        int mode = Convert.ToInt32(Console.ReadLine());

        if (mode == 1)
        {
            //Rondom symbols
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

        if (mode == 2)
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

        if (mode == 3)
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
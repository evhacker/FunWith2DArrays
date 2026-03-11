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
            Console.WriteLine("Please enter the number of rows:");
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
            Console.WriteLine("Please enter the number of columns:");
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

        //Rondom symbols
        List<string> symbols = new List<string>() { "?", "&", "%", "$", "*" };

        //Populate array
        for (int row = 0;
             row < nRows;
             row++)
        {
            for (int col = 0; col < nCols; col++)
            {
                Random rng = new Random();
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
                Random rngR = new Random();
                int r = rngR.Next(0, 256);
                Random rngG = new Random();
                int g = rngG.Next(0, 256);
                Random rngB = new Random();
                int b = rngB.Next(0, 256);

                Console.Write("| ");
                Console.Write(array2D[row, col] + " ", Color.FromArgb(r, g, b));
            }

            Console.Write("|\n");

            Console.Write(string.Concat(Enumerable.Repeat("+---", nCols)));
            Console.Write("+\n");
        }
    }
}
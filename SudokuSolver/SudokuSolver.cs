using System.Diagnostics;

namespace SudokuSolver
{
    class SudokuSolver
    {
        
        static void Main(string[] args)
        {
            //The hardest puzzle ever (49,498 tries to solve)
            int[,] puzzle1 =
            {
            {8, 0, 0,  0, 0, 0,  0, 0, 0},
            {0, 0, 3,  6, 0, 0,  0, 0, 0},
            {0, 7, 0,  0, 9, 0,  2, 0, 0},

            {0, 5, 0,  0, 0, 7,  0, 0, 0},
            {0, 0, 0,  0, 4, 5,  7, 0, 0},
            {0, 0, 0,  1, 0, 0,  0, 3, 0},

            {0, 0, 1,  0, 0, 0,  0, 6, 8},
            {0, 0, 8,  5, 0, 0,  0, 1, 0},
            {0, 9, 0,  0, 0, 0,  4, 0, 0}
            };

            //The hardest puzzle ever (49,498 tries to solve)
            int[,] puzzle2 =
            {
            {0, 7, 0,  0, 2, 0,  0, 4, 6},
            {0, 6, 0,  0, 0, 0,  8, 9, 0},
            {2, 0, 0,  8, 0, 0,  7, 1, 5},

            {0, 8, 4,  0, 9, 7,  0, 0, 0},
            {7, 1, 0,  0, 0, 0,  0, 5, 9},
            {0, 0, 0,  1, 3, 0,  4, 8, 0},

            {6, 9, 7,  0, 0, 2,  0, 0, 8},
            {0, 5, 8,  0, 0, 0,  0, 6, 0},
            {4, 3, 0,  0, 8, 0,  0, 7, 0}
            };

            //Extra hard puzzle (346,386 tries to solve)
            int[,] puzzle3 =
            {
            {5, 0, 9,  4, 0, 0,  0, 0, 0},
            {0, 0, 3,  0, 0, 0,  6, 9, 0},
            {0, 1, 0,  0, 0, 0,  0, 0, 5},

            {0, 5, 0,  1, 8, 0,  0, 0, 0},
            {3, 0, 0,  0, 5, 0,  0, 0, 7},
            {0, 0, 0,  0, 9, 6,  0, 5, 0},

            {9, 0, 0,  0, 0, 0,  0, 7, 0},
            {0, 3, 8,  0, 0, 0,  5, 0, 0},
            {0, 0, 0,  0, 0, 7,  1, 0, 3}
            };
            
            SolvePuzzle(puzzle3);

        }
        static bool CheckPossibility(int y, int x, int n, int[,] Puzzle)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Puzzle[y, i] == n)
                {
                    GlobalVariables.horizontalChecks++;
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (Puzzle[i, x] == n)
                {
                    GlobalVariables.verticalChecks++;
                    return false;
                }
            }
            int x_grid = (x / 3) * 3;
            int y_grid = (y / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Puzzle[y_grid + i , x_grid + j] == n)
                    {
                        GlobalVariables.gridChecks++;
                        return false;
                    }
                }
            }
            return true;
        }    
        static void SolvePuzzle(int[,] puzzle)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (puzzle[y,x] == 0)
                    {
                        foreach (int n in Enumerable.Range(1, 9))
                        {
                            if (CheckPossibility(y, x, n, puzzle))
                            {
                                puzzle[y, x] = n;
                                SolvePuzzle(puzzle);
                                puzzle[y, x] = 0;
                                GlobalVariables.puzzleChecks++;
                            }
                            
                        } return;
                        
                    }
                }
            }           
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string sec = ts.ToString("ss\\.ffffff");

            Console.WriteLine("Sudoku was solved with {0} horizontal checks, {1} vertical checks," +
                " {2} grid checks and {3} puzzle checks in {4} seconds!", GlobalVariables.horizontalChecks, 
                GlobalVariables.verticalChecks, GlobalVariables.gridChecks, GlobalVariables.puzzleChecks, sec);
            Console.WriteLine("Here is the answer of your puzzle!");

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("{0} {1} {2} | {3} {4} {5} | {6} {7} {8}", puzzle[i, 0], 
                    puzzle[i, 1], puzzle[i, 2], puzzle[i, 3], puzzle[i, 4],
                    puzzle[i, 5], puzzle[i, 6], puzzle[i, 7], puzzle[i, 8]);
                if (i == 2 || i == 5) Console.WriteLine("---------------------");              
            }
        }
    }
}
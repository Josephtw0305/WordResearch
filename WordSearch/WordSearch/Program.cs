using System;

namespace WordSearch
{
    class Program
    {
        static int rowNumber;
        static int colNumber;

        // For searching in all 8 direction  
        static int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

        static void Main(string[] args)
        {
            rowNumber = 3;
            colNumber = 4;

            // Set test map.
            char[,] grid = { {'A','B','C','E'},
                             {'S','F','C','S'},
                             {'A','D','E','E' }
                           };


            bool resultMethod2 = existWord(grid, "ABCCED");
            Console.WriteLine($"ABCCED:{resultMethod2.ToString()}");

            resultMethod2 = existWord(grid, "SEE");
            Console.WriteLine($"SEE:{resultMethod2.ToString()}");

            resultMethod2 = existWord(grid, "ABCB");
            Console.WriteLine($"ABCB:{resultMethod2.ToString()}");

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();

        }

        private static bool existWord(char[,] board, string word)
        {

            var row = board.GetLength(0);
            var column = board.GetLength(1);
            var visited = new bool[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (board[i, j] == word[0])
                    {
                        if (ExistHelper(board, i, j, word, 0, visited)) return true;
                    }
                }
            }

            return false;
        }

        private static bool ExistHelper(char[,] board, int i, int j, string word, int index, bool[,] visited)
        {
            if (i < 0 ||
                i >= board.GetLength(0) ||
                j < 0 ||
                j >= board.GetLength(1) ||
                board[i, j] != word[index] ||
                visited[i, j])
            {
                return false;
            }
                
            if (index == word.Length - 1) return true;

            visited[i, j] = true;

            if (ExistHelper(board, i - 1, j, word, index + 1, visited)) return true;
            if (ExistHelper(board, i + 1, j, word, index + 1, visited)) return true;
            if (ExistHelper(board, i, j - 1, word, index + 1, visited)) return true;
            if (ExistHelper(board, i, j + 1, word, index + 1, visited)) return true;

            visited[i, j] = false;
            return false;
        }

    }
}

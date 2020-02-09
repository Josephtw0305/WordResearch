using System;

namespace WordSearch
{
    class Program
    {
       
        static void Main(string[] args)
        {
        
            // Set searching baseBoard.
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

            string input = "";
            while (!(input.ToString() == "9999"))
            {
                Console.Write("Please input searching words:");
                string searchWords = Console.ReadLine();
                resultMethod2 = existWord(grid, searchWords);
                Console.WriteLine($"{searchWords}:{resultMethod2.ToString()}");
                Console.WriteLine("Press 9999 to end...");
                input = Console.ReadLine();
            }
        
        }

        /// <summary>
        /// Checking whether the giving word exist or not.
        /// </summary>
        /// <param name="board">base searching baseBoard.</param>
        /// <param name="word">target searching words.</param>
        /// <returns></returns>
        private static bool existWord(char[,] baseBoard, string word)
        {

            var row = baseBoard.GetLength(0);
            var column = baseBoard.GetLength(1);
            var visited = new bool[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    // Locate the first letter.
                    if (baseBoard[i, j] == word[0])
                    {
                        if (ExistHelper(baseBoard, i, j, word, 0, visited)) return true;
                    }
                }
            }

            return false;
        }


        private static bool ExistHelper(char[,] baseBoard, int i, int j, string word, int index, bool[,] visited)
        {
            // Confirming whether the index out of limitation or not.
            if (i < 0 ||
                i >= baseBoard.GetLength(0) ||
                j < 0 ||
                j >= baseBoard.GetLength(1) ||
                baseBoard[i, j] != word[index] ||
                visited[i, j])
            {
                return false;
            }
            
            // avoid the input index = -1
            if (index == word.Length - 1) return true;

            // mark this visit index to true that means it has been visited.
            visited[i, j] = true;

            //(1,1)

            // Up point.
            if (ExistHelper(baseBoard, i - 1, j, word, index + 1, visited)) return true;

            // Down point
            if (ExistHelper(baseBoard, i + 1, j, word, index + 1, visited)) return true;

            // Left point
            if (ExistHelper(baseBoard, i, j - 1, word, index + 1, visited)) return true;

            // Right point.
            if (ExistHelper(baseBoard, i, j + 1, word, index + 1, visited)) return true;

            // if no match point which locates the target point's up,down,lefe,and right point, mark this location to "visited".
            visited[i, j] = false;
            return false;
        }

    }
}

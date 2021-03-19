using System;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "";
            int queenCount = 0;

            while (true)
            {
                Console.WriteLine("Enter the count of queens: ");
                inputText = Console.ReadLine();

                if (int.TryParse(inputText, out queenCount) && queenCount > 0)
                    break;

                Console.WriteLine("Please input a positive integer!");
            }

            EightQueens eightQueens = new EightQueens(queenCount);

            // 每個 index 都代表皇后座標的 row，值則代表皇后座標的 column
            // e.g. Queens[0] == 4 表示第 0 列第 4 行放有皇后
            int[] Queens = new int[queenCount];
            eightQueens.PlaceQueen(Queens, 0);

            Console.Write(string.Format("Total count of solutions: {0}\n\n", eightQueens.Solutions.Count));
            for (int sid = 0; sid < eightQueens.Solutions.Count; sid++)
            {
                Console.Write(string.Format("Solution {0}:\n", sid + 1));
                eightQueens.PrintSolution(eightQueens.Solutions[sid]);
                Console.WriteLine();
            }
        }
    }
}

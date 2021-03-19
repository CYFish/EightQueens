using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    class EightQueens
    {
        /// <summary>
        /// 皇后數量
        /// </summary>
        public int QueenCount { get; private set; } = 0;
        /// <summary>
        /// 解法清單，每一列都代表一種解法
        /// </summary>
        public List<List<int>> Solutions { get; private set; } = new List<List<int>>();

        public EightQueens(int queenCount)
        {
            Solutions = new List<List<int>>();
            QueenCount = queenCount;
        }

        /// <summary>
        /// 放置皇后於傳入的列
        /// <param name="Queens">已擺放的皇后座標陣列</param>
        /// <param name="currentRow">要檢查的棋盤列</param>
        /// </summary>
        public void PlaceQueen(int[] Queens, int currentRow)
        {
            for (int cid = 0; cid < QueenCount; cid++)
            {
                if (!CheckCell(Queens, currentRow, cid)) continue;

                Queens[currentRow] = cid;

                if (currentRow == QueenCount - 1) // 目前這列已經是最後一列，表示已取得一個解法
                    Solutions.Add(Queens.ToList());
                else
                    PlaceQueen(Queens, currentRow + 1);
            }
        }

        /// <summary>
        /// 列印解法
        /// <param name="Queens">已擺放的皇后座標清單</param>
        /// </summary>
        public void PrintSolution(List<int> Queens)
        {
            for (int rid = 0; rid < QueenCount; rid++)
            {
                for (int cid = 0; cid < QueenCount; cid++)
                    Console.Write(cid == Queens[rid] ? "Q" : "*");

                Console.WriteLine();
            }
        }

        private bool CheckCell(int[] Queens, int checkRow, int checkColumn)
        {
            for (int rid = 0; rid < checkRow; rid++)
            {
                #region 檢查同行是否已經有皇后（往上檢查）
                if (Queens[rid] == checkColumn)
                    return false;
                #endregion

                #region 檢查左上右下對角線是否已經有皇后（往左上檢查）
                if (checkColumn - Queens[rid] == checkRow - rid)
                    return false;
                #endregion

                #region 檢查右上左下對角線是否已經有皇后（往右上檢查）
                if (Queens[rid] - checkColumn == checkRow - rid)
                    return false;
                #endregion
            }

            return true;
        }
    }
}

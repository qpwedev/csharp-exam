// 3

using System;

class Program {
    static void Main(string[] args) {
        int[,] matrix = { { 1, 1, 0 }, { 1, 1, 0 }, { 1, 1, 0 } }; 
        Console.WriteLine(largest_submatrix(matrix));
    }

    public static (int, int, int, int) largest_submatrix(int[,] m) {
        int matrixSize = m.GetLength(0);
        int[,] newMatrix = new int[matrixSize, matrixSize];
        for (int i = 0; i < matrixSize; ++i) { newMatrix[i, 0] = m[i, 0]; }
        for (int i = 0; i < matrixSize; ++i) { newMatrix[0, i] = m[0, i]; }
        for (int i = 1; i < matrixSize; ++i) {
            for (int j = 1; j < matrixSize; ++j) {
                if (m[i, j] == 1) { newMatrix[i, j] = Math.Min(newMatrix[i, j - 1], Math.Min(newMatrix[i - 1, j], newMatrix[i - 1, j - 1])) + 1; }
                else { newMatrix[i, j] = 0; }
            }
        }

        int ulci; int ulcj; int maxi = 0; int lrci = 0; int lrcj = 0;
        for (int i = 0; i < matrixSize; ++i) {
            for (int j = 0; j < matrixSize; ++j) {
                if (newMatrix[i, j] > maxi) {
                    maxi = newMatrix[i, j];
                    lrci = i; lrcj = j;
                }
            }
        }
        return (lrcj - (maxi - 1), lrci - (maxi - 1), lrcj, lrci);
    }
}

// 4
// Unfortunately it doesn't work as it should, but there isn't enough time to fix it

using System;
using System.Collections.Generic;

class Game {
    int counter = 0;
    public int turn = 1;
    public int m = 10;
    public int n = 6;
    public int winner = 0;
    public Game() { }

    public Game clone() {
        Game g = new Game();
        g.counter = counter; 
        g.winner = winner;
        g.turn = turn; 
        g.m = m; 
        g.n = n; 
        return g;
    }

    public List<int> possibleMoves() {
        List<int> output = new List<int>();
        for (int i = 1; i < (Math.Max(m, n) * Math.Max(m, n)); i++) output.Add(i);
        return output;
    }

    public bool checkForWin() {
        if (m == 0 || n == 0) {
            winner = winner == 1 ? 2 : 1;
            return true;
        }
        else { return false; }
    }
}

class TwentyOne {

    static void Main() {
        Console.WriteLine(firstWins());
    }

    static int minimax(Game game, out int best) {
        best = 0;
        game.checkForWin();
        if (game.winner > 0) return game.winner == 1 ? 1 : -1;
        int val = game.turn == 1 ? int.MinValue : int.MaxValue;
        foreach (var item in game.possibleMoves()) {
            Game g1 = game.clone();
            g1.m -= item;
            g1.n -= item;
            int v = minimax(g1, out int f);
            if (game.turn == 1 && v > val || game.turn == 2 && v < val) { val = v; best = item; }
        }
        return val;
    }

    static bool firstWins() {
        Game g = new Game();
        if (minimax(g, out int best) > 0) return true;
        return false;
    }
}
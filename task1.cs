// 1

using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        List<string> input = new List<string>();
        List<string> output = new List<string>();
        
        while (true) {
            string line = Console.ReadLine();
            if (line == null) { break; }
            string[] arrline = line.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arrline) { input.Add(item); }
        }

        foreach (var item in input) {
            if (!dict.ContainsKey(item)) { dict.Add(item, 1); output.Add(item); }
            else {
                int value;
                dict.TryGetValue(item, out value);
                dict[item] = value + 1;
            }
        }

        foreach (var item in output) { if (dict[item] == 1) { Console.WriteLine(item); } }
    }
}
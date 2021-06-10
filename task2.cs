// 2

using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Array2<int> myarray = new Array2<int>();
        Console.WriteLine( myarray.Length );
        myarray.Add(4);
        myarray.Insert(5);
        
    }
}

class Array2<T> {
    private int length;
    private int backwardLen;
    private List<T> forward;
    private List<T> backward;
    public delegate T Function(T x);

    public int Length{ get { return length; } }

    public Array2() {
        backward = new List<T>();
        forward = new List<T>();
        backwardLen = 0;
        length = 0;
	}

    public void Insert(T item) {
        backward.Add(item);
        ++backwardLen;
        ++length;
    }

    public void Add(T item) {
        forward.Add(item);
        ++length;
    }

    public T this[int index] {
        get { if (index >= backwardLen) { index -= backwardLen; return forward[index]; } 
            else { index = (backwardLen-1) - index; return backward[index]; }
        }
        set {
            if (index >= backwardLen) { index -= backwardLen; forward[index] = value; } 
            else { index = (backwardLen-1) - index; backward[index] = value; }
		}
	}

    public void Apply( Function function) {
        for (int i = backwardLen-1; i >= 0; i--) {
            backward[i] = function(backward[i]);
        }
        for (int i = 0; i < length- backwardLen; i++) {
            forward[i] = function(forward[i]);
        }
    }
}
using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            Graph g = new Graph();
            FileHandler f = new FileHandler();
            f.readPopulation(g, "../doc/Populasi.txt", input);
            f.readGraph(g, "../doc/Graf.txt");
            g.printAll();
            Console.WriteLine("Hello World!");
            g.BFS();
        }
    }
}

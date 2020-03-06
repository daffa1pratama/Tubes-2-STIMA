using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            FileHandler f = new FileHandler();
            f.readPopulation(g, "../doc/Populasi.txt");
            f.readGraph(g, "../doc/Graf.txt");
            // g.printCity();
            // System.Console.WriteLine(g.initialCity);
            Console.WriteLine("Hello World!");
        }
    }
}

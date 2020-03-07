using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("========================= PLAGUE INC SIMULATOR ============================");
            System.Console.WriteLine("Visualisasi Hari ke-berapa?");
            System.Console.Write(">> ");
            int input = Convert.ToInt32(Console.ReadLine());
            Graph g = new Graph();
            FileHandler f = new FileHandler();
            f.readPopulation(g, "../doc/Populasi.txt", input);
            f.readGraph(g, "../doc/Graf.txt");
            g.BFS(input);
        }
    }
}

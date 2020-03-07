using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace src
{
    class FileHandler 
    {
        public void readGraph(Graph g, string filepath)
        {
            string [] lines = File.ReadAllLines(filepath);
            string [] temp = new string[lines.Length-1];
            
            for (int i = 0; i < lines.Length-1; i++)
            {
                temp[i] = lines[i+1];
            }

            foreach (string item in temp)
            {
                string[] splitted = item.Split(' ');
                Neighbor neighbor = new Neighbor(Convert.ToChar(splitted[1]), Convert.ToDouble(splitted[2]));
                neighbor.isInfected(g.listOfCity.Find(x => x.cityName == Convert.ToChar(splitted[0])).infectedPopulation);
                g.listOfCity.Find(x => x.cityName == Convert.ToChar(splitted[0])).listOfNeighbor.Add(neighbor);
            }
        }

        public void readPopulation(Graph g, string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            string[] temp = new string[lines.Length - 1];
            for (int i = 0; i < lines.Length-1; i++)
            {
                temp[i] = lines[i+1];
            }

            foreach (string item in temp)
            {
                string[] splitted = item.Split(' ');
                City city = new City(Convert.ToChar(splitted[0]), Convert.ToDouble(splitted[1]));
                g.listOfCity.Add(city);
            }

            lines = lines[0].Split(' ');            
            Graph.initialCity = Convert.ToChar(lines[1]);
        }
    }
}
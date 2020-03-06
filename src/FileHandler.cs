// using System;
// using System.IO;
// using System.Collections.Generic;
// using System.Linq;

// namespace src
// {
//     class FileHandler 
//     {
//         public void ReadGraph(string filepath)
//         {
//             System.Console.WriteLine("coba");
//             string [] lines = File.ReadAllLines(filepath);
//             char [] node = new char[Convert.ToInt32(lines[0])];
//             string [] temp = new string[lines.Length-1];
//             List<TrailElement> containerTrail = new List<TrailElement>();
            
//             for (int i = 0; i < lines.Length-1; i++)
//             {
//                 temp[i] = lines[i+1];
//                 node[i] = lines[i+1][0];
//             }

//             foreach (string j in temp)
//             {
//                 string [] temporary = j.Split(' ');
//                 foreach (string i in temporary)
//                 {
//                     System.Console.WriteLine(i);
//                 }
//                 TrailElement trail = new TrailElement(temporary[1], temporary[2]);
//                 containerTrail.Add(trail);

//                 System.Console.WriteLine("=======");
//             }

//             foreach (TrailElement i in containerTrail)
//             {
//                 i.PrintElement();   
//             }

//             List<GraphElement> ListElement = new List<GraphElement>();
//             int i = 0
//             foreach (TrailElement trail in containerTrail)
//             {
//                 if (i == 0) {
//                     GraphElement elm = new GraphElement(node[i], )
//                     ListElement.Add()
//                 }
//             }
//         }
//     }
// }

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
            g.initialCity = Convert.ToChar(lines[1]);
        }
    }
}
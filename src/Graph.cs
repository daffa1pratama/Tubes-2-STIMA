using System;
using System.Collections.Generic;

namespace src
{
    // class TrailElement
    // {
    //     public char Succ { get; set; }
    //     public double Probs { get; set; }
    //     public TrailElement (string Succ, string Probs)
    //     {
    //         this.Succ = Convert.ToChar(Succ);
    //         this.Probs = Convert.ToDouble(Probs);
    //     }
    //     public void PrintElement ()
    //     {
    //         System.Console.WriteLine($"Succ : {this.Succ} , Probs : {this.Probs}");
    //     }
    // }
    
    // class GraphElement
    // {
    //     public char Node { get; set; }
    //     public List<TrailElement> NextNode;
    //     public GraphElement (char Node, List<TrailElement> NextNode)
    //     {
    //         this.Node = Node;
    //         this.NextNode = NextNode;
    //     }
    //     public void PrintElement ()
    //     {
    //         System.Console.Write(this.Node);
    //         foreach (TrailElement elm in NextNode)
    //         {
    //             elm.PrintElement();
    //         }
    //     }
    // }

    // class Graph
    // {
    //     public List<GraphElement> ListElement;
    //     public Graph (List<GraphElement> ListElement)
    //     {
    //         this.ListElement = ListElement;
    //     }   
    // }
    
    class City
    {
        // PROPERTY
        public char cityName { get; set; } // Nama Kota ; A
        public double population { get; set; } // Populasi Kota ; P(A)
        public List<Neighbor> listOfNeighbor { get; set; } // Container Tetangga
        public int infectedDay { get; set; } // Hari terinfeksi ; t(A)
        public bool isVisited { get; set; } // Kondisi kota pernah dikunjungi

        // METHOD
        public City(char cityName, double population)
        {
            this.listOfNeighbor = new List<Neighbor>();
            this.cityName = cityName;
            this.population = population;
            this.infectedDay = 0;
        }
        public double calcInfected()
        {
            double temp = 1 + ((this.population - 1) * Math.Pow(2.71, -0.25 * this.infectedDay));
            return this.population / temp;
        }

        public void displayCity()
        {
            System.Console.WriteLine("City Name: " + cityName);
            System.Console.WriteLine("Population: " + population);
            System.Console.WriteLine("Infected Day: " + infectedDay);
            System.Console.WriteLine("Infected Population: " + calcInfected());
        }

        public void printNeighbor()
        {
            foreach (Neighbor item in listOfNeighbor)
            {
                item.displayNeighbor();
            }
        }

    }

    class Neighbor
    {
        // PROPERTY
        public char neighborName { get; set; }
        public double travelProb { get; set; }
        public bool infected { get; set; }
        public void displayNeighbor()
        {
            System.Console.WriteLine("Neighbor Name: " + neighborName);
            System.Console.WriteLine("Travel Probability: " + travelProb);
        }   

        // METHOD
        public Neighbor(char neighborName, double travelProb)
        {

            this.neighborName = neighborName;
            this.travelProb = travelProb;
        }
    }

    class Graph 
    {
        public List<City> listOfCity { get; set; }
        public char initialCity { get; set; }
        public Graph() {
            this.listOfCity = new List<City>();
            this.initialCity = 'A';
        }
        public Graph(char city)
        {
            this.initialCity = city;
        }
        public void printCity()
        {
            foreach (City item in listOfCity)
            {
                item.displayCity();
            }
        }
    }
}



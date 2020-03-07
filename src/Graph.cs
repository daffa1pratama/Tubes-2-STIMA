using System;
using System.Collections.Generic;

namespace src
{   
    class City
    {
        // PROPERTY
        public char cityName { get; set; } // Nama Kota ; A
        public double population { get; set; } // Populasi Kota ; P(A)
        public List<Neighbor> listOfNeighbor { get; set; } // Container Tetangga
        public int infectedDay { get; set; } // Hari awal terinfeksi ; T(A)
        public int infectedDuration {get; set;} // Durasi Terinfeksi hingga akhir perhitungan; t(A)
        public double infectedPopulation { get; set; } // Populasi yang terinfeksi
        public bool isVisited { get; set; } // Kondisi kota pernah dikunjungi

        // METHOD
        public City(char cityName, double population, int infectedDay, int input)
        {
            this.listOfNeighbor = new List<Neighbor>();
            this.cityName = cityName;
            this.population = population;
            this.infectedDay = infectedDay;
            this.infectedDuration = input - this.infectedDay;
            this.infectedPopulation = calcInfected();
            this.i
        }
        public double calcInfected()
        {
            double temp = 1 + ((this.population - 1) * Math.Pow(Math.e, -0.25 * this.infectedDuration));
            return this.population / temp;
        }

        public void displayCity()
        {
            System.Console.WriteLine("City Name: " + cityName);
            System.Console.WriteLine("Population: " + population);
            System.Console.WriteLine("Infected Day: " + infectedDay);
            System.Console.WriteLine("Infected Population: " + infectedPopulation);
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
            System.Console.WriteLine("Infected: " + Convert.ToString(infected));
        }   

        // METHOD
        public Neighbor(char neighborName, double travelProb)
        {
            this.neighborName = neighborName;
            this.travelProb = travelProb;
        }

        public void isInfected(double infectedPopulation)
        {
            double S = infectedPopulation * travelProb;
            System.Console.WriteLine(infectedPopulation);
            this.infected = false;
            if (S > 1) {
                this.infected = true;
            }
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
        public void printAll()
        {
            foreach (City city in listOfCity)
            {
                System.Console.WriteLine("==========CITY==========");
                city.displayCity();
                System.Console.WriteLine("========NEIGHBOR========");
                foreach (Neighbor neighbor in city.listOfNeighbor)
                {
                    neighbor.displayNeighbor();
                }
                System.Console.WriteLine("=========================");
            }
        }
    }
}



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
        public City(char cityName, double population, int input)
        {
            this.listOfNeighbor = new List<Neighbor>();
            this.cityName = cityName;
            this.population = population;
            this.infectedDay = 1;
            this.infectedDuration = input - this.infectedDay;
            this.infectedPopulation = calcInfected();
        }
        public double calcInfected()
        {
            double temp = 1 + ((this.population - 1) * Math.Exp(-0.25 * this.infectedDuration));
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

        public bool infecting(Neighbor N)
        {
            double S = this.calcInfected() * N.travelProb;
            return (S > 1);
        }

        /* public int hitungLamaInfeksi()
        {
            int result = -4 * Math.log((city.population / infectedPopulation - 1) * (1 / (x - 1)));

        } */
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

        public void isInfected(double infectedPopulation) //parameter city asal
        {
            double S = infectedPopulation * travelProb;
            this.infected = false;
            if (S > 1) 
            {
                this.infected = true;    
                /* 
                city.infectedDay = -4 * Math.log((city.population/infectedPopulation - 1) * (1/(x-1)));
                */
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

        public void BFS()
        {
            // Inisialisasi Queue Awal
            Queue<Tuple<char, char>> QueueBFS = new Queue<Tuple<char, char>>();
            
            foreach (Neighbor neighbor in listOfCity.Find(x => x.cityName == this.initialCity).listOfNeighbor)
            {
                Tuple<char, char> init = new Tuple<char, char>(this.initialCity, neighbor.neighborName);                
                QueueBFS.Enqueue(init);
            }

            // Debug Inisialisasi Queue Awal
            System.Console.Write("Queue : {");
            foreach (Tuple<char,char> elmt in QueueBFS)
            {
                System.Console.Write("<" + elmt.Item1 + "," + elmt.Item2 + ">");

            }
            System.Console.WriteLine("}");

            System.Console.WriteLine(QueueBFS.Count);
            // Proses BFS
            while(QueueBFS.Count != 0)
            {
                Tuple<char, char> temp = QueueBFS.Dequeue();
                char newCity = temp.Item2;
                
                // Check city infecting
                foreach (Neighbor neighbor in listOfCity.Find(x => x.cityName == newCity).listOfNeighbor)
                {
                    char newNeighbor = neighbor.neighborName;
                    if (listOfCity.Find(x => x.cityName == newCity).infecting(listOfCity.Find(x => x.cityName == newCity).listOfNeighbor.Find(x => x.neighborName == newNeighbor))) {
                        Tuple<char, char> newTuple = new Tuple<char, char>(newCity, newNeighbor);
                        QueueBFS.Enqueue(newTuple);
                    }
                }


            }

            System.Console.Write("Queue : {");
            foreach (Tuple<char,char> elmt in QueueBFS)
            {
                System.Console.Write("<" + elmt.Item1 + "," + elmt.Item2 + ">");

            }
            System.Console.WriteLine("}");
            
        }


    }
}



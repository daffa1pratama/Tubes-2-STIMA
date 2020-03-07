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
            System.Console.WriteLine(infectedPopulation);
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

        public Tuple<char,char> constructTuple(City A, Neighbor B)
        {
            foreach (City city in listOfCity)
            {
                if (A.cityName == city.cityName)
                {
                    foreach (Neighbor neighbor in city.listOfNeighbor)
                    {
                        var Elmt = Tuple.Create(city.cityName, neighbor.neighborName);
                    }
                    break;
                }
                break;
            }
            return Elmt;
        }

        public void BFS()
        {
            /* Inisialisasi Queue Awal */
            Queue<Tuple<char,char>> QueueBFS = new Queue<Tuple<char,char>>();
            foreach (City city in listOfCity)
            {
                if (this.initialCity == city.cityName)
                {
                    foreach (Neighbor neighbor in city.listOfNeighbor)
                    {
                        var QueueElmt = Tuple.Create(city.cityName, neighbor.neighborName);
                        QueueBFS.Enqueue(QueueElmt);
                    }
                }
                break;
            }

            /* Debug Inisialisasi Queue Awal */
            System.Console.Write("Queue : (");
            foreach (Tuple<char,char> elmt in QueueBFS)
            {
                System.Console.Write("<" + elmt.Item1 + "," + elmt.Item2 + ">");

            }
            System.Console.WriteLine(")");

            /* Proses BFS */
            while(QueueBFS.Count != 0)
            {
                Tuple<char, char> tupleElmt = QueueBFS.Dequeue;
                
                foreach(City city in listOfCity)
                {
                    if(city.cityName == tupleElmt.Item1)
                    {
                        foreach(Neighbor neighbor in city.listOfNeighbor)
                        {
                            if(neighbor.neighborName == tupleElmt.Item2)
                            {
                                /* Apabila Berhasil Menginfeksi */
                                if (city.infecting(neighbor))
                                {
                                    /* Add Neighbor to Queue */
                                    foreach(City InfectedCity in listOfCity)
                                    {
                                        if(InfectedCity.cityName == tupleElmt.Item2)
                                        {

                                        }
                                        break;
                                    }

                                    /* Ubah Elemen City yang Terinfeksi */
                               

                                    
                                }
                            }
                            break;
                        }
                    }
                    break;
                }

            }

            
        }


    }
}



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
        public bool infected { get; set; } // Apakah kota sudah terinfeksi

        // METHOD
        public City(char cityName, double population, int input)
        {
            this.listOfNeighbor = new List<Neighbor>();
            this.cityName = cityName;
            this.population = population;
            this.infectedDay = 0;
            this.infectedDuration = input - this.infectedDay;
            this.infectedPopulation = 0;
            this.infected = false;
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
            System.Console.WriteLine("Infected?: " + infected);
            if(infected){
                System.Console.WriteLine("Infected Day: " + infectedDay);
                System.Console.WriteLine("Infected Duration : " + infectedDuration);
                System.Console.WriteLine("Infected Population: " + infectedPopulation);
            }
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

        public int lamaInfeksi(Neighbor N)
        {
            if (this.infectedPopulation == 0)
            {
                System.Console.WriteLine("asdasd");
                return 0;    
            }
            double res = (-4 * Math.Log((this.population / this.infectedPopulation - 1) * (1 / (this.population - 1)), 2.781));
            System.Console.WriteLine("this.population : " + this.population);
            System.Console.WriteLine("this.infectedpopulation : " + this.infectedPopulation);
            System.Console.WriteLine("lama INfeksi : " + res);
            int result = Convert.ToInt32(res);
            System.Console.WriteLine("lama INfeksi : " + result);
            return  result;
        }
    }

    class Neighbor
    {
        // PROPERTY
        public char neighborName { get; set; }
        public double travelProb { get; set; }
        
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

        // public void isInfected(double infectedPopulation) //parameter city asal
        // {
        //     double S = infectedPopulation * travelProb;
        //     if (S > 1) 
        //     {
        //         this.infected = true;    
        //         
                //  city.infectedDay = -4 * Math.log((city.population/infectedPopulation - 1) * (1/(x-1)));
                // 
        //     }
        // }
        
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

        public void printQueueBFS(Queue<Tuple<char,char>> QueueBFS){
            System.Console.Write("Queue : {");
            foreach (Tuple<char,char> elmt in QueueBFS)
            {
                System.Console.Write("<" + elmt.Item1 + "," + elmt.Item2 + ">");

            }
            System.Console.WriteLine("}");
        }

        public void BFS(int input)
        {
            // Inisialisasi Queue Awal
            Queue<Tuple<char, char>> QueueBFS = new Queue<Tuple<char, char>>();
            listOfCity.Find(x => x.cityName == this.initialCity).infected = true;
            listOfCity.Find(x => x.cityName == this.initialCity).infectedPopulation = listOfCity.Find(x => x.cityName == this.initialCity).calcInfected();

            this.printAll();
            
            foreach (Neighbor neighbor in listOfCity.Find(x => x.cityName == this.initialCity).listOfNeighbor)
            {
                Tuple<char, char> init = new Tuple<char, char>(this.initialCity, neighbor.neighborName);                
                QueueBFS.Enqueue(init);
            }

            // Debug Inisialisasi Queue Awal
            printQueueBFS(QueueBFS);
            System.Console.WriteLine("============== PERSEBARAN DIMULAI =================");

            // Proses BFS
            while(QueueBFS.Count != 0)
            {
                Tuple<char, char> temp = QueueBFS.Dequeue();
                char infectingCityName = temp.Item1;
                char cityToInfectName = temp.Item2;

                /* Kalo berhasil menginfeksi kota dan kota yang terinfeksi belum terinfeksi sebelumnya */
                if ((listOfCity.Find(x=>x.cityName == infectingCityName).infecting(listOfCity.Find(x => x.cityName == infectingCityName).listOfNeighbor.Find(x => x.neighborName == cityToInfectName))) && (!listOfCity.Find(x => x.cityName == cityToInfectName).infected)){

                    System.Console.WriteLine("{0} berhasil menginfeksi {1}", infectingCityName, cityToInfectName);

                    /* ======================== QUEUE MANAGER ========================== */

                    /* Tambahkan <kota terinfeksi,tetangga dari kota terinfeksi> ke dalam queue */
                    foreach (Neighbor neighbor in listOfCity.Find(x => x.cityName == cityToInfectName).listOfNeighbor)
                    {
                        char infectedNeighbors = neighbor.neighborName;
                        Tuple<char, char> newTuple = new Tuple<char, char>(cityToInfectName, infectedNeighbors);
                        QueueBFS.Enqueue(newTuple);
                    }
                    /* Debug Queue */ 
                        printQueueBFS(QueueBFS);

                    /* ====================== ATTRIBUTE CHANGE MANAGER =========================== */
                    listOfCity.Find(x => x.cityName == cityToInfectName).infected = true;
                    listOfCity.Find(x => x.cityName == cityToInfectName).infectedDay = listOfCity.Find(x => x.cityName == infectingCityName).lamaInfeksi(listOfCity.Find(x => x.cityName == infectingCityName).listOfNeighbor.Find(x => x.neighborName == cityToInfectName)) + listOfCity.Find(x=>x.cityName == infectingCityName).infectedDay;
                    System.Console.WriteLine("Berapa nih Infected Day? " + listOfCity.Find(x => x.cityName == cityToInfectName).infectedDay);
                    listOfCity.Find(x => x.cityName == cityToInfectName).infectedDuration = input - listOfCity.Find(x => x.cityName == cityToInfectName).infectedDay;
                    System.Console.WriteLine("Berapa nih Infected Duration? " + listOfCity.Find(x => x.cityName == cityToInfectName).infectedDuration);
                    listOfCity.Find(x => x.cityName == cityToInfectName).infectedPopulation = listOfCity.Find(x => x.cityName == cityToInfectName).calcInfected();
                    
                }

                /* Kalo kota yang akan diinfeksi sudah terinfeksi sebelumnya */
                else if (listOfCity.Find(x => x.cityName == cityToInfectName).infected){

                    System.Console.WriteLine("Kota {0} sudah terinfeksi sebelumnya! Serangan tidak akan berpengaruh", cityToInfectName);
                    printQueueBFS(QueueBFS);

                }

                /* Kalo kota tidak berhasil diinfeksi */
                else {

                    System.Console.WriteLine("{0} tidak berhasil menginfeksi {1}", infectingCityName, cityToInfectName);
                    printQueueBFS(QueueBFS);

                }

            }
            this.printAll();
        }
    }
}



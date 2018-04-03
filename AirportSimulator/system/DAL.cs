﻿using AirportSimulator.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.system
{
    class DAL
    {
        Dictionary<int, string> Destinations = new Dictionary<int, string>();

        private void CreateOfferedDestinations()
        {
            Destinations.Add(0, "Alanya");
            Destinations.Add(1, "Bangkok");
            Destinations.Add(2, "Barcelona");
            Destinations.Add(3, "Beijing");
            Destinations.Add(4, "Florida");
            Destinations.Add(5, "Hawaii");
            Destinations.Add(6, "NewYork");
            Destinations.Add(7, "Paris");
            Destinations.Add(8, "Turkey");
        }
        public string GetDestination(int identifier)
        {
            CreateOfferedDestinations();
            if (Destinations.ContainsKey(identifier))
            {
                return Destinations.Values.ElementAt(identifier);
            }
            else
            {
                return "No destination found";
            }
        }

        public List<Terminal> CreateTerminals()
        {
            List<Terminal> terminalList = new List<Terminal>();
            foreach (KeyValuePair<int, string> destination in Destinations)
            {
                terminalList.Add( new Terminal(destination.Key));
            }
            return terminalList;
        }

        public void Departure(Luggage lug)
        {

        }
        public void TestDAl()
        {
            Debug.WriteLine(GetDestination(8));
        }
    }
}

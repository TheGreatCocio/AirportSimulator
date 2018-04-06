using AirportSimulator.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.system
{
    public class DAL
    {
        private static DAL instance;

        public static DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL();
                }
                return instance;
            }
        } 

        private DAL()
        {
            CreateOfferedDestinations();
            CreateFlightPlans();
        }

        private Dictionary<int, string> Destinations = new Dictionary<int, string>();
        private List<FlightPlan> flightPlanList = new List<FlightPlan>();

        // Creates all the destinations to a Dictionary
        private void CreateOfferedDestinations()
        {
            Destinations.Add(1, "Alanya");
            Destinations.Add(2, "Bangkok");
            Destinations.Add(3, "Barcelona");
            Destinations.Add(4, "Beijing");
            Destinations.Add(5, "Florida");
            Destinations.Add(6, "Hawaii");
            Destinations.Add(7, "NewYork");
            Destinations.Add(8, "Paris");
            Destinations.Add(9, "Turkey");
            Destinations.Add(10, "Russia");
        }        
        
        // Creates a Flight Plan for every Destination
        public void CreateFlightPlans()
        {            
            foreach (KeyValuePair<int, string> destination in Destinations)
            {
                flightPlanList.Add(new FlightPlan(destination.Key, destination.Value));
            }
        }

        // Creates A Terminal for every Flight Plan
        public List<Terminal> CreateTerminals()
        {
            List<Terminal> terminalList = new List<Terminal>();
            foreach (FlightPlan plan in flightPlanList)
            {                
                terminalList.Add( new Terminal(plan.TerminalNumber,plan));
            }
            return terminalList;
        }

        // Creates 4 new Counters
        public List<Counter> CreateCounters()
        {
            List<Counter> counterList = new List<Counter>();
            counterList.Add(new Counter());
            counterList.Add(new Counter());
            counterList.Add(new Counter());
            counterList.Add(new Counter());

            return counterList;
        }
    }
}

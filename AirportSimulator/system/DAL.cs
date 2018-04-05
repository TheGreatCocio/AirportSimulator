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
            Destinations.Add(0, "Alanya");
            Destinations.Add(1, "Bangkok");
            Destinations.Add(2, "Barcelona");
            Destinations.Add(3, "Beijing");
            Destinations.Add(4, "Florida");
            Destinations.Add(5, "Hawaii");
            Destinations.Add(6, "NewYork");
            Destinations.Add(7, "Paris");
            Destinations.Add(8, "Turkey");
            Destinations.Add(9, "Russia");
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

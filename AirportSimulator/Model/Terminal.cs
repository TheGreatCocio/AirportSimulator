using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class Terminal
    {
        private static int terminalNumberIncrementer = 1;
        private int terminalNumber, destination;
        private List<Luggage> luggageToBeBoarded;
        private Queue<Luggage> terminalConveyor;
        private FlightPlan flightPlan;
        private DateTime departure;
        private bool isOpen;

        public int TerminalNumber { get => terminalNumber; set => terminalNumber = value; }
        public int Destination { get => destination; set => destination = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public List<Luggage> LuggageToBeBoarded { get => luggageToBeBoarded; set => luggageToBeBoarded = value; }
        public Queue<Luggage> TerminalConveyor { get => terminalConveyor; set => terminalConveyor = value; }
        public FlightPlan FlightPlan { get => flightPlan; set => flightPlan = value; }

        public Terminal(int destination)
        {
            Destination = destination;
            TerminalNumber = terminalNumberIncrementer++;
            FlightPlan = new FlightPlan(TerminalNumber);
            Task task = Task.Factory.StartNew(TakeLuggageToPlane);
        }

        public async void TakeLuggageToPlane()
        {
            while (true)
            {
                if (luggageToBeBoarded.Count >= 40)
                {
                    IsOpen = false;
                    await Task.Delay(10000);
                    LuggageToBeBoarded.Clear();
                }
            }
        }

        public void DequeueLuggage()
        {
            LuggageToBeBoarded.Add(TerminalConveyor.Dequeue());
        }
    }
}

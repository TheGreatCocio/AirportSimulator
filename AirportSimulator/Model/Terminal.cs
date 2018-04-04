using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class Terminal
    {
        private static int terminalNumberIncrementer = 1;
        private int terminalNumber, destination;
        private List<Luggage> luggageToBeBoarded = new List<Luggage>();
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

        public Terminal(int destination,FlightPlan flightPlan)
        {
            Destination = destination;
            TerminalNumber = terminalNumberIncrementer++;
            //Task task = Task.Factory.StartNew(TakeLuggageToPlane);
            IsOpen = true;
            FlightPlan = flightPlan;
            Debug.WriteLine(FlightPlan);

           
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

        public void Close()
        {
            IsOpen = false;
            StateChanged?.Invoke(this, new StateEventArgs(IsOpen));
        }

        public event EventHandler StateChanged;
    }
}

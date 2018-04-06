using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class Terminal
    {
        private int terminalNumber;
        private List<Luggage> luggageToBeBoarded = new List<Luggage>();
        private Queue<Luggage> terminalConveyor;
        private FlightPlan flightPlan;
        private DateTime departure;
        private bool isOpen;        

        public int TerminalNumber { get => terminalNumber; set => terminalNumber = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;               
            }
        }
        public List<Luggage> LuggageToBeBoarded { get => luggageToBeBoarded; set => luggageToBeBoarded = value; }
        public Queue<Luggage> TerminalConveyor { get => terminalConveyor; set => terminalConveyor = value; }
        public FlightPlan FlightPlan { get => flightPlan; set => flightPlan = value; }

        public Terminal(int terminalNumber,FlightPlan flightPlan)
        {
            TerminalNumber = terminalNumber;
            IsOpen = true;
            FlightPlan = flightPlan;
            TerminalConveyor = new Queue<Luggage>();
            // Starts a new "Thread" there is running the async method "Terminaling"
            Task dequeue = Task.Factory.StartNew(Terminaling);
        }

        // Dequeues luggaage until it hits LuggageToBeBoarded hits 40, 
        //After 40 it takes the luggage to the plane, Waits 10 seconds and resets
        private async void Terminaling()
        {
            while (true)
            {
                if (IsOpen)
                {
                    if (TerminalConveyor.Count != 0 && LuggageToBeBoarded.Count < 40)
                    {
                        LuggageToBeBoarded.Add(TerminalConveyor.Dequeue());
                        TerminalChanged?.Invoke(this, new TerminalEventArgs(this));
                    }
                    else if (LuggageToBeBoarded.Count >= 40)
                    {
                        IsOpen = false;
                        TerminalChanged?.Invoke(this, new TerminalEventArgs(this));
                        await Task.Delay(10000);
                        LuggageToBeBoarded.Clear();
                        IsOpen = true;
                        TerminalChanged?.Invoke(this, new TerminalEventArgs(this));
                    }
                }
                await Task.Delay(1000);
            }
        }
        public event EventHandler TerminalChanged;
    }
}

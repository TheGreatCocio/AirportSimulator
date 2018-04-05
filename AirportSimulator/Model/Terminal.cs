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
    public class Terminal : INotifyPropertyChanged
    {
        private int terminalNumber;
        private List<Luggage> luggageToBeBoarded = new List<Luggage>();
        private Queue<Luggage> terminalConveyor;
        private FlightPlan flightPlan;
        private DateTime departure;
        private bool isOpen;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TerminalNumber { get => terminalNumber; set => terminalNumber = value; }
        public DateTime Departure { get => departure; set => departure = value; }
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
               
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isOpen"));
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
            Debug.WriteLine(FlightPlan);
            terminalConveyor = new Queue<Luggage>();
            Task toPlane = Task.Factory.StartNew(TakeLuggageToPlane);
            Task dequeue = Task.Factory.StartNew(DequeueLuggage);
        }

        

        private async void TakeLuggageToPlane()
        {
            while (true)
            {
                if (luggageToBeBoarded.Count >= 40)
                {
                    IsOpen = false;
                    await Task.Delay(10000);
                    LuggageToBeBoarded.Clear();
                    IsOpen = true;
                }
            }
        }        

        private async void DequeueLuggage()
        {
            while (true)
            {
                if (terminalConveyor.Count != 0)
                {
                    LuggageToBeBoarded.Add(TerminalConveyor.Dequeue());
                }
                await Task.Delay(100);
            }
        }                
    }
}

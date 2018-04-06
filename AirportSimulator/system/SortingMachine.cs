using AirportSimulator.Model;
using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Sorting Machine Singleton 
/// </summary>
namespace AirportSimulator.system
{
    public class SortingMachine
    {
        private static SortingMachine instance;
        public Queue<Luggage> Luggages = new Queue<Luggage>();
        List<Terminal> terminals = new List<Terminal>();

        public List<Terminal> Terminals { get => terminals; set => terminals = value; }

        public static SortingMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SortingMachine();
                }
                return instance;
            }
        }

        private SortingMachine()
        {
            // Starts a new "Thread" there is running the async method "SendToTerminal"
            Task task = Task.Factory.StartNew(SendToTerminal);
        }

        // Dequeues the Luggage that comes in the Luggages Queue from the counters and
        // Sends them to the correct terminal based on the destination on the Luggage
        public async void SendToTerminal()
        {
            while (true)
            {
                if (Luggages.Count != 0)
                {
                    Luggage suitCase = Luggages.Dequeue();
                    if (suitCase != null)
                    {
                        foreach (Terminal terminal in Terminals)
                        {
                            if (terminal.TerminalNumber.Equals(suitCase.Destination) && terminal.IsOpen)
                            {
                                terminal.TerminalConveyor.Enqueue(suitCase);
                                
                            }
                        }
                    }
                }
                await Task.Delay(200);
            }                                                    
        }
    }
}

using AirportSimulator.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.system
{
    public class SortingMachine
    {
        private static SortingMachine instance;
        private DAL dal = new DAL();
        public Queue<Luggage> Luggages = new Queue<Luggage>();
        List<Terminal> Terminals = new List<Terminal>();

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
            Terminals = dal.CreateTerminals();
            Debug.WriteLine("############## Count: " + Terminals.Count);
        }
        public void SendToTerminal(int dest)
        {
            if (Luggages.Count != 0)
            {
                Luggage suitCase = Luggages.Dequeue();
                foreach (Terminal terminal in Terminals)
                {
                    if (terminal.Destination.Equals(suitCase.Destination))
                    {
                        terminal.TerminalConveyor.Enqueue(suitCase);
                    }
                }
            }                                        
        }
    }
}

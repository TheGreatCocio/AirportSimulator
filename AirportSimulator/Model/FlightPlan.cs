using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class FlightPlan
    {
        private int terminalNumber;
        private DateTime timeBeforeLiftoff;

        public int TerminalNumber { get => terminalNumber; set => terminalNumber = value; }
        public DateTime TimeBeforeLiftoff { get => timeBeforeLiftoff; private set => timeBeforeLiftoff = value; }

        public FlightPlan(int terminalNumber)
        {
            TerminalNumber = terminalNumber;
        }

        public void NewPlane()
        {
            TimeBeforeLiftoff = DateTime.UtcNow.AddSeconds(60);
        }
    }
}

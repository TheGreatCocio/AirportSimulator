using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    class StateEventArgs : EventArgs
    {
        bool state;

        public bool State { get => state; set => state = value; }

        public StateEventArgs(bool state)
        {
            state = State;
        }
    }
}

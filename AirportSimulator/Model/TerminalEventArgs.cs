using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class TerminalEventArgs : EventArgs
    {
        private Terminal terminal;

        public Terminal Terminal { get => terminal; set => terminal = value; }

        public TerminalEventArgs(Terminal terminal)
        {
            Terminal = terminal;
        }
    }
}

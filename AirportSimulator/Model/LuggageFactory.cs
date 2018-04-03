using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class LuggageFactory
    {
        Random rnd = new Random();

        public Luggage CreateLuggage()
        {
            int num = rnd.Next(1, 9);
            return new Luggage(num);
        }
    }
}

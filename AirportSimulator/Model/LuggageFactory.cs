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

        // Creates and returns a new Luggage object with a random destination Destination
        public Luggage CreateLuggage()
        {
            int num = rnd.Next(1, 11);
            return new Luggage(num);
        }
    }
}

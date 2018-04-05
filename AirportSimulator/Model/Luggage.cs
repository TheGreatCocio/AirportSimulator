using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class Luggage
    {
        private static List<int> usedIds = new List<int>();
        private int id;
        private int destination;

        public int Id { get => id; set => id = value; }
        public int Destination { get => destination; set => destination = value; }

        public Luggage(int destination)
        {
            Destination = destination;
            //id = LuggageIdGenerator();
        }

        /*private int LuggageIdGenerator()
        {
            Random rnd = new Random();
            int id = rnd.Next(100000, 999999);
            bool jackpot = true;
            do
            {
                if (!usedIds.Contains(id))
                {
                    jackpot = false;
                }
                else
                {
                    id = rnd.Next(100000, 999999);
                }
            } while (jackpot);
            usedIds.Add(id);
            return id;
        }*/
    }
}

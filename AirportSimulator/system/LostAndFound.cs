using AirportSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.system
{
    public class LostAndFound
    {
        private static LostAndFound instance;

        private List<Luggage> container;
        public List<Luggage> Container { get => container; set => container = value; }

        public static LostAndFound Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LostAndFound();
                }
                return instance;
            }
        }

        private LostAndFound()
        {
            Container = new List<Luggage>();
        }

        public void ContainLuggage(Luggage luggage)
        {
            Container.Add(luggage);
        } 
    }
}

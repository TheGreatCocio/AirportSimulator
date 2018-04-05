using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.Model
{
    public class Counter
    {
        private static int counterIncrementer = 1;
        private int counterId;
        private bool isOpen;
        LuggageFactory lf = new LuggageFactory();

        public int CounterId { get => counterId; set => counterId = value; }
        public bool IsOpen { get => isOpen; set => isOpen = value; }

        public Counter()
        {
            CounterId = counterIncrementer++;
            IsOpen = true;
            // Starts a new "Thread" there is running the async method "CreateLuggage"
            Task task = Task.Factory.StartNew(CreateLuggage);
        }

        // Creates New Luggage and adds it to a the sorting machine queue while its below 30
        public async void CreateLuggage()
        {
            while (true)
            {
                while (SortingMachine.Instance.Luggages.Count < 30)
                {
                    SortingMachine.Instance.Luggages.Enqueue(lf.CreateLuggage());
                    await Task.Delay(1000);
                }
                await Task.Delay(5000);
            }            
        }
    }
}

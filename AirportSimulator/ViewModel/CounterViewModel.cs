using AirportSimulator.Model;
using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportSimulator.ViewModel
{
    public class CounterViewModel : ViewModelBase
    {
        private bool _canExecuteMyCommand = true;
        private ObservableCollection<Counter> counters = new ObservableCollection<Counter>(DAL.Instance.CreateCounters());
        public ObservableCollection<Counter> Counters
        {
            get { return counters; }
            set
            {
                counters = value;
                OnPropertyChanged();
            }
        }

        public CounterViewModel()
        {

        }

        public ICommand openCloseCounter;
        public ICommand openCloseAllCounter;

        // Returns a command with a parameter witch is bound to a open/close Button
        public ICommand OpenCloseCounter
        {
            get
            {
                if (openCloseCounter == null)
                {
                    // Command that executes the OpenClose Method with a parameter
                    openCloseCounter = new RelayCommand<object>(OpenClose, () => _canExecuteMyCommand);
                }
                return openCloseCounter;
            }
        }

        // Returns a command with a parameter witch is bound to the open/close All Button
        public ICommand OpenCloseAllCounter
        {
            get
            {
                if (openCloseAllCounter == null)
                {
                    // Command that executes the OpenClose Method with a parameter
                    openCloseAllCounter = new RelayCommand<object>(OpenCloseAll, () => _canExecuteMyCommand);
                }
                return openCloseAllCounter;
            }
        }

        // A Method that opens a closed counter or closes a open counter
        private void OpenClose(object senderNumber)
        {
            // A Temp Collection
            ObservableCollection<Counter> temp = new ObservableCollection<Counter>(Counters);
            foreach (Counter count in temp)
            {
                // If the sending counter matches a counter in the collection then Open/Close and break
                if (count.CounterId.Equals(senderNumber))
                {
                    if (!count.IsOpen)
                    {
                        count.IsOpen = true;
                    }
                    else
                    {
                        count.IsOpen = false;
                    }

                    break;

                }
            }
            // The Bound Collection equals the temp collection
            Counters = temp;
        }

        // Opens or Closes all the counters
        private void OpenCloseAll(object sender)
        {
            // A Temp Collection
            ObservableCollection<Counter> temp = new ObservableCollection<Counter>(Counters);

            foreach (Counter count in temp)
            {
                if (!count.IsOpen)
                {
                    count.IsOpen = true;
                }
                else
                {
                    count.IsOpen = false;
                }
            }
            Counters = temp;
        }
    }
}

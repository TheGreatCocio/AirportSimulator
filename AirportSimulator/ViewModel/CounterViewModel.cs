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
        /// <summary>
        /// Returns a command with a parameter
        /// </summary>
        public ICommand OpenCloseCounter
        {
            get
            {
                if (openCloseCounter == null)
                {
                    openCloseCounter = new RelayCommand<object>(OpenClose, () => _canExecuteMyCommand);
                }
                return openCloseCounter;
            }
        }
        
        private void OpenClose(object senderNumber)
        {
            ObservableCollection<Counter> temp = new ObservableCollection<Counter>(Counters);
            foreach (Counter count in temp)
            {
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

            Counters = temp;
        }
    }
}

using System;
using AirportSimulator.system;
using AirportSimulator.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace AirportSimulator.ViewModel
{

    public class TerminalViewModel : ViewModelBase
    {
        private bool _canExecuteMyCommand = true;
        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>(DAL.Instance.CreateTerminals());
        public ObservableCollection<Terminal> Terminals
        {
            get { return terminals; }
            set
            {
                terminals = value;
                OnPropertyChanged();
            }
        }

        public TerminalViewModel()
        {
            foreach (Terminal term in Terminals)
            {
                SortingMachine.Instance.Terminals.Add(term);
            }
        }

        public ICommand closeTerminal;
        /// <summary>
        /// Returns a command with a parameter
        /// </summary>
        public ICommand CloseTerminal
        {
            get
            {
                if (closeTerminal == null)
                {
                    closeTerminal = new RelayCommand<object>(Close, () => _canExecuteMyCommand);
                }

                return closeTerminal;
            }
        }
        
        private void Close(object senderNumber)
        {
            ObservableCollection<Terminal> temp = new ObservableCollection<Terminal>(Terminals);
            foreach (Terminal term in temp)
            {
                if (term.TerminalNumber.Equals(senderNumber))
                {
                    if (term.IsOpen)
                    {
                        term.IsOpen = false;
                    }
                    else
                    {
                        term.IsOpen = true;
                    }
                    
                    break;
                }
            }
            Terminals = temp;
        }
    }
}

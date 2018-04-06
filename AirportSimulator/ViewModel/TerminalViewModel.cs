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
                // Updates The Sorting Machines List Of Terminals
                SortingMachine.Instance.Terminals.Add(term);
                // Set up listener to each Terminal
                term.TerminalChanged += TerminalChanged;
            }
        }

        public ICommand openCloseTerminal;

        // Returns a command with a parameter witch is bound to a open/close Button
        public ICommand OpenCloseTerminal
        {
            get
            {
                if (openCloseTerminal == null)
                {
                    // Command that executes the OpenClose Method with a parameter
                    openCloseTerminal = new RelayCommand<object>(OpenClose, () => _canExecuteMyCommand);
                }
                return openCloseTerminal;
            }
        }
        
        // A Method that opens a closed terminal or closes a open terminal
        private void OpenClose(object senderNumber)
        {
            // A Temp Collection
            ObservableCollection<Terminal> temp = new ObservableCollection<Terminal>(Terminals);
            foreach (Terminal term in temp)
            {
                // If the sending terminal matches a terminal in the collection then Open/Close and break
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
            // The Bound Collection equals the temp collection
            Terminals = temp;
        }

        // When a Change is happening in the terminal then run this.
        private void TerminalChanged(object sender, EventArgs e)
        {
            // A Temp Collection
            ObservableCollection<Terminal> temp = new ObservableCollection<Terminal>(Terminals);

            TerminalEventArgs tea = (TerminalEventArgs)e;
            if (tea != null)
            {
                // Set the temp terminal LuggageToBeBoarded to the senders LuggageToBeBoarded 
                foreach (Terminal term in temp)
                {
                    if (term.TerminalNumber.Equals(tea.Terminal.TerminalNumber))
                    {
                        term.LuggageToBeBoarded = tea.Terminal.LuggageToBeBoarded;
                    }
                }

                // The Bound Collection equals the temp collection
                Terminals = temp;
            }            
        }
    }
}

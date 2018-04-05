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
        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>();
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
            foreach (Terminal term in DAL.Instance.CreateTerminals())
            {
                Terminals.Add(term);
            };
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
            /*

            Debug.WriteLine("JUHU " + senderNumber);
            Terminal curr = null;
            foreach (Terminal term in Terminals)
            {
                if (term.TerminalNumber.Equals(senderNumber))
                {   
                   
                    term.IsOpen = false;
                    Debug.WriteLine("Terminal Closed!" + term.FlightPlan.Destination);
                    OnPropertyChanged("Terminals");
                  
                    curr = term;

                }

            }


            Terminals.Remove(curr);
            */


            //Working
            /*     Terminal curr = null;
                 int found = 0;
                 for (int i = 0; i < Terminals.Count; i++)
                 {
                     if (Terminals[i].TerminalNumber.Equals(senderNumber))
                     {
                         curr = Terminals[i];
                         curr.IsOpen = false;
                         found = i;
                         break;

                     }


                 }
                 Terminals.RemoveAt(found);
                 Terminals.Insert(found, curr);*/

            ObservableCollection<Terminal> temp = new ObservableCollection<Terminal>(Terminals);
            foreach (Terminal term in temp)
            {
                if (term.TerminalNumber.Equals(senderNumber))
                {

                    term.IsOpen = false;
                    break;

                }

            }

            Terminals = temp;
        }
    }
}

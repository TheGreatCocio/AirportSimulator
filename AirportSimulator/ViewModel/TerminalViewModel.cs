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

namespace AirportSimulator.ViewModel
{
    
    public class TerminalViewModel : ViewModelBase
    {
        private bool _canExecuteMyCommand = true;
        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>();
        public ObservableCollection <Terminal> Terminals
        {
            get { return terminals; }
            set
            {
                terminals = value;
                OnPropertyChanged();
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
                    closeTerminal = new RelayCommand<object>(Close);
                }

                return closeTerminal;
            }
        }       

        public TerminalViewModel()
        {
            foreach (Terminal term in DAL.Instance.CreateTerminals())
            {
                terminals.Add(term);
            };
        }

        private void Close(object senderNumber)
        {
            foreach (Terminal term in Terminals)
            {
                if (term.TerminalNumber.Equals(senderNumber))
                {
                    term.Close();
                }
            }
        }

        private void StateChanged(object sender, EventArgs e)
        {
            StateEventArgs sea = (StateEventArgs)e;
            foreach (Terminal term in Terminals)
            {
                if (term.Equals(sender))
                {
                    term.IsOpen = sea.State;
                }
            }
        }

    }
}

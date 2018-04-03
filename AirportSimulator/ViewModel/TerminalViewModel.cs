using System;
using AirportSimulator.system;
using AirportSimulator.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AirportSimulator.ViewModel
{
    
    public class TerminalViewModel : ViewModelBase
    {
        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>();
        public ObservableCollection <Terminal> Terminals
        {
            get { return terminals; }
            set { terminals = value; }
        }
        public TerminalViewModel()
        {
            foreach (Terminal term in DAL.Instance.CreateTerminals())
            {
                terminals.Add(term);
            };
        }

        void Close()
        {
             
        }



    }
}

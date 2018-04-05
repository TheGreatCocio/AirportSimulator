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

        //ObservableCollection<INotifyPropertyChanged> items = new ObservableCollection<INotifyPropertyChanged>();
        //items.CollectionChanged += items_CollectionChanged;       

        //static void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.OldItems != null)
        //    {
        //        foreach (INotifyPropertyChanged item in e.OldItems)
        //            item.PropertyChanged -= item_PropertyChanged;
        //    }
        //    if (e.NewItems != null)
        //    {
        //        foreach (INotifyPropertyChanged item in e.NewItems)
        //            item.PropertyChanged += item_PropertyChanged;
        //    }
        //}

        //static void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>();
        public ObservableCollection <Terminal> Terminals
        {
            get { return terminals; }
            set
            {
                foreach (Terminal terminal in terminals)
                {
                    OnPropertyChanged();                
                }
                terminals = value;
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
                    closeTerminal = new RelayCommand<object>(Close,  ()=> _canExecuteMyCommand);
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
                    term.IsOpen = false;
                    Debug.WriteLine("Terminal Closed!");
                }
            }
        }        
    }
}

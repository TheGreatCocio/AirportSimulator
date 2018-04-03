﻿using AirportSimulator.Model;
using AirportSimulator.system;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator.ViewModel
{
    public class FlightPlanViewModel : ViewModelBase
    {
        private ObservableCollection<FlightPlan> flightPlans = new ObservableCollection<FlightPlan>();

        public ObservableCollection<FlightPlan> FlightPlans { get => flightPlans; set => FlightPlans = value; }

        private void GetFlightPlans()
        {
            
        }

        public FlightPlanViewModel()
        {
            foreach (FlightPlan plan in DAL.Instance.CreateFlightPlans())
            {
                flightPlans.Add(plan);
            }
        }
    }
}

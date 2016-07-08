﻿using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBilling.Application
{
        public interface IProjectViewModel : IProject
        {
            Status EstimateStatus { get; set; }
        }

         public class ProjectViewModel : Notifier, IProjectViewModel
         {
             private int _id;
             private string _name;
             private double _estimate;
             private double _actual;
             private Status _estimateStatus = Status.None;

             public ProjectViewModel()
             { }

             public ProjectViewModel(IProject project)
             {
                 if (project == null)
                     return;
                 ID = project.ID;
                 Update(project);
             }

             public int ID
             {
                 get { return _id; }
                 set
                 {
                     _id = value;
                     NotifyPropertyChanged("Id");
                 }
             }

             public string Name
             {
                 get { return _name; }
                 set
                 {
                     _name = value;
                     NotifyPropertyChanged("Name");
                 }
             }

             public double Estimate
             {
                 get { return _estimate; }
                 set
                 {
                     _estimate = value;
                     NotifyPropertyChanged("Estimate");
                 }
             }

             public double Actual
             {
                 get { return _actual; }
                 set
                 {
                     _actual = value;
                     UpdateEstimateStatus();
                     NotifyPropertyChanged("Actual");
                 }
             }

             public Status EstimateStatus
             {
                 get { return _estimateStatus; }
                 set
                 {
                     _estimateStatus = value;
                     NotifyPropertyChanged("EstimateStatus");
                 }
             }

             public void Update(IProject project)
             {
                 ID = project.ID;
                 Name = project.Name;
                 Estimate = project.Estimate;
                 Actual = project.Actual;
             }

             private void UpdateEstimateStatus()
             {
                 if (Actual == 0)
                     EstimateStatus = Status.None;
                 else if (Actual <= Estimate)
                     EstimateStatus = Status.Good;
                 else
                     EstimateStatus = Status.Bad;
             }
         }

}

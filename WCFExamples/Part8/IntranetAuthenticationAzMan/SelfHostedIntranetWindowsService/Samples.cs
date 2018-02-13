﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace SampleService
{
    public class Samples : ISamples
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin Role")]
        public string GetSecretCode()
        {
            DisplaySecurityDetails();
            return "The Secret Code";
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Member Role")]
        public string GetMemberCode()
        {
            DisplaySecurityDetails();
            return "The Member-Only Code";
        }

        public string GetPublicCode()
        {
            DisplaySecurityDetails();
            return "The Public Code";
        }

        private static void DisplaySecurityDetails()
        {
            Console.WriteLine("Windows Identity = " +
            WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Thread CurrentPrincipal Identity = " +
            Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine("ServiceSecurityContext Primary Identity = " + 
                ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("ServiceSecurityContext Windows Identity = " + 
                ServiceSecurityContext.Current.WindowsIdentity.Name);
        }
    }
}
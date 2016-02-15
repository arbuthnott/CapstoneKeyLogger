﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class Personnel
    {
        //Members
        //int id;
        //string userName;
        //string password;
        //string firstName;
        //string lastName;
        //bool isAdmin;
        //int permitLevel;

        //Properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public int PermitLevel { get; set; }

        //Default constructor
        public Personnel()
        {
            Id = 0;
            UserName = "username";
            Password = "password";
            FirstName = "firstname";
            LastName = "lastname";
            IsAdmin = false;
            PermitLevel = 0;
        }

        //Constructor
        public Personnel(int pId, string pUserName, string pPassword, string pFirstName, string pLastName, bool pIsAdmin, int pPermitLevel)
        {
            Id = pId;
            UserName = pUserName;
            Password = pPassword;
            FirstName = pFirstName;
            LastName = pLastName;
            IsAdmin = pIsAdmin;
            PermitLevel = pPermitLevel;
        }


    }
}
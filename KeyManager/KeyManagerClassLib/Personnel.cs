using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class Personnel
    {
        //Members
        int id;
        string userName;
        string password;
        string firstName;
        string lastName;
        bool isAdmin;
        int permitLevel;

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
            id = 0;
            userName = "username";
            password = "password";
            firstName = "firstname";
            lastName = "lastname";
            isAdmin = false;
            permitLevel = 0;
        }

        //Constructor
        public Personnel(int pId, string pUserName, string pPassword, string pFirstName, string pLastName, bool pIsAdmin, int pPermitLevel)
        {
            id = pId;
            userName = pUserName;
            password = pPassword;
            firstName = pFirstName;
            lastName = pLastName;
            isAdmin = pIsAdmin;
            permitLevel = pPermitLevel;
        }


    }
}
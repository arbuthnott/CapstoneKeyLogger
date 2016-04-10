using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class Personnel : IComparable<Personnel>
    {
        //Properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public int PermitLevel { get; set; }

        //List Properties
        public List<Key> Keys { get; set; }
        public List<KeyRing> Keyrings { get; set; }

        /// <summary>
        /// Deletes this person from the db. No effect on OOP.
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            // TODO - consider whether people with active checkouts can be deleted!

            // TODO - consider whether the last user can be deleted!

            DataLayer dl = new DataLayer();
            dl.DeleteRecord("personnel", Id);
            return true;
        }

        /// <summary>
        /// Create or update this person in the database.
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("Username", UserName == null ? "NULL" : UserName);
            dl.AddValue("Password", Password == null ? "NULL" : Password);
            dl.AddValue("First Name", FirstName);
            dl.AddValue("Last Name", LastName);
            dl.AddValue("IsAdministrator", IsAdmin ? "1" : "0");
            dl.AddValue("PermitLevel", "" + PermitLevel);
            if (Id == -1)
            {
                Id = dl.AddRecord("personnel");
            }
            else
            {
                dl.AlterRecord("personnel", Id);
            }
        }

        //Default constructor
        public Personnel()
        {
            Id = -1;
            UserName = null;
            Password = null;
            FirstName = "New";
            LastName = "User";
            IsAdmin = false;
            PermitLevel = 0;
            Keys = new List<Key>();
            Keyrings = new List<KeyRing>();
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
            Keys = new List<Key>();
            Keyrings = new List<KeyRing>();
        }

        public int CompareTo(Personnel other)
        {
            if (this.LastName.CompareTo(other.LastName) != 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
        }
    }
}
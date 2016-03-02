using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagerData;

namespace KeyManagerClassLib
{
    public class Checkout : IComparable<Checkout>
    {
        //Properties
        public int Id { get; set; }
        public Personnel Person { get; set; }
        public Key Key { get; set; }
        public KeyRing KeyRing { get; set; }
        public bool IsReturned { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Deletes the checkout.  Does not update the OOP
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            DataLayer dl = new DataLayer();
            dl.DeleteRecord("checkout", Id);
            return true;
        }

        /// <summary>
        /// Saves this checkout if new, or updates if it already exists.
        /// </summary>
        public void Save()
        {
            DataLayer dl = new DataLayer();
            dl.AddValue("IsReturned", IsReturned ? "1" : "0");
            dl.AddValue("Date", Date.ToLongDateString());
            if (Person != null) // can happen if checkout references a Personnel that's been erased.
            {
                dl.AddValue("Person", "" + Person.Id);
            }
            if (Key != null)
            {
                dl.AddValue("Key", "" + Key.Id);
            }
            if (KeyRing != null)
            {
                dl.AddValue("Keyring", "" + KeyRing.Id);
            }

            if (this.Id == -1)
            {
                if (Person == null)
                {
                    dl.AddValue("Person", "0");
                }
                Id = dl.AddRecord("checkout");
            }
            else
            {
                dl.AlterRecord("checkout", Id);
            }
        }

        //Default Constructor
        public Checkout()
        {
            Id = 0;
            Person = new Personnel();
            Key = new Key();
            KeyRing = new KeyRing();
            IsReturned = false;
            Date = DateTime.Now;
        }

        //Constructor
        public Checkout(int pId, Personnel pPerson, Key pKey, KeyRing pKeyRing, bool isRet, DateTime pDate)
        {
            Id = pId;
            Person = pPerson;
            Key = pKey;
            KeyRing = pKeyRing;
            IsReturned = isRet;
            Date = pDate;
        }

        public int CompareTo(Checkout other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}

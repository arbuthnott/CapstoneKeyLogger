using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

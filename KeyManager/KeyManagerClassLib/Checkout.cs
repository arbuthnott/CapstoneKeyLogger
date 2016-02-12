using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class Checkout
    {
        //Members
        private int id;
        private Personnel person;
        private Key key;
        private KeyRing keyRing;
        private bool isReturned;
        private DateTime date;

        //Properties
        public int Id { get; set; }
        public Personnel MyProperty { get; set; }
        public Key Key { get; set; }
        public KeyRing KeyRing { get; set; }
        public bool IsReturned { get; set; }
        public DateTime Date { get; set; }

        //Default Constructor
        public Checkout()
        {
            id = 0;
            person = new Personnel();
            key = new Key();
            keyRing = new KeyRing();
            isReturned = false;
            date = DateTime.Now;
        }

        //Constructor
        public Checkout(int pId, Personnel pPerson, Key pKey, KeyRing pKeyRing, DateTime pDate)
        {
            id = pId;
            person = pPerson;
            key = pKey;
            keyRing = pKeyRing;
            isReturned = false;
            date = pDate;
        }
    }
}

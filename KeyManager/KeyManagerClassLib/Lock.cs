using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    class Lock
    {
        /*
        SUGGESTION: may not need this class!
        (change the Lock reference in Door class to an integer lockId)
        */

        //Members
        int id;

        //Properties
        public int Id { get; set; }

        //Default constructor
        public Lock()
        {
            id = 0;
        }

        //Constructor
        public Lock(int pId)
        {
            id = pId;
        }

    }


}
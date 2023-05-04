using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filozofowie
{
    class Cutlery
    {
        public int ID { get; private set; }
        public volatile bool isOnTheTable = true;
        private static int lastID=0;

        public Cutlery()
        {
            ID = lastID++;
        }

        public bool pickUP(Philosopher p)
        {
            lock (this)
            { 
                if (isOnTheTable)
                {
                    isOnTheTable = false;
                    return true;
                }
                return false;
            }
        }

        public bool putDown(Philosopher p)
        {
            lock (this)
            {
                //Console.WriteLine(String.Format("Putting down cutlery {0}  by philosopher {2}, that is:{1}", ID, isOnTheTable, p.ID));
                if (!isOnTheTable)
                {
                    isOnTheTable = true;
                    return true;
                }
                else
                {
                    throw new SystemException("ERROR " + ID +" ph "+p.ID);
                }
            }
        }
    }
}

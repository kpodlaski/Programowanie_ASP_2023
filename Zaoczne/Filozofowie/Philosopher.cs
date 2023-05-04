using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Filozofowie
{
    class Philosopher 
    {
        private Cutlery leftCutlery;
        private Cutlery rightCutlery;
        private Random rand = new Random();
        static int lastID =0;
        public int ID;

        public Philosopher(Cutlery left, Cutlery right)
        {
            leftCutlery = left;
            rightCutlery = right;
            ID = lastID++;
            Console.WriteLine(String.Format("Philosopher {0} have cutrery, on left {1}, on right {2}", ID, leftCutlery.ID, rightCutlery.ID));
        }

        public void Think()
        {
            Console.WriteLine(String.Format("Philosopher {0} is thinking now", this.ID));
            Thread.Sleep(rand.Next(5));
        }

        public void Eat()
        {
            Console.WriteLine(String.Format("Philosopher {0} picking up cutlery", this.ID, leftCutlery.ID));
            while (true)
            {
               if (leftCutlery.pickUP(this))
                {
                    break;
                }
            }
            //Console.WriteLine(String.Format("Philosopher is left cutlery {1} on table: {0}", leftCutlery.isOnTheTable, leftCutlery.ID));
            //Console.WriteLine(String.Format("Philosopher {0} picking up right cutlery {1}", this.ID, rightCutlery.ID));
            Thread.Sleep(1);
            while (true)
            {
                if (rightCutlery.pickUP(this))
                    break;
            }
            //Console.WriteLine(String.Format("Philosopher is left cutlery {1} on table: {0}", rightCutlery.isOnTheTable, rightCutlery.ID));
            Console.WriteLine(String.Format("Philosopher {0} is eating", this.ID, leftCutlery.isOnTheTable, rightCutlery.isOnTheTable));
            Thread.Sleep(rand.Next(5));
            //Console.WriteLine(String.Format("Philosopher {0} putting back cutlery", this.ID));
            rightCutlery.putDown(this);
            leftCutlery.putDown(this);
        }

        public void Life()
        {
            while (true)
            {
                Think();
                Eat();
                
                
            }
        }
    }
}

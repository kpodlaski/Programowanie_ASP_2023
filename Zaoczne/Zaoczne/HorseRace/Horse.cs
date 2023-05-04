using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaoczne.HorseRace
{
    class Horse
    {
        public int ID { get; private set; }
        private double speed;
        static int lastId = 0;
        double distance;
        public long finishTime { get; private set; } 

        public Horse(double speed)
        {
            ID = lastId++;
            this.speed = speed;
        }

        public void DoRace(Race race)
        {
            Console.WriteLine(String.Format(
                "Approaching start line {0}", ID));
            race.StartBarrier.SignalAndWait();
            racing(race);
            race.HorseFinished(this);
            //Console.WriteLine(String.Format("Horse {0} ended Race", ID));

        }

        private void racing(Race race)
        {
            while (distance < race.Distance)
            {
                distance += speed;
            }
            finishTime = DateTime.Now.Ticks;
        }


        private void racingWithLock(Race race)
        {
            bool isRunning = true;
            double distance = 0.0;
            while (isRunning)
            {
                //We check position twice, to ensure the best and shortest synchronization, no thread can interrupt between checking and getting ticks from the clock.
                //This approach will use synchronization so apriori each itertion of while will take longer time
                //Moreover checking distance twice also add some time to every iteration
                //We cold use one if, and put isRunning=false in the first one, but this would prolong lock time. So increase cost of synchronization.
                lock (race) { 
                    if (distance >= race.Distance)
                    {
                        finishTime = DateTime.Now.Ticks;
                    } 
                }
                if (distance >= race.Distance)
                {
                    isRunning = false;
                }
                else
                {
                    distance += speed;
                }
            }
        }

    }
}

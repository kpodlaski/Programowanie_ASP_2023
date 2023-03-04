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
            double distance = 0.0;
            race.StartBarrier.SignalAndWait();
            while (distance < race.Distance)
            {
                distance += speed;
            }
            finishTime = DateTime.Now.Ticks;
            race.HorseFinished(this);
            //Console.WriteLine(String.Format("Horse {0} ended Race", ID));

        }


    }
}

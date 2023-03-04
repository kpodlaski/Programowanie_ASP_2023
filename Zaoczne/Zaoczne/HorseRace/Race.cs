using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Zaoczne.HorseRace
{
    class Race
    {
        public double Distance = 1000;
        private List<Horse> horses = new List<Horse>();
        public Barrier StartBarrier, EndBarrier;
        private long startTime;

        public void SetUpRace()
        {
            
            Random rand = new Random();
            for (int i=0; i<5; i++)
            {
                Horse h = new Horse(rand.NextDouble()*50+1);
                horses.Add(h);
            }
            StartBarrier = new Barrier(horses.Count, (b) =>
            {
                Console.WriteLine("START !!!!");
                startTime = DateTime.Now.Ticks;
            });

            EndBarrier = new Barrier(horses.Count, (b) =>
            {
                Console.WriteLine("Results !!!!");
                printFinalResults();
            });
            foreach (Horse h in horses)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    h.DoRace(this);
                }));
                t.Start( );
            }
        }


        public void HorseFinished(Horse horse)
        {
            EndBarrier.SignalAndWait();
        }

        public void printFinalResults()
        {
            horses.Sort((h1, h2) => { return (int) (h1.finishTime - h2.finishTime); });
            for (int place = 1; place <= horses.Count; place++) {
                Horse horse = horses[place - 1];
                Console.WriteLine(String.Format("Place {0} Horse {1} with time:{2} ticks",
                    place, horse.ID, horse.finishTime - startTime));
            }
        }

    }
}

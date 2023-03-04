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

        public void SetUpRace()
        {
            
            Random rand = new Random();
            for (int i=0; i<5; i++)
            {
                Horse h = new Horse(rand.NextDouble()*50+1);
                horses.Add(h);
            }

            foreach(Horse h in horses)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    h.DoRace(this);
                }));
                t.Start();
            }
        }

        public void HorseFinished(Horse horse)
        {
            Console.WriteLine(String.Format("Horse {0} finished Race", horse.ID));
        }

    }
}

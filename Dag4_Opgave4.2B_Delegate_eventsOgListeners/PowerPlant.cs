using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4._2B_Delegate_eventsOgListeners
{
    public delegate void Warning();

    internal class PowerPlant
    {
        public Warning alarm;

        public void Setwarning(Warning wa)
        {
            alarm += wa;

        }

        public void HeatUp()
        {
            Random randomTal = new Random();
            int tal = randomTal.Next(0, 101);
            if (tal > 50)
            {
                alarm.Invoke();
            }
        }




    }
}

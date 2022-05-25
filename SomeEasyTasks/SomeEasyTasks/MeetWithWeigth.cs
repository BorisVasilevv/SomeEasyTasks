using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeEasyTasks
{

    public class Event
    {
        public int Profit;
        public int StartTime, FinishTime;
    }


    ///<summary>
    /// Search the most profitable way of visit non-overlapping appointments in time and output profit
    /// </summary>

    public class MeetWithWeigth
    {       
        private List<Event> Events=new List<Event>();

        public MeetWithWeigth(params Event[] inputEvents)
        {
            Events=inputEvents.ToList();
        }

        public int GetOptimalScheduleGain()
        {
            Event fakeBorderEvent = new Event { StartTime = int.MinValue, FinishTime = int.MinValue, Profit = 0 };
            Events = Events.Concat(new[] { fakeBorderEvent }).OrderBy(e => e.FinishTime).ToList();
            int[] opt = new int[Events.Count];
            opt[0] = 0; 
            for (int k = 1; k < Events.Count; k++)
            {
                int indexOfCompatibleEvent = Array.FindLastIndex(Events.ToArray(), x => x.FinishTime < Events[k].StartTime);
                opt[k] = Math.Max(opt[k - 1], opt[indexOfCompatibleEvent] + Events[k].Profit);
            }
            return opt.Last();
        }
    }
}

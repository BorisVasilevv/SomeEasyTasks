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

    public static class MeetWithWeigth
    {
        
        public static void Main()
        {
            Console.WriteLine(GetOptimalScheduleGain(new Event[0]));//0

            Console.WriteLine(GetOptimalScheduleGain(new Event { StartTime = 1, FinishTime = 11, Profit = 50 }));//50

            Console.WriteLine(GetOptimalScheduleGain(
                new Event { StartTime = 9, FinishTime = 11, Profit = 50 },
                new Event { StartTime = 10, FinishTime = 13, Profit = 190 },
                new Event { StartTime = 14, FinishTime = 17, Profit = 90 },
                new Event { StartTime = 12, FinishTime = 15, Profit = 200 },
                new Event { StartTime = 16, FinishTime = 18, Profit = 50 }));//300

            Console.WriteLine("OK");
        }


        public static int GetOptimalScheduleGain(params Event[] events)
        {
            // добавление fakeBorderEvent позволяет не обрабатывать некоторые граничные случаи
            Event fakeBorderEvent = new Event { StartTime = int.MinValue, FinishTime = int.MinValue, Profit = 0 };
            events = events.Concat(new[] { fakeBorderEvent }).OrderBy(e => e.FinishTime).ToArray();

            // OPT(k) = Max(OPT(k-1), w(k) + OPT(p(k))
            int[] opt = new int[events.Length];
            opt[0] = 0; // нулевым всегда будет fakeBorderEvent
            for (int k = 1; k < events.Length; k++)
            {
                int indexOfCompatibleEvent = Array.FindLastIndex(events, x => x.FinishTime < events[k].StartTime);
                opt[k] = Math.Max(opt[k - 1], opt[indexOfCompatibleEvent] + events[k].Profit);
            }
            return opt.Last();
        }
    }
}

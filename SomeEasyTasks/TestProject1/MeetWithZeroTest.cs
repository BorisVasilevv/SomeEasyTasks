using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeEasyTasks;

namespace TestProject1
{
    [TestClass]
    public class MeetWithZeroTest
    {
        [TestMethod]
        public void ZeroElements()
        {
            MeetWithWeigth meetWithWeigth = new MeetWithWeigth(new Event[0]);

           
            MeetCheck(0, meetWithWeigth);
        }
        
        [TestMethod]
        public void OneElement()
        {
            MeetWithWeigth  meetWithWeigth = new MeetWithWeigth(new Event { StartTime = 1, FinishTime = 11, Profit = 50 });
            
            MeetCheck(50, meetWithWeigth);
        }
        
        [TestMethod]
        public void StandartTest()
        {

            MeetWithWeigth meetWithWeigth = new MeetWithWeigth(
                    new Event { StartTime = 9, FinishTime = 11, Profit = 50 },
                    new Event { StartTime = 10, FinishTime = 13, Profit = 190 },
                    new Event { StartTime = 14, FinishTime = 17, Profit = 90 },
                    new Event { StartTime = 12, FinishTime = 15, Profit = 200 },
                    new Event { StartTime = 16, FinishTime = 18, Profit = 50 });
            MeetCheck(300, meetWithWeigth);
        }

        private void MeetCheck(int excpectedAnswer, MeetWithWeigth meetWithWeigth )
        {
            Assert.AreEqual(excpectedAnswer, meetWithWeigth.GetOptimalScheduleGain());
        }
    }
}
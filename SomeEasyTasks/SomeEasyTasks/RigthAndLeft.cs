using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeEasyTasks
{

    public static class RigthAndLeft
    {
        public static void Run()
        {

            string instruction = Console.ReadLine();
            StrangeQueue strangeQueue = new StrangeQueue();
            for (int i = 0; i < instruction.Length; i++)
            {
                strangeQueue.Add(instruction[i]);
            }
            strangeQueue.WriteQueue();
        }
    }

    class StrangeQueue
    {
        QueueItem Head = new QueueItem() { Value = 0 };
        QueueItem LastInput;
        int Count = 1;

        public void Add(char instruction)
        {
            if (Count == 1) LastInput = Head;
            QueueItem item = new QueueItem() { Value = Count };
            if (instruction == 'R')
            {
                if (LastInput.Right != null) item.Right = LastInput.Right;
                LastInput.Right = item;
                item.Left = LastInput;
                LastInput = item;
            }
            else if (instruction == 'L')
            {
                if (LastInput.Left != null)
                {
                    item.Left = LastInput.Left;
                    if (LastInput.Left.Right != null) LastInput.Left.Right = item;
                }
                LastInput.Left = item;
                item.Right = LastInput;
                LastInput = item;
            }
            else throw new Exception();
            Count++;
        }
        public void WriteQueue()
        {
            while (Head.Left != null)
                Head = Head.Left;
            while (Head.Right != null)
            {
                Console.Write(Head.Value);
                Console.Write(" ");
                Head = Head.Right;
            }
            Console.WriteLine(Head.Value);
        }
    }

    class QueueItem
    {
        public QueueItem Left;
        public QueueItem Right;
        public int Value;
    }
}

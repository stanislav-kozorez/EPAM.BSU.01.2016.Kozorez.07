using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Task1;
using Logic.Task2;
using Logic.Task3;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AlarmClock
            FirstSubscriber first = new FirstSubscriber();
            SecondSubscriber second = new SecondSubscriber();
            AlarmClock alarm = new AlarmClock(5);

            alarm.OnAlarm += second.Method;
            alarm.OnAlarm += second.Method;
            alarm.OnAlarm += first.Method;

            alarm.Start();
            Console.WriteLine();

            #endregion

            #region Fibonacci iterator

            foreach (var item in Fibonacci.GetFibonacciValues(20))
                Console.Write(item + "  ");
            Console.WriteLine();

            #endregion

            #region CustomQueue

            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(2);
            queue.Enqueue(92);

            Console.WriteLine("Queue size: {0}", queue.Count);
            Console.WriteLine("Peeked element: {0}", queue.Peek());
            Console.WriteLine("Queue size: {0}", queue.Count);
            Console.WriteLine("Dequeued element: {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element: {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element: {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element: {0}", queue.Dequeue());
            queue.Enqueue(-3);
            Console.WriteLine("Queue size: {0}\n", queue.Count);

            queue.Enqueue(57);
            queue.Enqueue(36);
            queue.Enqueue(22);
            queue.Enqueue(592);

            foreach (var item in queue)
                Console.Write("{0} ", item);

            Console.WriteLine();

            IEnumerator<int> iterator = queue.GetEnumerator();
            try
            {
                while (iterator.MoveNext())
                {
                    Console.Write("{0} ", iterator.Current);
                }
            }
            finally
            {
                iterator.Dispose();
            }

            #endregion

            Console.ReadKey();
        }
    }

    class FirstSubscriber
    {
        public void Method(object sender, AlarmClockEventArgs e)
        {
            Console.WriteLine("FirstSubscriber: Alarmed after {0} seconds", e.ElapsedSeconds);
        }
    }

    class SecondSubscriber
    {
        public void Method(object sender, AlarmClockEventArgs e)
        {
            Console.WriteLine("SecondSubscriber: Alarmed after {0} seconds", e.ElapsedSeconds);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task2
{
    public static class Fibonacci
    {
        public static IEnumerable<ulong> GetFibonacciValues(int valuesCount)
        {
            ulong lastButOneValue = 1;
            ulong lastValue = 1;
            ulong newValue;

            yield return 1;
            if (valuesCount < 2)
                yield break;
            yield return 1;

            for (int i = 0; i < valuesCount - 2; i++)
            {
                try
                {
                    checked
                    {
                        newValue = lastButOneValue + lastValue;
                    }
                }
                catch (OverflowException ex)
                {
                    throw new ArgumentException(nameof(valuesCount), ex);
                }
                yield return newValue;
                lastButOneValue = lastValue;
                lastValue = newValue;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task4
{
    public static class BinarySearch
    {
        public static int Start<T>(T[] arr, T element)
        {
            int index = -1;
            int first = 0;
            int last = arr.Length;
            int middle = 0;

            Comparer<T> c = Comparer<T>.Default;

            if ((arr.Length != 0) && (c.Compare(element, arr[0]) >= 0) && (c.Compare(element, arr[arr.Length - 1]) <= 0))
                while (first < last)
                {
                    middle = first + (last - first) / 2;

                    if (c.Compare(arr[middle], element) == -1)
                    {
                        first = middle + 1;
                    }
                    else if (c.Compare(arr[middle], element) == 1)
                    {
                        last = middle;
                    }
                    else
                    {
                        index = middle;
                        break;
                    }
                }

            return index;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task4
{
    public static class BinarySearch
    {
        public static int Start<T>(T[] arr, T element, IComparer<T> comparer)
        {
            if(comparer == null)
                if (typeof(T).GetInterface("IComparable") == null && typeof(T).GetInterface("IComparable`1") == null &&
                    typeof(T).GetInterface("IComparer") == null && typeof(T).GetInterface("IComparer`1") == null)
                    throw new ArgumentException("IComparable interface is not implemented");

            return SortImpl(arr, element, comparer ?? Comparer<T>.Default);
        }

        public static int Start<T>(T[] arr, T element, Comparison<T> comparison)
        {
            if (comparison == null)
                if (typeof(T).GetInterface("IComparable") == null && typeof(T).GetInterface("IComparable`1") == null &&
                    typeof(T).GetInterface("IComparer") == null && typeof(T).GetInterface("IComparer`1") == null)
                    throw new ArgumentException("IComparable interface is not implemented");
                else
                    return SortImpl(arr, element, Comparer<T>.Default);
            else
                return SortImpl(arr, element, Comparer<T>.Create(comparison));
        }

        private static int SortImpl<T>(T[] arr, T element, IComparer<T> c)
        {
            int index = -1;
            int first = 0;
            int last = arr.Length;
            int middle = 0;

            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task5
{
    public static class Sort
    {
        public static void BubbleSort<T>(IList<T> arr, IComparer<T> comparer)
        {
            if(comparer == null)
                if (typeof(T).GetInterface("IComparable") == null && typeof(T).GetInterface("IComparable`1") == null &&
                    typeof(T).GetInterface("IComparer") == null && typeof(T).GetInterface("IComparer`1") == null)
                    throw new ArgumentException("IComparable interface is not implemented");
            IComparer<T> c = comparer ?? Comparer<T>.Default;
            BubbleSortImpl(arr, c);
        }

        public static void BubbleSort<T>(IList<T> arr, Comparison<T> comparison)
        {
            IComparer<T> c;
            if (comparison == null)
                c = Comparer<T>.Default;
            else
                c = Comparer<T>.Create(comparison);
            BubbleSortImpl(arr, c);
        }

        private static void BubbleSortImpl<T>(IList<T> arr, IComparer<T> comparer)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            for (int i = 0; i < arr.Count() - 1; i++)
                for (int j = 0; j < arr.Count() - i - 1; j++)
                    if (comparer.Compare(arr[j], arr[j + 1]) > 0)
                        Swap(arr, j);
        }

        private static void Swap<T>(IList<T> arr, int index)
        {
            T temp = arr[index];
            arr[index] = arr[index + 1];
            arr[index + 1] = temp;
        }
    }
}

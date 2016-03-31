using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task5
{
    public static class Sort
    {
        public static void BubbleSort<T>(IList<T> arr, IComparer<T> comparer = null)
        {
            if (arr == null)
                throw new ArgumentNullException($"{nameof(arr)}");
            IComparer<T> c = comparer ?? Comparer<T>.Default;
            BubbleSortImpl(arr, c);
        }

        private static void BubbleSortImpl<T>(IList<T> arr, IComparer<T> comparer)
        {
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

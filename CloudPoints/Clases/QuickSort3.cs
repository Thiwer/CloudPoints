using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPoints.Clases
{
    public static class QuickSort3
    {
        public static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            const int threshold = 2048;
            if (hi <= lo) return;

            int lt = lo;
            int gt = hi;

            T pivot = arr[lo];
            int i = lo + 1;
            while (i <= gt)
            {
                int cmp = arr[i].CompareTo(pivot);
                if (cmp < 0) Swap(arr, lt++, i++);
                if (cmp > 0) Swap(arr, i, gt--);
                else i++;
            }

            if (hi - lo < threshold)
            {
                Sort(arr, lo, lt - 1);
                Sort(arr, gt + 1, hi);
            }
            else
            {
                Parallel.Invoke(
                    () => Sort(arr, lo, lt - 1),
                    () => Sort(arr, gt + 1, hi)
                    );
            }
        }

        public static void Sort<T>(T[] arr, int lo, int hi, Func<T, T, int> comparator)
        {
            const int threshold = 2048;
            if (hi <= lo) return;

            int lt = lo;
            int gt = hi;

            T pivot = arr[lo];
            int i = lo + 1;
            while (i <= gt)
            {
                int cmp = comparator(arr[i], pivot);
                if (cmp < 0) Swap(arr, lt++, i++);
                if (cmp > 0) Swap(arr, i, gt--);
                else i++;
            }

            if (hi - lo < threshold)
            {
                Sort(arr, lo, lt - 1, comparator);
                Sort(arr, gt + 1, hi, comparator);
            }
            else
            {
                Parallel.Invoke(
                    () => Sort(arr, lo, lt - 1, comparator),
                    () => Sort(arr, gt + 1, hi, comparator)
                    );
            }
        }

        private static void Swap<T>(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

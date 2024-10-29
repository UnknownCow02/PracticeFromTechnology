namespace WebApiPractice.Sorting
{
    public class QuickSort
    {
        public static char[] QuickSortMethod(char[] text, int minIndex, int maxIndex)
        {
            if (minIndex > maxIndex) return text;
            var pivotIndex = GetPivotIndex(text, minIndex, maxIndex);

            QuickSortMethod(text, minIndex, pivotIndex - 1);
            QuickSortMethod(text, pivotIndex + 1, maxIndex);

            return text;
        }
        private static int GetPivotIndex(char[] text, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (text[i] < text[maxIndex])
                {
                    pivot++;
                    Swap(ref text[pivot], ref text[i]);
                }
            }
            pivot++;
            Swap(ref text[pivot], ref text[maxIndex]);

            return pivot;
        }
        private static void Swap(ref char left, ref char right)
        {
            var temp = left;
            left = right;
            right = temp;
        }
    }
}
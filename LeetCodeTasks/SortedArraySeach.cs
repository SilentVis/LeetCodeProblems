namespace LeetCodeTasks
{
    public class SortedArraySeach
    {
        private static int OutOfBoundaryValue => (int)(Math.Pow(2, 31) - 1);
        private const int NotFound = -1;

        public int Search(ArrayReader reader, int target)
        {
            var leftBound = 0;
            var rightBound = target - reader.Get(leftBound);

            if (reader.Get(leftBound) > target)
            {
                return NotFound;
            }

            while (rightBound - leftBound > 1)
            {
                var index = leftBound + ((rightBound - leftBound) / 2);

                var value = reader.Get(index);

                if (value == target)
                {
                    return index;
                }

                if (value > target)
                {
                    rightBound = index;
                }
                else
                {
                    leftBound = index;
                }

            }

            if(reader.Get(leftBound) == target) return leftBound;
            if (reader.Get(rightBound) == target) return rightBound;
            
            return NotFound;
        }

        public class ArrayReader
        {
            private readonly int[] _array;

            public ArrayReader(int[] array)
            {
                _array = array;
            }


            public int Get(int index) => index > _array.Length - 1 ? OutOfBoundaryValue : _array[index];
        }
    }
}

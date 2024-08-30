using System;
using System.Linq;

namespace MissingNumber
{
    public class NaturalNumberSet
    {
        private readonly int[] _numbers;

        public NaturalNumberSet()
        {
            _numbers = Enumerable.Range(1, 100).ToArray();
        }

        public void Extract(int number)
        {
            if (number < 1 || number > 100)
                throw new ArgumentException("El número debe estar entre 1 y 100");

            _numbers[number - 1] = 0;
        }

        public int CalculateMissingNumber()
        {
            int expectedSum = (100 * 101) / 2;  // Sumatoria de 1 a 100
            int actualSum = _numbers.Sum();
            return expectedSum - actualSum;
        }
    }
}

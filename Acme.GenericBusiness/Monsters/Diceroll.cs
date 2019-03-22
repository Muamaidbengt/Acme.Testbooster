using System;

namespace Monsters
{
    public static class Diceroll
    {
        private static Random _rnd = new Random();

        private static int RollD4()
        {
            return _rnd.Next(1, 5);
        }

        private static int RollD6()
        {
            return _rnd.Next(1, 7);
        } 

        private static int RollD8()
        {
            return _rnd.Next(1, 9);
        }

        public static int D4(int times)
        {
            return Repeat(RollD4, times);
        }

        public static int D6(int times)
        {
            return Repeat(RollD6, times);
        }

        public static int D8(int times)
        {
            return Repeat(RollD8, times);
        }

        private static int Repeat(Func<int> rollFunc, int times)
        {
            if (times < 0)
                throw new ArgumentException("The number of times to roll must be non-negative", nameof(times));

            var sum = 0;
            while (times > 0)
            {
                sum += rollFunc();
                times--;
            }

            return sum;
        }
    }
}
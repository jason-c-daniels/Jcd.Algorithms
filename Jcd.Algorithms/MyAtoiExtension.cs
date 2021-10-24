namespace Jcd.Algorithms
{
    public static class MyAtoiExtension
    {
        /// <summary>
        /// https://leetcode.com/problems/string-to-integer-atoi/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int MyAtoi(this string s)
        {
            var inDigits = false;
            var inWs = true;
            long result = 0;
            var isNeg = false;
            foreach (var c in s)
            {
                if (ProcessWs(c, ref inWs, ref inDigits, ref isNeg)) continue;

                if (ProcessPlusMinus(c, ref inDigits, ref isNeg)) continue;

                if (inDigits && IsDigit(c))
                {
                    result *= 10;
                    result += Ctoi(c);
                    if (isNeg && -1 * result <= int.MinValue) return int.MinValue;
                    if (!isNeg && result >= int.MaxValue) return int.MaxValue;
                    continue;
                }

                if (!IsDigit(c))
                    break;
            }
            if (isNeg && -1 * result <= int.MinValue) return int.MinValue;
            if (!isNeg && result >= int.MaxValue) return int.MaxValue;
            return (int) (isNeg ? -1*result : result);
        }

        private static bool ProcessPlusMinus(char c, ref bool inDigits, ref bool isNeg)
        {
            if (!inDigits && (c == '+' || c == '-'))
            {
                inDigits = true;
                isNeg = c == '-';
                return true;
            }

            if (!inDigits && IsDigit(c))
            {
                inDigits = true;
            }

            return false;
        }

        private static bool ProcessWs(char c, ref bool inWs, ref bool inDigits, ref bool isNeg)
        {
            if (inWs && c == ' ') return true;
            if (inWs) inWs = false;

            return false;
        }

        private static bool IsDigit(char c) => Ctoi(c) >= 0;

        private static long Ctoi(char c)
        {
            return c switch
            {
                '0' => 0,
                '1' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                _ => -1
            };
        }
    }
}
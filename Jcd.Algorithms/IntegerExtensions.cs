namespace Jcd.Algorithms
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Reverse the bits of an integer.
        /// </summary>
        /// <param name="n">the number to reverse the bits of</param>
        /// <returns>the new number</returns>
        public static uint ReverseBits(this uint n)
        {
            uint result = 0;
            var setMask = ((uint)1<<31);
            var i = 0;
            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                    result ^= (setMask >> i);
                i++;
            }

            return result;
        }

        /// <summary>
        /// Given a signed 32-bit integer x, return x with its digits reversed. If reversing x
        /// causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1],
        /// then return 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(this int x) {
            try
            {
                bool isNeg = x < 0;
                var ux = (uint)(x >= 0 ? x : x * -1);
                uint ur = 0;

                var pr = ur;
                while (ux > 0)
                {
                    ur = checked(ur*10); 
                    ur = checked(ur + ux % 10);
                    ux /= 10;
                    if (ur > (uint)int.MaxValue + 1) return 0;
                    if (!isNeg && ur == (uint)int.MaxValue + 1) return 0;
                }

                if (isNeg && ur == (uint)int.MaxValue + 1) return int.MinValue;

                return ((int)ur) * (isNeg ? -1 : 1);
            }
            catch
            {
                return 0;
            }
        }
        
        
    }
}
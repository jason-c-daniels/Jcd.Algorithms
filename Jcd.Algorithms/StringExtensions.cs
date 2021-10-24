using System;
using System.Collections.Generic;
using System.Linq;

namespace Jcd.Algorithms
{
    public static class StringExtensions
    {
        /// <summary>
        /// Given a string s return all the N-letter-long sequences (substrings)
        /// that occur more than once in the sequence.
        /// </summary>
        /// <param name="s">The sequence to examine</param>
        /// <param name="seqSize">The size of the repeated subsequence to seek</param>
        /// <returns>a list of repeated sequences</returns>
        public static IList<string> FindRepeatedSubSequences(this string s, int seqSize)
        {
            var hs = new HashSet<string>(10000);
            var hsRepeated = new HashSet<string>();
            for (var i = 0; i <= s.Length - seqSize ; i++)
            {
                var ss = s[i..(i + seqSize)];
                if (hs.Contains(ss) && !hsRepeated.Contains(ss)) hsRepeated.Add(ss);
                else if (!hs.Contains(ss)) hs.Add(ss);
            }

            return hsRepeated.ToList();
        }
    }
}
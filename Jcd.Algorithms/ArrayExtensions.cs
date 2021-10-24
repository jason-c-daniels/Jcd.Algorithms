using System;
using System.Collections.Generic;
using System.Linq;

namespace Jcd.Algorithms
{
    public static class ArrayExtensions
    {
        
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            nums1 ??= Array.Empty<int>();
            nums2 ??= Array.Empty<int>();
            var len = nums1.Length + nums2.Length;
            if (len == 0) throw new ArgumentException("One of the two arrays must have at least one value.");
            // handle only one populated list.
            if (nums1.Length == 0) return nums2.Median();
            if (nums2.Length == 0) return nums1.Median();
            // we have two lists with Count > 0 elements.
            var takeTwo = len % 2 == 0;
            var mp = len / 2;
            // if there is no overlap, or the largest of one list is the same as the smallest in the other
            // consider the arrays disjoint and calculate the median as if we had a single sorted array/
            bool disjoint = nums1[0] >= nums2[^1] || nums2[0] >= nums1[^1];
            if (disjoint)
            {
                return DisjointMedian(nums1, nums2, mp, takeTwo);
            }

            // do the O((n+m)/2) approach because I'm lazy and don't want 
            // to figure out how to search for the median in log(n+m) time.
            var ll = nums1.Length <= nums2.Length ? nums1 : nums2;
            var rl = nums1.Length <= nums2.Length ? nums2 : nums1;
            
            var med = ll[0];
            var lv = ll[0];
            int i = 0, j = 0, c = 0;
            
            while (c <= mp)
            {
                if (c > 0) lv = med; // capture last (potential median) value
                if (i < ll.Length && j < rl.Length)
                {
                    if (ll[i] <= rl[j]) { med = ll[i]; i++; }
                    else if (ll[i] > rl[j]) {  med = rl[j]; j++; }
                }
                else if (i < ll.Length)
                {
                    med = ll[i]; i++;
                }
                else
                {
                    med = rl[j]; j++;
                }

                c++;
            }
            return takeTwo ? (lv+med) / 2.0 : med;
        }

        private static double DisjointMedian(int[] nums1, int[] nums2, int mp, bool takeTwo)
        {
            var ll = nums1[0] >= nums2[^1] ? nums2 : nums1;
            var rl = nums2[0] >= nums1[^1] ? nums2 : nums1;
            
            // check if the median is strictly in the left list 
            if (mp <= ll.Length - 1)
            {
                if (takeTwo) return (ll[mp] + ll[mp - 1]) / 2.0;
                return ll[mp];
            }
            
            // Otherwise the median is in the rightmost list, or spanning the
            // border between the two lists; in other words: if (mp >= ll.Length)
            var rli = mp - ll.Length;
            if (!takeTwo) return rl[rli];
            if (rli == 0) return (rl[0] + ll[^1]) / 2.0;
            return (rl[rli] + rl[rli - 1]) / 2.0;
        }

        public static double Median(this int[] self)
        {
            var take = self.Length % 2 == 0 ? 2 : 1;
            var mp = self.Length  / 2;
            if (take == 1) return self[mp];
            return (self[mp-1] + self[mp]) / 2.0;
        } 
        
        /// <summary>
        /// Given an array, rotate the array to the right by k steps,
        /// where k is non-negative.
        /// </summary>
        /// <param name="nums">The array to rotate</param>
        /// <param name="k">the number of steps in the rotation</param>
        public static void Rotate(this int[] nums, int k)
        {
            var N = nums.Length;
            if (k == 0 || N == 1) return; // no rotation possible
            // negative k is left rotation, which in terms of right rotation is
            // k = N - |k| % N
            if (k < 0) k = N - (Math.Abs(k) % N);
            k = k % N;
            if (k == 0) return; // k was ultimately a multiple of N
            var s1 = nums[..^k];
            var s2 = nums[^k..];
            int i = 0;
            foreach (var v in s2.Concat(s1))
            {
                nums[i++] = v;
            }
        }
        
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jcd.Algorithms.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var b= "-123.456e789".IsNumber();
            b="0.8".IsNumber();
            b="1a".IsNumber();
            b="2e0".IsNumber();
            b="2e10".IsNumber();
            b=".".IsNumber();
            b=".1.".IsNumber();
            b=".e1".IsNumber();
            b="ee".IsNumber();
            b="10e".IsNumber();
            b="10e-".IsNumber();
            b="1ee".IsNumber();
            b="-0.1".IsNumber();
            b="3e+7".IsNumber();
            
            var numbers = new[] { "2", "0089", "-0.1", "+3.14", "4.", "-.9", "0.8", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789", "2e0", "2e10" };
            foreach (var number in numbers)
            {
                if (!number.IsNumber()) throw new Exception($"{number} is actually a number fix your code.");
            }
            
            var notNumbers = new[] {"abc", "1a", "1e", "10e", "e3", "99e2.5", "--6", "-+3", "95a54e53", ".", "..", "..2", "1ee", ".e1", ".ee" };
            foreach (var number in notNumbers)
            {
                if (number.IsNumber()) throw new Exception($"{number} is not actually a number fix your code.");
            }
            
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var nums2 = new[] { -1, -100,3,99 };
            nums2.Rotate(2);
            nums.Rotate(3);
            var rss = "AAAAAAAAAAA".FindRepeatedSubSequences(10);
            var rev = 1534236469.Reverse();
            rev = 900.Reverse();
            rev = 921.Reverse();
            rev = -921.Reverse();
            rev = int.MinValue.Reverse();
            rev = "-91283472332".MyAtoi();
            rev = "9223372036854775808".MyAtoi();

            var l1 = new ListNode(1, new ListNode(4, new ListNode(5)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var l3 = new ListNode(2, new ListNode(6));

            var lists = new[] { l1, l2, l3 };
            var lists2 = new ListNode[] { null, null };
            var nl = lists.SDLMerge();
            nl = lists2.SDLMerge();

            var l4 = new int[] { 1,2,3,4,5,6,7,8,9}.FromIntList();
            var nl2 = LeetCodeProblems.ReverseKGroup(l4, 2); 
            
            var l5 = new int[] { 1,2,3,4,5,6,7,8,9}.FromIntList();
            var nl3 = LeetCodeProblems.ReverseKGroup(l5, 3);
            var is1 = new int[] { 1,3,5,11,13 };
            var is2 = new int[] { 2,4,6,10 };
            var m = ArrayExtensions.FindMedianSortedArrays(is1, is2);

            var r= LeetCodeProblems.FirstMissingPositive(new[] { -1,4,2,1,9,10 });
            

        }
    }    
}

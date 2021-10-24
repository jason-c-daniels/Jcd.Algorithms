using System.Collections.Generic;

namespace Jcd.Algorithms.Examples
{
    class LeetCodeProblems
    {
        static public int FirstMissingPositive(int[] nums) 
        {
            // we'll only consider values from 1 to n-1
            // swap them into their (m-1)th position where m = nums[i]
            for(var i=0;i<nums.Length;i++)
            {
                var c = nums[i] - 1;
                if (c < nums.Length && nums[i] > 0)
                {
                    // swap 'em
                    if (nums[c] != nums[i])
                    {
                        (nums[c], nums[i]) = (nums[i], nums[c]);
                        i--;
                    }
                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1) return i + 1;
            }

            return nums.Length+1;
        }

        static public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;
            if (head.next == null) return head;
            if (head.next.next == null)
            {
                if (k > 2) return head;
                // swap 'em!
                var nh = head.next;
                nh.next = head;
                head.next = null;
                return nh;
            }
            
            var s = new List<ListNode>(k);
            ListNode h = null;
            ListNode ph = null, pt=null;
            var c = head;
            var p = c;
            while (c != null)
            {
                s.Add(c);
                if (k == s.Count)
                    (ph, pt) = ComputeReversals(s, k, c, ph, pt);
                c = c.next; 
                h ??= ph;
            }

            if (s.Count > 0) pt.next = s[0];
            else pt.next = null;
            return h;
        }

        private static (ListNode ph, ListNode pt) ComputeReversals(List<ListNode> s, int k, ListNode c,  ListNode ph, ListNode pt)
        {
            // reverse all pointers within the list.
            for (int i = s.Count - 1; i > 0; i--)
            {
                s[i].next = s[i - 1];
            }

            if (pt != null) pt.next = c;
            ph = s[^1];
            pt = s[0];                
            s.Clear();

            return (ph, pt);
        }
    }
}
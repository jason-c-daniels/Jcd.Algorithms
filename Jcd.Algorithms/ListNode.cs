using System.Collections.Generic;

namespace Jcd.Algorithms
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
   }

    public static class ListNodeExtensions2
    {
        public static ListNode[] ToArray(this ListNode self)
        {
            return self.ToList().ToArray();
        }

        public static List<ListNode> ToList(this ListNode self)
        {
            var result = new List<ListNode>();
            var c = self;
            while (c != null)
            {
                result.Add(c);
                c = c.next;
            }

            return result;
        }

        public static ListNode FromList(this IList<ListNode> self)
        {
            if (self == null || self.Count == 0) return null;
            var r = self[0];
            for (int j = self.Count - 2; j >= 0; j--)
            {
                self[j].next = self[j + 1];
            }
            return r;
        }
        
        public static ListNode FromIntList(this IList<int> self)
        {
            if (self == null || self.Count == 0) return null;
            var n = new ListNode(self[^1]);
            for (int j = self.Count - 2; j >= 0; j--)
            {
                n = new ListNode(self[j], n);
            }
            return n;
        }

    }
}
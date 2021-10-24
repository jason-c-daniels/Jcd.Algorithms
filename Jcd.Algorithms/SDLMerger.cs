using System.Collections.Generic;

namespace Jcd.Algorithms
{
    public static class SDLMerger
    {
        public static ListNode SDLMerge(this ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            return lists.Length == 1 ? lists[0] : BuildList(BuildDictionary(lists));
        }

        static SortedDictionary<int, List<ListNode>> BuildDictionary(ListNode[] lists)
        {
            var d = new SortedDictionary<int, List<ListNode>>();
            foreach (var list in lists)
            {
                var cn = list;
                while (cn != null)
                {
                    if (d.ContainsKey(cn.val))
                        d[cn.val].Add(cn);
                    else
                        d.Add(cn.val,new List<ListNode>(new[]{cn}));
                    var l = d[cn.val];
                    if (l.Count > 1)
                        l[^2].next = l[^1];
                    cn = cn.next;
                    l[^1].next = null;
                }
            }
            return d;
        }

        static ListNode BuildList(SortedDictionary<int, List<ListNode>> d)
        {
            ListNode head = null;
            ListNode pt = null; // previous tail
            foreach (var (_, list) in d)
            {
                head ??= list[0];
                if (pt != null) pt.next = list[0]; // link the lists
                pt = list[^1];
            }
            return head;
        }
    }
}
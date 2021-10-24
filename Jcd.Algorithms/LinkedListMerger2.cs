using System.Collections.Generic;

namespace Jcd.Algorithms
{
    public static class LinkedListMerger2
    {
        public static ListNode Merge3(this ListNode[] nodes)
        {
            if (nodes == null || nodes.Length == 0) return null;
            if (nodes.Length == 1) return nodes[0];
            var dict= BuildDictionary(nodes);

            return BuildListNodes(dict);
        }

        private static ListNode BuildListNodes(SortedDictionary<int, int> dict)
        {
            ListNode head = null;
            ListNode pn = null;

            foreach (var kvp in dict)
            {
                for (var i = 0; i < kvp.Value; i++)
                {
                    var n = new ListNode(kvp.Key);
                    head ??= n;
                    if (pn != null) pn.next = n;
                    pn = n;
                }
            }

            return head;
        }

        private static SortedDictionary<int, int> BuildDictionary(ListNode[] nodes)
        {
            var dict = new SortedDictionary<int, int>();
            foreach (var listNode in nodes)
            {
                var cn = listNode;
                while (cn != null)
                {
                    if (!dict.ContainsKey(cn.val))
                    {
                        dict.Add(cn.val, 1);
                    }
                    else
                    {
                        dict[cn.val]++;
                    }

                    cn = cn.next;
                }
            }

            return dict;
        }
    }
}
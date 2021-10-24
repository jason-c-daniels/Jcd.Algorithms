using System;
using System.Collections.Generic;
using System.Linq;

namespace Jcd.Algorithms
{
    public static class LinkedListDictionaryMerger
    {
        public static ListNode DictionaryMerge(this ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            return lists.Length == 1 ? lists[0] : BuildList(BuildDictionary(lists));
        }

        private static ListNode BuildList(Dictionary<int, int> d)
        {
            var keys = d.Keys.ToArray();
            if (keys.Length > 1) Array.Sort(keys);
            ListNode head = null;
            ListNode pn = null;
            foreach (var key in keys)
            {
                var v = d[key];
                for (var i = 0; i < v; i++)
                {
                    var n = new ListNode(key);
                    head ??= n;
                    if (pn != null) pn.next = n;
                    pn = n;
                }
            }

            return head;
        }

        static Dictionary<int, int> BuildDictionary(ListNode[] lists)
        {
            var d = new Dictionary<int, int>();
            foreach (var list in lists)
            {
                var cn = list;
                while (cn != null)
                {
                    if (d.ContainsKey(cn.val)) d[cn.val]++;
                    else d.Add(cn.val,1);
                    cn = cn.next;
                }
            }
            return d;
        }
    }
}
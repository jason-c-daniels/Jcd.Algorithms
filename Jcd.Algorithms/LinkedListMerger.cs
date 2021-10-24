using System;

namespace Jcd.Algorithms
{
    using System.Collections.Generic;

    public static class LinkedListMerger
    {
        public static ListNode Merge2(this ListNode[] nodes)
        {
            var allNodes = AllNodes_YourDriverCodeSucks_ItFails_Where_My_Local_System_Does_Not_Fix_Your_System(nodes);
            if (allNodes == null) return null;
            if (allNodes.Length == 0) return null;
            Array.Sort(allNodes, (x, y) => x.val.CompareTo(y.val));
            allNodes[^1].next = null;
            // reconnect 'em all
            ListNode priorNode = null;
            foreach (var node in allNodes)
            {
                if (priorNode != null) priorNode.next = node;
                node.next = null;
                priorNode = node;
            }
            return allNodes[0]; // first item is the head of the new list
        }

        // Driver Code Writer: Why do you hate LINQ and extension methods?  Your driver can't handle them. Fix it.
        static ListNode[] AllNodes_YourDriverCodeSucks_ItFails_Where_My_Local_System_Does_Not_Fix_Your_System(
            ListNode[] nodes)
        {
            var resultCache = new List<ListNode>();
            foreach (var node in nodes)
            {
                var cn = node;
                while (cn != null)
                {
                    resultCache.Add(cn);
                    cn = cn.next;
                }
            }

            return resultCache.ToArray();
        }
    }
}

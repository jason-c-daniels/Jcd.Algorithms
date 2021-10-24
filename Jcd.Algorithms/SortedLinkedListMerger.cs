using System;
using System.Collections.Generic;
using System.Linq;

namespace Jcd.Algorithms
{

    public static class ListNodeExtensions
    {

        public static ListNode Merge(this ListNode[] nodes)
        {
            if (nodes == null || nodes.Length == 0) return null; // nothing to merge
            var lists = nodes.Select(n => new MyLinkedList(n)).ToList();
            var newList = new MyLinkedList();

            MyLinkedList ml = FindMin(lists);
            while (ml?.current != null)
            {
                var v = ml.current.val;
                while (ml.current.val == v)
                {
                    newList.Append(ml.current.Clone());
                    ml.MoveNext();
                }

                if (ml.current == null) lists.Remove(ml);
                if (lists.Count > 0) ml = FindMin(lists);
            }

            return newList.head;
        }

        private static MyLinkedList FindMin(List<MyLinkedList> lists)
        {
            if (lists.Count == 1) return lists[0];
            var result = lists[0];
            foreach (var l in lists)
            {
                if (l.CompareTo(result) < 0) result = l;
            }

            return result;
        }

        public static ListNode Clone(this ListNode node, ListNode next = null)
        {
            return new ListNode(node.val, next);
        }

        private class MyLinkedList : IComparable<MyLinkedList>
        {
            public ListNode head;
            public ListNode current;
            public ListNode tail;

            public MyLinkedList()
            {
                head = null;
                current = null;
                tail = null;
            }

            public MyLinkedList(ListNode node) => Append(node);

            public void Append(ListNode node)
            {
                if (head == null)
                {
                    head = node;
                    current = node; // set our start at the head.
                    tail = node;
                    return;
                }

                // someone hosed us up. Find the real tail.
                if (tail == null)
                {
                    tail = head;
                    while (tail.next != null) tail = tail.next;
                }

                tail.next = node;
                tail = node;
                tail.next = null; // disconnect from prior list.
            }

            public ListNode MoveNext()
            {
                current = current?.next;
                return current;
            }

            /// <inheritdoc />
            public int CompareTo(MyLinkedList other)
            {
                if (current == null && other.current == null) return 0;
                if (current == null && other.current != null) return 1; // sort null current to end of list.
                if (current != null && other.current == null) return -1; // sort non-null current to front of list.
                return current.val.CompareTo(other.current.val); // otherwise sort based on current value.
            }
        }
   }
}
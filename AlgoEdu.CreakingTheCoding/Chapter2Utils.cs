using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AlgoEdu.CreakingTheCoding.Lib;

namespace AlgoEdu.CreakingTheCoding
{
    public static class Chapter2Utils
    {
        /// <summary>
        /// Удаление дубликатов из несортированного связанного списка
        /// </summary>
        /// <param name="list"></param>
        public static void DeleteDub1(ListNode<int> list)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();

            ListNode<int> head = list;
            ListNode<int> prev = list;

            while (head != null)
            {
                if (table.ContainsKey(head.Value))
                {
                    if (head.Next != null)
                    {
                        prev.Next = head.Next;
                    }
                    else
                    {
                        prev.Next = null;
                    }          
                }
                else
                {
                    table.Add(head.Value, 0);
                }

                prev = head;
                head = head.Next;
            }

        }

        public static void DeleteDub2(ListNode<int> list)
        {
            ListNode<int> head = list;
            ListNode<int> tail = list;
            ListNode<int> prev = list;

            while (head != null)
            {
                tail = head.Next;
                prev = head;

                while (tail != null)
                {
                    if (head.Value == tail.Value)
                    {
                        if (head.Next != null)
                        {
                            prev.Next = tail.Next;
                        }
                        else
                        {
                            prev.Next = null;
                        }
                    }

                    prev = tail;
                    tail = tail.Next;
                }
                head = head.Next;
            }
        }

        /// <summary>
        /// Поиск k элемента с конца в односвязанном списке
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        public static ListNode<int> Find(ListNode<int> list, int k)
        {
            if (k <= 0)
            {
                return null;
            }
            ListNode<int> ptr1 = list;
            ListNode<int> ptr2 = list;

            for (int i = 0; i < k - 1; i++)
            {
                if (ptr2.Next == null)
                {
                    return null;
                }
                ptr2 = ptr2.Next;
            }
            if (ptr2.Next == null)
            {
                return null;
            }

            while (ptr2.Next != null)
            {
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;
            }
            return ptr1;
        }

        /// <summary>
        /// Удаление первого элемента из списка
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool DeleteFirst(ListNode<int> node)
        {
            if (node == null || node.Next == null)
            {
                return false; 
            }

            var next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;

            return true;
        }

        /// <summary>
        /// Напишите код, разбивающий связанный список вокруг значения x так, чтобы
        /// все узлы, меньше x, оказались перед узлами, бильшими или равными x
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public static ListNode<int> Position(ListNode<int> list, int pivot)
        {
            ListNode<int> before = null;
            ListNode<int> after = null;

            while (list != null)
            {
                var next = list.Next;

                if (list.Value < pivot)
                {
                    list.Next = before;
                    before = list;
                }
                else 
                {
                    list.Next = after;
                    after = list;
                }

                list = next;
            }

            if (before == null)
            {
                return after;
            }

            ListNode<int> head = before;
            while (before.Next != null)
            {
                before = before.Next;
            }
            before.Next = after;

            return head;

        }
    }
}

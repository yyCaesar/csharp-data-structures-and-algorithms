using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// leetcode题目
    /// </summary>
    internal class LeetCode
    {

        private static LeetCode instance;

        public static LeetCode GetInstance()
        {
            if (instance == null)
            {
                instance = new LeetCode();
            }
            return instance;
        }


        public NodeList code136_DeleteNode_2(NodeList head, int val)
        {

            return null;

        }

        /// <summary>
        /// 删除链表的节点（单指针）
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public NodeList code136_DeleteNode_1(NodeList head, int val)
        {
            if (head.val == val)
            {
                return head.next;
            }

            //     -99
            // [-3, 5, -99];
            NodeList cur = head;
            while (cur.next != null && cur.next.val != val)
            {
                cur = cur.next;
            }


            if (cur.next != null)
            {
                cur.next = cur.next.next;
            }


            return head;
        }


        ArrayList code123_ArrayList = new System.Collections.ArrayList();

        /// <summary>
        /// 图书整理（数组倒序）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] code123_ReverseBookList_4(NodeList head)
        {
            //输入：head = [3, 6, 4, 1]
            //输出：[1,4,6,3]

            if (head == null)
            {
                return new int[0];
            }

            NodeList cur = head;
            int count = 0;
            while (cur != null)
            {
                count++;
                cur = cur.next;
            }

            int[] ints = new int[count];

            cur = head;
            while (cur != null)
            {
                ints[--count] = cur.val;
                cur = cur.next;
            }
            return ints;
        }

        /// <summary>
        /// 图书整理（双指针）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] code123_ReverseBookList_3(NodeList head)
        {
            //输入：head = [3, 6, 4, 1]
            //输出：[1,4,6,3]

            if (head == null)
            {
                return new int[0];
            }

            NodeList pre = null;
            NodeList cur = head;
            int count = 0;
            while (cur != null)
            {
                count++;
                NodeList temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }

            int[] ints = new int[count];

            for (int i = 0; i < count; i++)
            {
                ints[i] = pre.val;
                pre = pre.next;
            }
            return ints;
        }

        /// <summary>
        /// 图书整理（栈实现）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] code123_ReverseBookList_2(NodeList head)
        {
            Stack<int> stack = new Stack<int>();

            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }

            int[] ints = new int[stack.Count];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = stack.Pop();
            }

            return ints;
        }

        /// <summary>
        /// 图书整理（递归实现）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] code123_ReverseBookList_1(NodeList head)
        {
            code123_recursion(head);

            int[] ints = new int[code123_ArrayList.Count];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = (int)code123_ArrayList[i];
            }

            return ints;
        }

        private void code123_recursion(NodeList head)
        {
            if (head == null) { return; }

            //Console.WriteLine($"递:{head.val}");
            code123_recursion(head.next);
            //Console.WriteLine($"归:{head.val}");

            code123_ArrayList.Add(head.val);
        }

        /// <summary>
        /// 反转链表（递归实现）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public NodeList code24_ReverseList_1(NodeList head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            //Console.WriteLine(head.val);
            NodeList node = code24_ReverseList_1(head.next);
            head.next.next = head;
            head.next = null;
            //Console.WriteLine(head.val);
            return node;
        }

        /// <summary>
        /// 反转链表（三指针实现）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public NodeList code24_ReverseList_2(NodeList head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            NodeList pre = null;
            NodeList cur = head;

            while (cur != null)
            {
                NodeList temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            return pre;
        }
    }
}

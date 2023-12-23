using System;
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
            if(head == null || head.next == null)
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

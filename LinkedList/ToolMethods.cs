using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// 工具方法
    /// </summary>
    internal class ToolMethods
    {

        private static ToolMethods instance;

        private ToolMethods() { }

        public static ToolMethods getInstance()
        {
            if (instance == null)
            {
                return new ToolMethods();
            }
            return instance;
        }

        /// <summary>
        /// 数组转换为节点(哨兵链表)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public NodeList ArrayToNodeList2(int[] arr)
        {
            NodeList? sentinel = new NodeList(-1);
            NodeList? cur = sentinel;

            for (int i = 0; i < arr.Length; i++)
            {
                NodeList temp = new NodeList(arr[i]);
                cur.next = temp;
                cur = temp;
            }
            return sentinel.next;
        }

        /// <summary>
        /// 数组转换为节点(改变指针方向)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public NodeList ArrayToNodeList1(int[] arr)
        {
            NodeList? nodeList = null;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                nodeList = new NodeList(arr[i], nodeList);

            }
            return nodeList;

        }

        /// <summary>
        /// 打印链表节点值
        /// </summary>
        /// <param name="node"></param>
        public void Print(NodeList node)
        {
            while (node != null)
            {
                Console.Write($"{node.val} -> ");
                node = node.next;
            }
            Console.WriteLine("null");
        }


    }
}

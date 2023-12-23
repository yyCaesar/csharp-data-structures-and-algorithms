using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// 链表
    /// </summary>
    internal class NodeList
    {
        public int val;
        public NodeList next;

        public NodeList(int val = 0, NodeList next = null)
        {
            this.val = val;
            this.next = next;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class RedBlackTree
    {

        Node root;

        public bool isRed(Node node)
        {
            return node != null && node.color == Color.RED;
        }

        public bool isBlack(Node node)
        {
            return node == null || node.color == Color.BLACK;
        }

        /// <summary>
        /// 右旋
        /// </summary>
        public void rightRotate(Node node)
        {
            Node currentParent = node.parent;
            Node futureParent = node.left;
            Node futureGrandson = futureParent.right;

            if (futureGrandson != null)
            {
                futureGrandson.parent = node;
            }

            futureParent.right = node;
            futureParent.parent = currentParent;

            node.left = futureGrandson;
            node.parent = futureParent;

            if (currentParent == null)
            {
                root = futureParent;
            }
            else if (currentParent.left == node)
            {
                currentParent.left = futureParent;
            }
            else if (currentParent.right == node)
            {
                currentParent.right = futureParent;
            }
        }

        /// <summary>
        /// 左旋
        /// </summary>
        public void leftRotate(Node node)
        {
            Node currentParen = node.parent;
            Node futureParent = node.right;
            Node futureGrandson = futureParent.left;

            if(futureGrandson != null)
            {
                futureGrandson.parent = node;
            }

            futureParent.left = node;
            futureParent.parent = currentParen;

            node.right = futureGrandson;
            node.parent = futureParent;

            if (currentParen == null)
            {
                root = currentParen;
            }
            else if (currentParen.left == node)
            {
                currentParen.left = futureParent;
            }
            else
            {
                currentParen.right = futureParent;
            }


        }




        public class Node
        {
            public int key;
            public object value;
            public Node left;
            public Node right;
            public Node parent;
            public Color color = Color.RED;


            public Node(int key)
            {
                this.key = key;
            }

            public Node(int key, Color color)
            {
                this.key = key;
                this.color = color;
            }

            public Node(int key, object value)
            {
                this.key = key;
                this.value = value;
            }

            public Node(int key, object value, Node left, Node right, Color color)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
                this.color = color;

                if (left != null)
                {
                    left.parent = this;
                }

                if (right != null)
                {
                    right.parent = this;
                }
            }


            /// <summary>
            /// 是否是左孩子
            /// </summary>
            /// <returns></returns>
            public bool IsLeftChild()
            {
                return parent != null && parent.left == this;
            }


            /// <summary>
            /// 获取兄弟节点
            /// </summary>
            /// <returns></returns>
            public Node GetBrotherNode()
            {
                if (parent == null)
                {
                    return null;
                }

                if (this.IsLeftChild())
                {
                    return parent.right;
                }
                else
                {
                    return parent.left;
                }

            }


            /// <summary>
            /// 获取叔叔节点
            /// </summary>
            /// <returns></returns>
            public Node GetUncleNode()
            {
                /**
                        5        5              5
                                / \            / \
                               3   8          3   8 
                                             /
                                            2
                 */


                // 一层、两层树没有 uncle node
                if (parent == null || parent.parent == null)
                {
                    return null;
                }

                if (parent.IsLeftChild())
                {
                    return parent.parent.right;
                }
                else
                {
                    return parent.parent.left;
                }
            }

        }

        public enum Color
        {
            BLACK, RED
        }

    }
}

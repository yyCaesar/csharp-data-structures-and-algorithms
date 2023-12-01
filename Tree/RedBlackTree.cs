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

        public bool IsRed(Node node)
        {
            return node != null && node.color == Color.RED;
        }

        public bool IsBlack(Node node)
        {
            return node == null || node.color == Color.BLACK;
        }


        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(int key, object value)
        {
            Node temp = root;
            Node parent = null; //记录找节点退出时的最后一个节点

            //先找到合适的位置
            while (temp != null)
            {
                parent = temp;
                if (key < temp.key)
                {
                    temp = temp.left;
                }
                else if (key > temp.key)
                {
                    temp = temp.right;
                }
                else
                {
                    temp.value = value;
                    return;
                }
            }

            //没找到key，就新增，插入parent节点下
            Node inserted = new Node(key, value);

            if (parent == null)
            {
                root = inserted;
            }
            else if (key < parent.key)
            {
                parent.left = inserted;
                inserted.parent = parent;
            }
            else if (key > parent.key)
            {
                parent.right = inserted;
                inserted.parent = parent;
            }

        }


        /// <summary>
        /// 修复相邻的红色节点
        /// </summary>
        /// <param name="node"></param>
        public void RepairAdjacentRedNodes(Node node)
        {
            /***
             * 1.插入的节点为根节点
             * 2.插入节点父亲是黑色，无需调整
             * 3.红红相邻，叔叔为红
             * 4.红红相邻，叔叔为黑
             * 
             */

            if (node == root)
            {
                node.color = Color.BLACK;
                return;
            }

            if (IsBlack(node.parent))
            {
                return;
            }

            Node parent = node.parent;
            Node uncle = node.GetUncleNode();
            Node grandParent = parent.parent;

            if (IsRed(uncle))
            {
                parent.color = Color.BLACK;
                uncle.color = Color.BLACK;
                grandParent.color = Color.RED;

                RepairAdjacentRedNodes(grandParent);
                return;
            }

            //LL
            if (parent.IsLeftChild() && node.IsLeftChild())
            {
                parent.color = Color.BLACK;
                grandParent.color = Color.RED;
                this.RightRotate(grandParent);
            }
            //LR
            else if (parent.IsLeftChild() && !node.IsLeftChild())
            {
                LeftRotate(parent);
                node.color = Color.BLACK;
                grandParent.color = Color.RED;
                this.RightRotate(grandParent);
            }
            //RR
            else if (!parent.IsLeftChild() && !node.IsLeftChild())
            {
                parent.color = Color.BLACK;
                grandParent.color = Color.RED;
                this.LeftRotate(grandParent);
            }
            //RL
            else
            {
                RightRotate(parent);
                node.color = Color.BLACK;
                grandParent.color = Color.RED;
                this.LeftRotate(grandParent);
            }
        }



        /// <summary>
        /// 右旋
        /// </summary>
        public void RightRotate(Node node)
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
        public void LeftRotate(Node node)
        {
            Node currentParen = node.parent;
            Node futureParent = node.right;
            Node futureGrandson = futureParent.left;

            if (futureGrandson != null)
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

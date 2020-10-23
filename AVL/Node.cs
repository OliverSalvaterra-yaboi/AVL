using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System.Text;

namespace AVL
{
    public class Node<T> 
    {
        public T key;
        public Node<T> lc;
        public Node<T> rc;

        public Node(T key, Node<T> lc, Node<T> rc)
        {
            this.key = key;
            this.lc = lc;
            this.rc = rc;
        }

        public int GetHeight()
        {
            int leftHeight = lc == null ? 0: lc.GetHeight();
            int rightHeight = rc == null ? 0: rc.GetHeight();

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public int ChildCount()
        {
            int count = 0;

            if (lc != null)
                count++;

            if (rc != null)
                count++;

            return count;
        }

        public int Balance()
        {
            int rightHeight = rc == null ? 0 : rc.GetHeight();
            int leftHeight = lc == null ? 0 : lc.GetHeight();
            return rightHeight - leftHeight;
        }
    }


    public class AVL<T> where T: IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }


        public Node<T> add(Node<T> node, T key)
        {
            if(node == null)
            {
                return new Node<T>(key, null, null);
            }

            if (key.CompareTo(node.key) >= 0)
            {
                node.rc = add(node.rc, key);
            }
            else
            {
                node.lc = add(node.lc, key);
            }

            return balance(node);
        }
        public void insert(T key)
        {
            Count++;
            Root = add(Root, key);
        }

        public Node<T> rr(Node<T> node)
        {
            Node<T> piv = node.lc;
            node.lc = piv.rc;
            piv.rc = node;
            return piv;
        }

        public Node<T> rl(Node<T> node)
        {
            Node<T> piv = node.rc;
            node.rc = piv.lc;
            piv.lc = node;
            return piv;
        }

        public Node<T> balance(Node<T> node)
        {
            if(node.Balance() > 1)
            {
                if (node.rc.Balance() < 0)
                {
                    node.rc = rr(node);
                }

                node = rl(node);
            }

            if(node.Balance() < -1)
            {
                if (node.lc.Balance() > 0)
                {
                    node.lc = rl(node);
                }

                node = rr(node);
            }

            return node;
        }

        public void remove(T key)
        {
            Count--;
            Root = remove(Root, key);
        }

        public Node<T> remove(Node<T> node, T key)
        {
            if(node == null) return null;   

            if (key.CompareTo(node.key) > 0)
            {
                node.rc = remove(node.rc, key);
            }
            else if(key.CompareTo(node.key) < 0)
            {
                node.lc = remove(node.lc, key);
            }
            else
            {
                if(node.ChildCount() == 2)
                {
                    Node<T> temp = min(node.rc);
                    node.key = temp.key;
                    node.rc = remove(node.rc, temp.key);
                }
                else
                {
                    if(node.rc != null)
                    {
                        return node.rc;
                    }
                    else if(node.lc != null)
                    {
                        return node.lc;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return balance(node);
        }

        public Node<T> min(Node<T> node)
        {
            if (node.lc == null) return node;
            return min(node.lc);
        }
    }
}

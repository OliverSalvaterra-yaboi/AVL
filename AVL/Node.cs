using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace AVL
{
    class Node<T> 
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
            return rc.GetHeight() - lc.GetHeight();
        }
    }


    class AVL<T> where T: IComparable<T>
    {
        Node<T> root;
        int Count;


        public Node<T> add(Node<T> node, T key)
        {
            if (key.CompareTo(node.key) >= 0)
            {
                if(node.rc != null)
                {
                    add(node.rc, key);
                }
                else
                {
                    node.rc = new Node<T>(key, null, null);
                }
            }
            else
            {
                if(node.lc != null)
                {
                    add(node.lc, key);
                }
                else
                {
                    node.lc = new Node<T>(key, null, null);
                }
            }

            return balance(node);
        }
        public void insert(T key)
        {
            Count++;
            root = add(root, key);
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
                if(node.lc.Balance() < 0)
                {
                    node = rl(node);
                }

                node = rr(node);
            }

            if(node.Balance() < -1)
            {
                if(node.rc.Balance() > 0)
                {
                    node = rr(node);
                }

                node = rl(node);
            }

            return node;
        }

        public void remove(T key)
        {
            Count--;
            root = remove(root, key);
        }

        public Node<T> remove(Node<T> node, T key)
        {
            if (key.CompareTo(node.key) > 0)
            {
                if (node.rc != null)
                {
                    remove(node.rc, key);
                }
                else
                {
                    return null;
                }
            }
            else if(key.CompareTo(node.key) < 0)
            {
                if (node.lc != null)
                {
                    remove(node.lc, key);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if(node.ChildCount() == 2)
                {
                    Node<T> temp = min(node.rc);
                }
                else
                {

                }
            }
            return node;
        }

        public Node<T> min(Node<T> node)
        {
            if (node.lc == null) return node;
            return min(node.lc);
        }
    }
}

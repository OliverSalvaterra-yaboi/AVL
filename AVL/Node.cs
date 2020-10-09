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


        public void traversal(Node<T> node, T key)
        {
            Node<T> trav = node;
            if (key.CompareTo(trav.key) > 0)
            {

            }
            else
            {

            }
        }
        public void insert(T key)
        {
            if (root == null) { root = new Node<T>(key, null, null); Count++; return; }

            traversal(root, key);
        }
    }
}

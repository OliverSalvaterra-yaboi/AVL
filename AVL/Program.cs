using System;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AVL<int>();

            tree.insert(5);
            tree.insert(7);
        }
    }
}

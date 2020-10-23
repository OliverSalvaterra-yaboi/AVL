using System;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AVL<int>();

            for(int i = 1; i < 10; i++)
            {
                tree.insert(i);
            }
            for(int i = 1; i < 10; i++)
            {
                tree.remove(i);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Node<T>
    {
        public readonly T data;
        public int level;

        public Node(T data, int level)
        {
            this.data = data;
            this.level = level;
        }
    }
}

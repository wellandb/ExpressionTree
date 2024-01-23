using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Node
    {
        public Node lchild;
        public char info;
        public Node rchild;
        // Node stores info and is connected to a left and right child
        public Node(char c)
        {
            info = c;
            lchild = null;
            rchild = null;
        }
    }
}

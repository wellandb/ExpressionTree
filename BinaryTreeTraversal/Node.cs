using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversal
{
    class Node
    {
        public Node lchild;
        public int info;
        public Node rchild;
        // Node stores info and is connected to a left and right child
        public Node(int i)
        {
            info = i;
            lchild = null;
            rchild = null;
        }
    }
}

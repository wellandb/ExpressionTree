using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class StackNode
    {
        private Node[] stackArray;
        // Top marks the top of the stack as an index in the array
        private int top;
        // StackNode is a stack of nodes and implements the usual stack operations
        public StackNode()
        {
            stackArray = new Node[10];
            top = -1;
        }

        public StackNode(int maxSize)
        {
            stackArray = new Node[maxSize];
            top = -1;
        }

        // Gets size of the stack
        public int Size()
        {
            return top + 1;
        }
        // Checks if empty
        public bool IsEmpty()
        {
            return (top == -1);
        }
        // Checks if full
        public bool isFull()
        {
            return (top == stackArray.Length -1);
        }
        // push node to the top of the stack
        public void Push(Node node)
        {
            if(isFull())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            top++;
            stackArray[top] = node;
        }
        // pop top node off the stack
        public Node Pop()
        {
            Node x;
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                throw new System.InvalidOperationException();
            }
            x = stackArray[top];
            top --;
            return x;
        }
        // look at the top node
        public Node Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                throw new System.InvalidOperationException();
            }
            return stackArray[top];
        }
        // Prints the stack to console
        public void Display()
        {
            int i;
            Console.WriteLine("top = " + top);
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }
            Console.WriteLine("Stack is: ");
            for (i = top; i>=0; i--)
            {
                Console.WriteLine(stackArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

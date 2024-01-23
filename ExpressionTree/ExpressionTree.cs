using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    internal class ExpressionTree
    {
        Node? root;
        // Constructor sets the root to null
        public ExpressionTree()
        {
            root =null;
        }
        // Checks if character is an operation
        static bool isOperator(char c)
        {
            if(c =='+'|| c =='-'|| c =='*'|| c =='/'|| c =='^')
                return true;
            return false;
        }
        // Builds the tree
        public void BuildTree(String postfix)
        {
            StackNode stack = new StackNode(30);
            Node t;
            // Loops through the postfix expression
            for(int i = 0; i < postfix.Length; i++)
            {
                // If character is an operation then create a new node and pop the two top stack levels as children
                if (isOperator(postfix[i]))
                {
                    t = new Node(postfix[i]);
                    t.rchild = stack.Pop();
                    t.lchild = stack.Pop();
                    // Push the node onto the stack
                    stack.Push(t);
                }
                else
                /*operand*/
                // Create a node of the operand and push onto stack
                {
                    t =new Node(postfix[i]);
                    stack.Push(t);
                }
            }
            // Root is the final Node on stack
            root = stack.Pop();
        }

        // Prefix is a preorder search of the expression tree
        public void Prefix()
        {
            Preorder(root);
            Console.WriteLine();
        }
        // Preorder search is root, left, right search recursively on the expression tree
        private void Preorder(Node p)
        {
            if(p ==null)
                return;
            Console.Write(p.info);
            Preorder(p.lchild);
            Preorder(p.rchild);
        }
        // Postfix is a postorder search on the expression tree
        public void Postfix()
        {
            Postorder(root);
            Console.WriteLine();
        }
        // postorder search is left, right, root search recursively on the expression tree
        private void Postorder(Node p)
        {
            if (p ==null)
            {
                return;
            }
            Postorder(p.lchild);
            Postorder(p.rchild);
            Console.Write(p.info);
        }
        // Parenthesized infix is an infix search on expression tree with brackets written around each operation
        public void ParenthesizedInfix()
        {
            Inorder(root);
            Console.WriteLine();
        }
        // Inorder search is left, root, right search with brackets around the whole operation (left root right)
        private void Inorder(Node p)
        {
            if(p ==null)
                return;
            if(isOperator(p.info))
                Console.Write("(");

            Inorder(p.lchild);
            Console.Write(p.info);
            Inorder(p.rchild);

            if(isOperator(p.info))
                Console.Write(")");
        }
        // Display calls the Display(node, level) method on node = root & level = 0
        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }
        // Display is a recursive call to print the expression tree starting right to left and incrementing the levels with spaces
        private void Display(Node p,int level)
        {
            int i;
            if(p ==null)
                return;
            Display(p.rchild, level + 1);
            Console.WriteLine();
            for(i = 0; i < level; i++)
                Console.Write("     ");
            Console.Write(p.info);
            Display(p.lchild, level + 1);
        }
        // Evaluate calls Evaluate on the root if it exists else it returns 0
        public int Evaluate()
        {
            if(root ==null)
                return 0;
            else
                return Evaluate(root);
        }
        // Evaluate is a recursive call on the Node which performs the operations on the operands of the left and right child if info is an operator else it returns the info as an operand
        private int Evaluate(Node p)
        {
            if(!isOperator(p.info))
            {return Convert.ToInt32(Char.GetNumericValue(p.info)); }

            int leftValue = Evaluate(p.lchild);
            int rightValue = Evaluate(p.rchild);

            if(p.info =='+'){return leftValue + rightValue; }
            else if(p.info =='-'){return leftValue -rightValue; }
            else if(p.info =='*'){return leftValue * rightValue; }
            // Add operation for '^'
            else if(p.info == '^') { return (int)Math.Pow(leftValue, rightValue); }
            else{return leftValue / rightValue; }
        }
    }
}

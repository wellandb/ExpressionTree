using System;
using System.Text.RegularExpressions;

namespace ExpressionTree
{
    internal class Program
    {
        public class Implementation
        {
            // Priority of operations
            public int precedence(char op) 
            {
                if(op =='*'|| op =='/'|| op =='%')
                    return 3;
                else if(op =='+'|| op =='-')
                    return 2;
                else if(op =='^')
                    return 1;
                else
                    return -1;
            }

            // Converts infix to postfix
            public string Infix_To_Postfix(ref string expn)
            {
                Stack<char> stk =new Stack<char>();
                string output ="";
                char _out;
                foreach(var ch in expn)
                {
                    // Checks if char is a letter/number
                    bool isAlphaBet = Regex.IsMatch(ch.ToString(),"[a-z]",RegexOptions.IgnoreCase);
                    if(Char.IsDigit(ch) || isAlphaBet)
                    {
                        output = output + ch;
                    }
                    // Else it is an operation
                    else
                    {
                        switch(ch)
                        {
                            case'+':
                            case'-':
                            case'*':
                            case'/':
                            case'%':
                            case'^':
                                // while stack is not empty and the priority of current operation is less than or equal to the top operation on the stack
                                while(stk.Count > 0 && precedence(ch) <= precedence(stk.Peek()))
                                {
                                    // Put the operation on top of the stack in the output
                                    _out = stk.Peek();
                                    stk.Pop();
                                    output = output + "" + _out;
                                }
                                // Push operation onto stack
                                stk.Push(ch);
                                output = output + "";
                                break;
                            // If the operation is a bracket push
                            case'(':
                                stk.Push(ch);
                                break;
                            // if operation is closed bracket then pop all operations onto the output unless it is an open bracket
                            case')':
                                while(stk.Count > 0 && (_out = stk.Peek()) !='(')
                                {
                                    stk.Pop();
                                    output = output +""+ _out +"";
                                }
                                if(stk.Count > 0 && (_out = stk.Peek()) =='(')
                                    stk.Pop();
                                break;
                        }
                    }
                }
                // Empty stack onto the output
                while(stk.Count > 0)
                {
                    _out = stk.Peek();
                    stk.Pop();
                    output = output + _out;
                }
                return output;
            }
        }



        static void Main(string[] args)
        {
            ExpressionTree etree = new ExpressionTree();
            string input;
            Console.WriteLine("-----------------");
            Implementation imp = new Implementation();
            input ="1+2*3+2+3";
            string postfix = imp.Infix_To_Postfix(ref input);
            Console.WriteLine("infix: "+ input);
            Console.WriteLine("Postfix: "+ postfix);
            Console.WriteLine("-----------------");
            etree.BuildTree(postfix);
            etree.BuildTree(postfix);
            etree.Display();
            Console.Write("Prefix : ");
            etree.Prefix();
            Console.Write("Postfix : ");
            etree.Postfix();
            Console.Write("Infix : ");
            etree.ParenthesizedInfix();
            Console.WriteLine("Value : "+ etree.Evaluate() );
            Console.ReadLine();
        }
    }
}

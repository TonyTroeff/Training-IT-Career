using System;
using System.Collections.Generic;

namespace ExtractSubExpressions
{
    internal class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();

            var (isBalanced, subExpressions) = IsBalanced(expression);
            if (isBalanced)
            {
                Console.WriteLine("This is balanced expression!");
                foreach (string subExpression in subExpressions)
                    Console.WriteLine($"--> {subExpression}");
            }
            else Console.Write("This is NOT a balanced expression!");
        }

        static (bool IsBalanced, string[] SubExpressions) IsBalanced(string expression)
        {
            Stack<int> symbolsStack = new Stack<int>();
            List<string> subExpressions = new List<string>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{') symbolsStack.Push(i);
                else if (expression[i] == ')' || expression[i] == ']' || expression[i] == '}')
                {
                    // We MUST check:
                    // 1. If the stack empty, the expression is not balanced!
                    // 2. If the top element from the stack does not correspond, the expression is not balanced!
                    // 3. If the top element from the stack does correspond, the expression may be balanced!
                    if (symbolsStack.Count == 0) return (IsBalanced: false, SubExpressions: Array.Empty<string>());

                    char openingSymbol = expression[symbolsStack.Peek()];
                    if ((expression[i] == ')' && openingSymbol != '(')
                        || (expression[i] == ']' && openingSymbol != '[')
                        || (expression[i] == '}' && openingSymbol != '{'))
                        return (IsBalanced: false, SubExpressions: Array.Empty<string>());

                    int startIndex = symbolsStack.Pop();
                    subExpressions.Add(expression.Substring(startIndex, i - startIndex + 1));
                }
            }

            // This is NOT correct.
            // return true;
            if (symbolsStack.Count != 0) return (IsBalanced: false, SubExpressions: Array.Empty<string>());

            return (IsBalanced: true, SubExpressions: subExpressions.ToArray());
        }
    }
}
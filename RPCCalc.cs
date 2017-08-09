using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        int res = SolveRpc(Console.ReadLine().Split(' '));
        string sres = int.MinValue == res ? "INVALID" : res.ToString();
        Console.WriteLine(sres);
    }

    public static int SolveRpc(string[] ops)
    {
        int result = 0;
        var stack = new Stack<int>();
        try
        {
            foreach (var op in ops)
            {
                int iop = 0;
                if (int.TryParse(op, out iop))
                {
                    stack.Push(iop);
                }
                else
                {
                    int x1, x2, x3;
                    char cop = op[0];
                    switch (cop)
                    {
                        case '+':
                            x2 = stack.Pop();
                            x1 = stack.Pop();
                            stack.Push(x1 + x2);
                            break;
                        case '-':
                            x2 = stack.Pop();
                            x1 = stack.Pop();
                            stack.Push(x1 - x2);
                            break;
                        case '*':
                            x2 = stack.Pop();
                            x1 = stack.Pop();
                            stack.Push(x1 * x2);
                            break;
                        case '/':
                            x2 = stack.Pop();
                            x1 = stack.Pop();
                            stack.Push(x1 / x2);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }
            result = stack.Pop();
        }
        // If the stack is empty, we'll get this.
        catch (InvalidOperationException)
        {
            result = int.MinValue;
        }
        if (stack.Count > 0)
        {
            result = int.MinValue;
        }
        return result;
    }
}

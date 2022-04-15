using System;
using System.Linq;

class Program
{
    static Orders.GroupOrders orders = new Orders.GroupOrders(new Orders.IOrder[]{
        new Orders.OrderVariants(new Orders.IOrder[]{
            new Orders.StringOrder("+"),
            new Orders.StringOrder("-")
        }, false),
        new Orders.OrderVariants(new Orders.IOrder[]{
            new Orders.FunctionOrder(Checkers.NumberChecker.Search),
            new Orders.FunctionOrder(Checkers.IndentChecker.Search)
        }),
        new Orders.LoopedOrder(
            new Orders.GroupOrders(new Orders.IOrder[] {
                new Orders.OrderVariants(new Orders.IOrder[] {
                    new Orders.StringOrder("+"),
                    new Orders.StringOrder("-"),
                    new Orders.StringOrder("*"),
                    new Orders.StringOrder("/")
                }, false),
                new Orders.OrderVariants(new Orders.IOrder[] {
                    new Orders.FunctionOrder(Checkers.NumberChecker.Search),
                    new Orders.FunctionOrder(Checkers.IndentChecker.Search)
                })
            })
        , false)
    });

    static void ProcessingExpression(string expression)
    {
        int output;
        
        output = orders.Processing(expression);

        if (output == -1)
        {
            Console.WriteLine("Error in structure");
            Console.WriteLine(expression);
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", orders.getPosition())) + "^");
        }
        else if (output != expression.Length)
        {
            Console.WriteLine("Error in structure");
            Console.WriteLine(expression);
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", output)) + "^");
        }
        else
        {
            Console.WriteLine("Structure is correct");
        }
    }

    static void Main(string[] args)
    {

        for (int index = 0; index < args.Length; index++)
        {
            Console.Write("---");
            Console.Write(index + 1);
            Console.WriteLine("---");
            
            ProcessingExpression(args[index]);

            Console.Write("---");
            Console.WriteLine("---");
        }
    }
}

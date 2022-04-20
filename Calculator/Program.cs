using System;
using Calculator;

namespace Calculator
{
    internal class Program
    {
        private static string ReadOpeartion()
        {
            Console.Write("Enter value or operation or \"help\" to show a list of commands: ");
            string operation = Console.ReadLine();
            if (operation == "help")
            {
                Console.WriteLine("Value: ");
                Console.WriteLine("     new value: \"new\"");
                Console.WriteLine("     clear value: \"clear\"");
                Console.WriteLine("Operation: ");
                Console.WriteLine("     change sing: \"+/-\"");
                Console.WriteLine("     percent: \"%\"");
                Console.WriteLine("     add: \"+\"");
                Console.WriteLine("     subtract: \"-\"");
                Console.WriteLine("     multiply: \"*\"");
                Console.WriteLine("     divide: \"/\"");
                Console.WriteLine("Enter: \"end\" to exit the calculator");
                Console.Write("Enter value or operation: ");
                operation = Console.ReadLine();
            }
            Console.WriteLine();

            return operation;
        }

        private static float ReadNumber(string message)
        {
            float number;

            Console.Write(message);
            if (!float.TryParse(Console.ReadLine(), out number))
                throw new InvalidCastException("The resulting number is not a number"); 
            Console.WriteLine();

            return number;
        }

        private static ICalculator.Response ApplyOperation(ref Calculator calculator, string operation)
        {
            float number;
            switch (operation)
            {
                case "%":
                    number = ReadNumber("Enter the precent: ");
                    return calculator.TakePercentageOfNumber(number);
                case "+/-":
                    return calculator.ChangeSing();
                case "*":
                    number = ReadNumber("Enter the number you want to multiply by: ");
                    return calculator.MultiplyByNumber(number);
                case "+":
                    number = ReadNumber("Enter the number you want to add: ");
                    return calculator.AddNumber(number);
                case "-":
                    number = ReadNumber("Enter the number you want to subtract: ");
                    return calculator.SubstractNumber(number);
                case "/":
                    number = ReadNumber("Enter the number you want to divide by: ");
                    return calculator.DivideByNumber(number);
                case "new":
                    number = ReadNumber("Enter a new value: ");
                    return calculator.SetNewValue(number);
                case "clear":
                    return calculator.SetNewValue(0);
                default:
                    Console.WriteLine("> Invalid opeartor \n");
                    return ICalculator.Response.Successfully;
            }
        }

        static int Main(string[] args)
        {
            try
            {
                Calculator calculator = new Calculator();
                string operation;

                do
                {
                    Console.WriteLine("Result: " + calculator.GetState());
                    Console.WriteLine();

                    operation = ReadOpeartion();
                    if (operation == "end")
                        break;
                    ICalculator.Response response = ApplyOperation(ref calculator, operation);

                    if (response == ICalculator.Response.DivideByZero)
                        Console.WriteLine("> The operation has not been performed. It is impossible to divide by zero \n");
                    if (response == ICalculator.Response.Overflow)
                        Console.WriteLine("> The operation has not been performed. Overflow \n");
                }
                while (operation != "end");

                Console.WriteLine("The final result of calculations: " + calculator.GetState());
                return 0;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return 1;
            }
        }
    }
}

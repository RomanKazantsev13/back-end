using System;

namespace Calculator
{
    internal class Program
    {
        private static string GetOperation()
        {
            Console.WriteLine("Enter value or operation or \"help\" to show a list of commands: ");
            string operation = Console.ReadLine();
            if (operation == "help")
            {
                Console.WriteLine("Enter value or operation: ");
                Console.WriteLine("Value: ");
                Console.WriteLine("     new value: \"new\"");
                Console.WriteLine("     clear value: \"clear\"");
                Console.WriteLine("Operation: ");
                Console.WriteLine("     change sing: \"+/-\"");
                Console.WriteLine("     percent: \"%\"");
                Console.WriteLine("     add: \"+\"");
                Console.WriteLine("     subtract: \"-\"");
                Console.WriteLine("     multiply: \"*\"");
                Console.WriteLine("     divide: \"/\" or \"\\\"");
                Console.WriteLine("Enter: \"end\" to exit the calculator");
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
            {
                throw new InvalidCastException("The resulting number is not a number");
            }
            Console.WriteLine();

            return number;
        }
        private static float GetArgument(string operation, float result)
        {
            float argument;

            if (operation == "+/-")
            {
                return -1;
            }
            if (operation == "%")
            {
                argument = ReadNumber("Enter the precent: ");

                return argument;
            }

            if (operation == "+" || operation == "-" || operation == "*" || operation == "/" || operation == "\\")
            {
                argument = ReadNumber("Enter the second operand: ");

                return argument;
            }

            return 0;
        }

        private static float ApplyopeartionToOperands(string operation, float result, float argument)
        {
            switch (operation)
            {
                case "%":
                    if (argument < 0)
                    {
                        throw new ArgumentOutOfRangeException("Negative percentage is not acceptable");
                    }
                    result = (float)(result * argument * 0.01);
                    break;
                case "+/-":
                case "*":
                    result = result * argument;
                    break;
                case "+":
                    result = result + argument;
                    break;
                case "-":
                    result = result - argument;
                    break;
                case "/":
                case "\\":
                    if (argument == 0)
                    {
                        throw new DivideByZeroException("Division by 0 is not allowed");
                    }
                    result = result / argument;
                    break;
                default:
                    Console.WriteLine("Invalid opeartor");
                    break;
            }

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The result causes an overflow");
            }

            return result;
        }

        private static float GetNewValue(string operation)
        {
            float result = 0;

            switch (operation)
            {
                case "new":
                    result = ReadNumber("Enter new value: ");
                    break;
                case "clear":
                    return result;
            }

            return result;
        }

        public static float Calculate()
        {
            string operation;
            float result = 0;
            float argument;

            do
            {
                Console.WriteLine("Result: " + result);
                Console.WriteLine();

                operation = GetOperation();
                if (operation == "end")
                {
                    break;
                }
                if (operation == "new" || operation == "clear")
                {
                    result = GetNewValue(operation);
                }
                else
                {
                    argument = GetArgument(operation, result);
                    result = ApplyopeartionToOperands(operation, result, argument);
                }
            }
            while (operation != "end");

            return result;
        }

        static int Main(string[] args)
        {
            try
            {
                float result = Calculate();
                Console.WriteLine("The final result of calculations: " + result);

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

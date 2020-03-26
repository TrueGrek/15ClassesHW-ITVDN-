using System;

namespace _15ClassesHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            
            Console.WriteLine(calc.Add(1, 2));
            Console.WriteLine(calc.Div(10, 2));
            Console.WriteLine(calc.Div(10, 0));
            Console.ReadLine();
        }
    }
}

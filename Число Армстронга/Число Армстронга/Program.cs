using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Число_Армстронга
{
    class Program
    {
        static uint[] SplitNumber(uint n)
        {
            var result = new uint[0];
            int i = 0;
            while (n > 0)
            {
                Array.Resize(ref result, i + 1);
                result[i] = n % 10;
                n = n / 10;
                i++;
            }
            Array.Reverse(result);
            return result;
        }
        static uint Power(uint x, uint y)
        {
            return y == 0 ? 1 : x * Power(x, y - 1);
        }
        static bool Число_Армстронга(uint number)
        {
            var digits = SplitNumber(number);
            uint sum = 0u;
            var p = (uint)digits.Length;
            foreach (var digit in digits)
            {
                sum += Power(digit, p);
            }
            return sum == number;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Число Армстронга - это натуральное число, которое в данной системе\nсчисления равно сумме своих цифр, возведённых в степень, равную количеству его цифр.\n");
                Console.Write("Начало диапазона: ");
                uint s = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Конец диапазона: ");
                var e = Convert.ToUInt32(Console.ReadLine());


                Console.WriteLine("Числа Армстронга из диапазона от {0} до {1}", s, e);
                for (uint i = s; i <= e; i++)
                {
                    if (Число_Армстронга(i))
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
            catch (OverflowException) { Console.WriteLine("\nОшибка!"); }
            catch (FormatException) { Console.WriteLine("\nОшибка!"); }
            Console.ReadLine();
        }
    }
}

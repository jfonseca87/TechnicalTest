using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] myArray = { 1, 2, 2, 4, 5, 6, 7, 8, 9, 7 };
            int currentNumber = 0;
            int mostRepeatedNumber = 0;
            int mostRepeatedTimes = 0;
            int times = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == currentNumber)
                {
                    times++;
                    mostRepeatedNumber = currentNumber;
                    mostRepeatedTimes = times;
                }
                else
                {
                    currentNumber = myArray[i];
                    times = 1;
                }
            }

            Console.WriteLine($"The number {mostRepeatedNumber} is the most repeated with {mostRepeatedTimes} times");
            Console.ReadLine();
        }

        public static (int number, int quantity) GetMostRepeatedNumber(int[] array)
        {
            int currentNumber = 0;
            int mostRepeatedNumber = 0;
            int mostRepeatedTimes = 0;
            int times = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == currentNumber)
                {
                    times++;
                    mostRepeatedNumber = currentNumber;
                    mostRepeatedTimes = times;
                }
                else 
                {
                    currentNumber = array[i];
                    times = 1;
                }
            }

            return (mostRepeatedNumber, mostRepeatedTimes);
        }
    }
}

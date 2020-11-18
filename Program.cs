using System;
using System.Collections.Generic;

namespace ConsoleAppThisDoesntMakeAnySense
{
    static class Program
    {
        public delegate bool Predicate<TInput>(TInput input);
        public delegate T[] Del<T>(T[] input);

        static void Main(string[] args)
        {
            Console.WriteLine("Enter variables:");
            string variables = Console.ReadLine();

            string[] stringArray = variables.Split(',');
            int[] intArray = Array.ConvertAll(stringArray, int.Parse);

            Predicate<int> predicate = IsEven;
            Del<int> newArray = SortedArray;

            //
            Console.WriteLine("Input array:");
            ShowArray(intArray);
            Console.WriteLine("Result: ");
            ShowArray(intArray.ThisDoesntMakeAnySense(predicate, newArray));
            Console.WriteLine();

            //
            predicate = IsNegative;
            Console.WriteLine("Input array:");
            ShowArray(intArray);
            Console.WriteLine("Result: ");
            ShowArray(intArray.ThisDoesntMakeAnySense(predicate, newArray));
            Console.WriteLine();

            //
            intArray = null;
            Console.WriteLine("Input array:");
            ShowArray(intArray);
            Console.WriteLine("Result: ");
            ShowArray(intArray.ThisDoesntMakeAnySense(predicate, newArray));

        }

        public static void ShowArray<TInput>(TInput[] input)
        {
            try 
            {
                foreach (var item in input)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {

            }
        }

        public static T[] ThisDoesntMakeAnySense<T>(this T[] massive, Predicate<T> predicateDelegate, Del<T> newArray)
        {
            try
            {
                foreach (var item in massive)
                {
                    if (predicateDelegate(item))
                    {
                        return new T[8];
                    }
                }

                return newArray(massive);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {

            }

            return massive;
        }

        public static bool IsEven(int input)
        {
            if(input % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsNegative(int input)
        {
            if(input < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] SortedArray(int[] input)
        {
            Array.Sort(input);
            return input;
        }
    }
}

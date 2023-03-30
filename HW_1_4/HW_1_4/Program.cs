using System;

namespace HW_1_4
{
    /// <summary>
    /// Entry point of App.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Start point of App.
        /// </summary>
        /// <param name="args">added via console.</param>
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Greeting to all here, my dears!\nSo, Enter the array size: ");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n <= 0)
                {
                    Console.WriteLine("Array cannot be zero or nagative size!");
                }

                int[] numbers = new int[n];
                InitializeArray(numbers); // Fill initial array with random numbers from 1 to 26.

                int even = 0, odd = 0;
                CountNumbers(numbers, ref even, ref odd); // Count the amounts of even and odd numbers in the first array.

                int[] evenNumbers = new int[even];
                int[] oddNumbers = new int[odd];
                FillTwoArrays(numbers, ref evenNumbers, ref oddNumbers); // Sort numbers from initial array and fill arrays of even numbers and odd numbers.

                char[] alphabet = new char[26];
                FillCharArray(ref alphabet); // Create and fill alphabet array.

                char[] evenCharArray = new char[even];
                char[] oddCharArray = new char[odd];
                ConvertNumToChar(evenNumbers, ref evenCharArray, in alphabet); // Convert even numbers to chars in new array.
                ConvertNumToChar(oddNumbers, ref oddCharArray, in alphabet); // Convert odd numbers to chars in new array.
                CountCompareUpperChars(ref evenCharArray, ref oddCharArray); // Compare the amount of upper letters in arrays.

                Console.Write("\nThe even chars are: ");
                DisplayCharArray(evenCharArray); // Display array of even chars.

                Console.Write("\nThe odd chars are: ");
                DisplayCharArray(oddCharArray); // Display array of odd chars.

                Console.WriteLine("\nWould you like to try again? (Y / N)");
                string rec = Console.ReadLine();
                if (rec == "N" ^ rec == "n" ^ rec == "No" ^ rec == "no")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        /// <summary>
        /// Fill initial array with numbers from 1 to 26 including.
        /// </summary>
        /// <param name="numbers">Transfered.</param>
        /// <returns>Filled array.</returns>
        public static int[] InitializeArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Random().Next(1, 27);
            }

            return numbers;
        }

        private static void CountNumbers(int[] numbers, ref int even, ref int odd)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }
        }

        private static void FillTwoArrays(int[] numbers, ref int[] evenNumbers, ref int[] oddNumbers)
        {
            for (int k = 0, i = 0, j = 0; k < numbers.Length; k++)
            {
                if (numbers[k] % 2 == 0)
                {
                    evenNumbers[i++] = numbers[k];
                }
                else
                {
                    oddNumbers[j++] = numbers[k];
                }
            }
        }

        private static void FillCharArray(ref char[] array)
        {
            int j = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                array[j] = i;

                if (array[j] == 'a' || array[j] == 'e' || array[j] == 'i' || array[j] == 'h' || array[j] == 'j' || array[j] == 'd')
                {
                    array[j] = char.ToUpper(array[j]);
                }

                j++;
            }
        }

        private static void ConvertNumToChar(int[] numbers, ref char[] array, in char[] letters)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = numbers[i];
                array[i] = letters[j - 1];
            }
        }

        private static void CountCompareUpperChars(ref char[] array1, ref char[] array2)
        {
            int i = 0, j = 0;

            for (int k = 0; k < array1.Length; k++)
            {
                if (char.IsUpper(array1[k]))
                {
                    i++;
                }
            }

            for (int k = 0; k < array2.Length; k++)
            {
                if (char.IsUpper(array2[k]))
                {
                    j++;
                }
            }

            if (i > j)
            {
                Console.WriteLine($"Even array contains more, {i} upper letters, while Odd array contains {j}.");
            }
            else if (i == j)
            {
                Console.WriteLine($"Seems, that both arrays have the same amount of upper letters, {i} in each.");
            }
            else
            {
                Console.WriteLine($"Odd array contains more, {j} upper letters, while Even array contains {i}.");
            }
        }

        private static void DisplayCharArray(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
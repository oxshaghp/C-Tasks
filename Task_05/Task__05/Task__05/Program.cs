
using System;
using System.Linq;

namespace Task__05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("     C# ASSIGNMENT - PART 01 SOLUTIONS     ");
            Console.WriteLine("===========================================\n");

            // --- Problem 1: Division & Exception Handling ---
            Console.WriteLine("--- 1. Division & Exception Handling ---");
            try
            {
                Console.Write("Enter dividend (x): ");
                int x = int.Parse(Console.ReadLine()!);
                Console.Write("Enter divisor (y): ");
                int y = int.Parse(Console.ReadLine()!);

                int divResult = x / y;
                Console.WriteLine($"Result: {divResult}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            finally
            {
                // Question Purpose: The finally block executes unconditionally to handle cleanup operations regardless of success or failure.
                Console.WriteLine("Operation complete");
            }

            // --- Problem 2: Defensive Code & TryParse ---
            Console.WriteLine("\n--- 2. Defensive Code ---");
            // Question Answer: int.TryParse() returns a boolean instead of throwing an exception when input is invalid, making the program robust.
            try
            {
                TestDefensiveCode(5, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }

            // --- Problem 3: Nullable Types & Null-Coalescing ---
            Console.WriteLine("\n--- 3. Nullable Value Types ---");
            int? nullableInt = null;
            int defaultVal = nullableInt ?? 10; // Null-coalescing operator
            Console.WriteLine($"Value assigned via '??': {defaultVal}");
            Console.WriteLine($"HasValue: {nullableInt.HasValue}");
            // Question Answer: Accessing .Value on a null Nullable throws an InvalidOperationException.

            // --- Problem 4: Array Bounds ---
            Console.WriteLine("\n--- 4. Array Bounds Checking ---");
            int[] boundsArray = new int[5];
            try
            {
                int invalidVal = boundsArray[10]; // Out of bounds access
            }
            catch (IndexOutOfRangeException ex)
            {
                // Question Answer: Checking bounds prevents IndexOutOfRangeException and potential runtime crashes/security flaws.
                Console.WriteLine($"Caught Exception: {ex.Message}");
            }

            // --- Problem 5: 2D Array Sums ---
            Console.WriteLine("\n--- 5. 2D Array Row/Column Sums ---");
            int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            // Question Answer: GetLength(dimension) returns the size of a specific dimension (0 for rows, 1 for columns).
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++) rSum += matrix[i, j];
                Console.WriteLine($"Row {i} Sum: {rSum}");
            }

            // --- Problem 6: Jagged Arrays ---
            Console.WriteLine("\n--- 6. Jagged Arrays ---");
            int[][] jaggedArr = new int[3][];
            jaggedArr[0] = new int[] { 1, 2 };
            jaggedArr[1] = new int[] { 3, 4, 5, 6 };
            jaggedArr[2] = new int[] { 7, 8, 9 };
            // Question Answer: Rectangular arrays (int[,]) are single contiguous memory blocks. Jagged arrays (int[][]) are arrays of array-references.
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine($"Row {i}: " + string.Join(" ", jaggedArr[i]));
            }

            // --- Problem 7: Nullable Reference Types ---
            Console.WriteLine("\n--- 7. Nullable Reference Types ---");
            // Question Answer: Nullable reference types provide compile-time safety against NullReferenceException.
            string? nullableStr = "Test String";
            string forcedStr = nullableStr!; // Null-forgiveness operator (!)
            Console.WriteLine($"Suppressed Warning Value: {forcedStr}");

            // --- Problem 8: Boxing and Unboxing ---
            Console.WriteLine("\n--- 8. Boxing and Unboxing ---");
            int numVal = 100;
            object boxedVal = numVal; // Boxing
            try
            {
                string invalidCast = (string)boxedVal; // Invalid Unboxing
            }
            catch (InvalidCastException ex)
            {
                // Question Answer: Boxing allocates memory on the heap; heavy usage causes performance hits and Garbage Collection pressure.
                Console.WriteLine($"Unboxing Error: {ex.Message}");
            }

            // --- Problem 9: Out Parameters ---
            Console.WriteLine("\n--- 9. Out Parameters ---");
            SumAndMultiply(10, 20, out int sumRes, out int prodRes);
            Console.WriteLine($"Sum: {sumRes}, Product: {prodRes}");
            // Question Answer: out parameters pass uninitialized variables; C# requires them to be assigned before method returns.

            // --- Problem 10: Optional and Named Parameters ---
            Console.WriteLine("\n--- 10. Optional & Named Parameters ---");
            PrintString(count: 2, message: "Hello Named Parameter");
            // Question Answer: Optional parameters must be placed at the end so positional argument mapping is unambiguous.

            // --- Problem 11: Null Propagation Operator ---
            Console.WriteLine("\n--- 11. Null Propagation Operator ---");
            int[]? nullArray = null;
            int? arrayLength = nullArray?.Length; // Null propagation ?.
            // Question Answer: ?. short-circuits to null if the object is null, preventing NullReferenceException.
            Console.WriteLine($"Safely accessed length: {arrayLength?.ToString() ?? "Array is null"}");

            // --- Problem 12: Switch Expression ---
            Console.WriteLine("\n--- 12. Switch Expression ---");
            string dayName = "Monday";
            int dayNum = dayName switch
            {
                "Monday" => 1,
                "Tuesday" => 2,
                "Wednesday" => 3,
                "Thursday" => 4,
                "Friday" => 5,
                "Saturday" => 6,
                "Sunday" => 7,
                _ => -1
            };
            // Question Answer: Switch expressions are preferred over 'if' for mapping single values concisely with clean syntax.
            Console.WriteLine($"Day number for {dayName}: {dayNum}");

            // --- Problem 13: Params Keyword ---
            Console.WriteLine("\n--- 13. Params Keyword ---");
            Console.WriteLine($"Params Sum: {SumArray(1, 2, 3, 4, 5)}");
            // Question Answer: params must be a 1D array, must be the last parameter, and only one params parameter is allowed per method.


            Console.WriteLine("\n===========================================");
            Console.WriteLine("     C# ASSIGNMENT - PART 02 SOLUTIONS     ");
            Console.WriteLine("===========================================\n");

            // 1. Numbers in Range
            Console.WriteLine("--- Part 2 - 1: Print Numbers in Range (Input: 6) ---");
            int rangeLimit = 6;
            for (int i = 1; i <= rangeLimit; i++)
                Console.Write(i + (i == rangeLimit ? "" : ", "));
            Console.WriteLine();

            // 2. Multiplication Table
            Console.WriteLine("\n--- Part 2 - 2: Multiplication Table (Input: 7) ---");
            int mulInput = 7;
            for (int i = 1; i <= 12; i++)
                Console.Write((mulInput * i) + (i == 12 ? "" : ", "));
            Console.WriteLine();

            // 3. List Even Numbers
            Console.WriteLine("\n--- Part 2 - 3: List Even Numbers (Input: 16) ---");
            int evenLimit = 16;
            for (int i = 2; i <= evenLimit; i += 2)
                Console.Write(i + (i >= evenLimit - 1 ? "" : ", "));
            Console.WriteLine();

            // 4. Compute Exponentiation
            Console.WriteLine("\n--- Part 2 - 4: Exponentiation (3^4) ---");
            int baseNum = 3, expNum = 4;
            long powResult = 1;
            for (int i = 0; i < expNum; i++) powResult *= baseNum;
            Console.WriteLine($"Output: {powResult}");

            // 5. Reverse Text String
            Console.WriteLine("\n--- Part 2 - 5: Reverse String (Input: \"Hello\") ---");
            string strToRev = "Hello";
            char[] strArr = strToRev.ToCharArray();
            Array.Reverse(strArr);
            Console.WriteLine($"Output: {new string(strArr)}");

            // 6. Reverse Integer Value
            Console.WriteLine("\n--- Part 2 - 6: Reverse Integer (Input: 12345) ---");
            int numToRev = 12345, reversedNum = 0;
            while (numToRev > 0)
            {
                reversedNum = (reversedNum * 10) + (numToRev % 10);
                numToRev /= 10;
            }
            Console.WriteLine($"Output: {reversedNum}");

            // 7. Longest Distance Between Matching Elements
            Console.WriteLine("\n--- Part 2 - 7: Longest Distance Between Matching Elements ---");
            int[] distArr = new int[] { 7, 0, 0, 0, 0, 5, 6, 7, 5, 0, 7, 5, 3 };
            int maxDist = 0;
            for (int i = 0; i < distArr.Length; i++)
            {
                for (int j = distArr.Length - 1; j > i; j--)
                {
                    if (distArr[i] == distArr[j])
                    {
                        int dist = j - i - 1;
                        if (dist > maxDist) maxDist = dist;
                        break;
                    }
                }
            }
            Console.WriteLine($"Longest Distance: {maxDist}");

            // 8. Reverse Words in Sentence
            Console.WriteLine("\n--- Part 2 - 8: Reverse Words in Sentence ---");
            string sentence = "English is great";
            // Single Console.WriteLine statement using Split, Reverse, and Join
            Console.WriteLine(string.Join(" ", sentence.Split(' ').Reverse()));
        }

        // Helper Method for Problem 2
        public static void TestDefensiveCode(int x, int y)
        {
            if (x <= 0 || y <= 0) throw new ArgumentException("X and Y must be positive.");
            if (y <= 1) throw new ArgumentException("Y must be greater than 1.");
            Console.WriteLine($"Defensive code accepted: X={x}, Y={y}");
        }

        // Helper Method for Problem 9
        public static void SumAndMultiply(int a, int b, out int sum, out int product)
        {
            sum = a + b;
            product = a * b;
        }

        // Helper Method for Problem 10
        public static void PrintString(string message, int count = 5)
        {
            for (int i = 0; i < count; i++) Console.WriteLine(message);
        }

        // Helper Method for Problem 13
        public static int SumArray(params int[] numbers)
        {
            int total = 0;
            foreach (int n in numbers) total += n;
            return total;
        }
    }
}
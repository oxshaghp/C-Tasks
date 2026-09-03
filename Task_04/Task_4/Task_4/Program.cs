using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("            C# ARRAYS TASK SOLUTION               ");
            Console.WriteLine("==================================================\n");

            #region SECTION 01: Array Initialization & IndexOutOfRangeException
            Console.WriteLine("--- SECTION 01: Initialization & Index Exception ---");

            // 1. Initializer list
            int[] arrWay1 = new int[] { 10, 20, 30 };

            // 2. new int[size] + manual assignment
            int[] arrWay2 = new int[3];
            arrWay2[0] = 100;
            arrWay2[1] = 200;
            arrWay2[2] = 300;

            // 3. Array syntax sugar (Implicitly typed array / Collection expression syntax)
            int[] arrWay3 = [1, 2, 3];

            // Print elements of arrWay2
            Console.Write("Elements of arrWay2: ");
            for (int i = 0; i < arrWay2.Length; i++)
            {
                Console.Write(arrWay2[i] + " ");
            }
            Console.WriteLine();

            // Demonstrating IndexOutOfRangeException
            Console.WriteLine("\n[Testing Exception]");
            try
            {
                Console.WriteLine("Attempting to access index 5 in an array of size 3...");
                int invalidAccess = arrWay2[5]; // Index is out of bounds
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Caught Expected Exception: {ex.Message}");
            }

            /*
             * QUESTION ANSWER:
             * Default value assigned to array elements in C#:
             * - Numeric types (int, double, float, long, etc.): 0
             * - Boolean (bool): false
             * - Reference types (string, custom objects): null
             * - Character (char): '\0' (null character)
             */
            #endregion

            #region SECTION 02: Shallow Copy vs Deep Copy
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("--- SECTION 02: Shallow Copy vs Deep Copy ---");

            int[] originalArr = { 1, 2, 3 };

            // A. Shallow Copy (Reference Copy)
            int[] shallowArr = originalArr;
            shallowArr[0] = 99; // Modifying shallow copy

            Console.WriteLine($"Original after Shallow Copy modification: {originalArr[0]} (Changed!)");
            Console.WriteLine($"Shallow Copy value: {shallowArr[0]}");

            // Reset original array back
            originalArr[0] = 1;

            // B. Deep Copy using Clone()
            int[] deepArr = (int[])originalArr.Clone();
            deepArr[0] = 555; // Modifying deep copy

            Console.WriteLine($"Original after Deep Copy modification: {originalArr[0]} (Remained Unchanged)");
            Console.WriteLine($"Deep Copy value: {deepArr[0]}");

            /*
             * QUESTION ANSWER:
             * Array.Clone() vs Array.Copy():
             * - Array.Clone(): Creates a new array instance object and returns an object that needs casting. 
             *                  It duplicates the entire array structure (Deep copy for value types).
             * - Array.Copy(): Copies a range of elements from an existing array to another ALREADY EXISTING 
             *                 destination array. Gives precise control over source index, destination index, and length.
             */
            #endregion

            #region SECTION 03: 2D Array (Student Grades)
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("--- SECTION 03: 2D Array for Student Grades ---");

            int[,] studentGrades = new int[3, 3]; // 3 Students, 3 Subjects

            // Dynamic User Input
            Console.WriteLine("Please enter grades for 3 students (3 subjects each):");
            for (int student = 0; student < studentGrades.GetLength(0); student++)
            {
                Console.WriteLine($"\nStudent #{student + 1}:");
                for (int subject = 0; subject < studentGrades.GetLength(1); subject++)
                {
                    Console.Write($"  Enter grade for Subject #{subject + 1}: ");
                    int.TryParse(Console.ReadLine(), out studentGrades[student, subject]);
                }
            }

            // Printing Grades
            Console.WriteLine("\nDisplaying Student Grades:");
            for (int student = 0; student < studentGrades.GetLength(0); student++)
            {
                Console.Write($"Student {student + 1} Grades: ");
                for (int subject = 0; subject < studentGrades.GetLength(1); subject++)
                {
                    Console.Write($"{studentGrades[student, subject]}\t");
                }
                Console.WriteLine();
            }

            /*
             * QUESTION ANSWER:
             * GetLength() vs Length for Multidimensional Arrays:
             * - Length: Returns the TOTAL number of elements across ALL dimensions combined (e.g., 3x3 array returns 9).
             * - GetLength(dimension): Returns the number of elements in a specific dimension (0-indexed).
             *                          (e.g., GetLength(0) returns rows = 3, GetLength(1) returns columns = 3).
             */
            #endregion

            #region SECTION 04: Array Methods Showcase
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("--- SECTION 04: Array Methods Showcase ---");

            int[] numbers = { 40, 10, 50, 20, 30 };

            // Helper Lambda to print arrays easily
            void PrintArray(string label, int[] arr) =>
                Console.WriteLine($"{label}: [{string.Join(", ", arr)}]");

            PrintArray("Initial Array", numbers);

            // 1. Array.Sort()
            Array.Sort(numbers);
            PrintArray("1. After Array.Sort()", numbers); // Sorts elements in ascending order

            // 2. Array.Reverse()
            Array.Reverse(numbers);
            PrintArray("2. After Array.Reverse()", numbers); // Reverses the order of current elements

            // 3. Array.IndexOf()
            int target = 20;
            int index = Array.IndexOf(numbers, target);
            Console.WriteLine($"3. Array.IndexOf({target}): Found at index {index}"); // Returns 0-based index or -1 if not found

            // 4. Array.Copy()
            int[] copiedNumbers = new int[3];
            Array.Copy(numbers, 0, copiedNumbers, 0, 3);
            PrintArray("4. After Array.Copy() (First 3 elements)", copiedNumbers); // Copies specified range to destination array

            // 5. Array.Clear()
            Array.Clear(numbers, 0, 2);
            PrintArray("5. After Array.Clear() (Cleared first 2 elements)", numbers); // Resets elements to default value (0)

            /*
             * QUESTION ANSWER:
             * Array.Copy() vs Array.ConstrainedCopy():
             * - Array.Copy(): Standard copy. If a type mismatch or error occurs mid-operation, the operation stops,
             *                 leaving the destination array partially modified.
             * - Array.ConstrainedCopy(): Guarantees atomic behavior (Transaction-like). If the copy operation fails
             *                            due to runtime exceptions, it rolls back state and leaves target untouched.
             */
            #endregion

            #region SECTION 05: Iteration Loops (for, foreach, while)
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("--- SECTION 05: Array Iteration Loops ---");

            int[] sampleList = { 5, 10, 15, 20, 25 };

            // 1. For Loop
            Console.Write("A. Printing with FOR loop: ");
            for (int i = 0; i < sampleList.Length; i++)
            {
                Console.Write(sampleList[i] + " ");
            }
            Console.WriteLine();

            // 2. Foreach Loop
            Console.Write("B. Printing with FOREACH loop: ");
            foreach (int val in sampleList)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();

            // 3. While Loop (Reverse Order)
            Console.Write("C. Printing REVERSE with WHILE loop: ");
            int idx = sampleList.Length - 1;
            while (idx >= 0)
            {
                Console.Write(sampleList[idx] + " ");
                idx--;
            }
            Console.WriteLine();

            /*
             * QUESTION ANSWER:
             * Why is foreach preferred for read-only operations on arrays?
             * 1. Safety: Prevents accidental modification of elements inside the loop.
             * 2. Index Safety: Completely eliminates IndexOutOfRangeException risks.
             * 3. Readability & Maintenance: Cleaner syntax without managing index variables or step limits manually.
             * 4. Optimization: C# compiler optimizes foreach on standard single-dimensional arrays to be as fast as a indexed loop.
             */
            #endregion

            Console.WriteLine("\n==================================================");
            Console.WriteLine("               PROGRAM EXECUTED                   ");
            Console.WriteLine("==================================================");
        }
    }
}
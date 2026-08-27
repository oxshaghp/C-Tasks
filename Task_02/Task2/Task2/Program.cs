using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================================================
            // 1. Problem: Comments Example
            // =========================================================================

            // This is a single-line comment: Storing initial integer values
            int x1 = 10;
            int y1 = 20;

            /*
               This is a multi-line comment:
               The following lines calculate the sum of x1 and y1,
               and then display the result to the console output.
            */
            int sum1 = x1 + y1;
            Console.WriteLine(sum1);


            /*
               QUESTION: What is the shortcut to comment and uncomment a selected block of code in Visual Studio?
               ANSWER:
               - Comment selected block:   Ctrl + K, Ctrl + C
               - Uncomment selected block: Ctrl + K, Ctrl + U
            */


            // =========================================================================
            // 2. Problem: Identify and fix errors
            // =========================================================================

            /*
               Original Code with Errors:
               int x = "10";              // Error 1: Cannot implicitly convert type 'string' to 'int'
               console.WriteLine(x + y);  // Error 2: 'console' should be capitalized ('Console'). Error 3: 'y' is undefined.

               Fixed Version below:
            */
            int xFixed = 10; // Or string xFixed = "10"; depending on intention
            int yFixed = 20;
            Console.WriteLine(xFixed + yFixed);


            /*
               QUESTION: Explain the difference between a runtime error and a logical error with examples.
               ANSWER:
               - Runtime Error: Occurs while the program is running, causing it to crash or throw an exception.
                 Example: Division by zero -> int result = 10 / 0; (Throws DivideByZeroException).
               
               - Logical Error: The code runs without crashing, but produces incorrect results due to flawed logic.
                 Example: Calculating average as (a + b / 2) instead of ((a + b) / 2).
            */


            // =========================================================================
            // 3. Problem: Variable Declarations using Naming Conventions
            // =========================================================================

            string fullName = "John Doe"; // camelCase for local variables
            int age = 25;
            decimal monthlySalary = 5000.50m;
            bool isStudent = true;


            /*
               QUESTION: Why is it important to follow naming conventions such as PascalCase in C#?
               ANSWER:
               Following naming conventions improves code readability, maintainability, and consistency.
               In C#, PascalCase is standard for class names and methods, while camelCase is standard for local 
               variables and parameters. It helps developers immediately understand the scope and nature of an identifier.
            */


            // =========================================================================
            // 4. Problem: Reference Types Demonstration
            // =========================================================================

            Person p1 = new Person();
            p1.Name = "Alice";

            // p2 points to the exact same memory address on the Heap as p1
            Person p2 = p1;

            // Changing p2's property affects p1 as well
            p2.Name = "Bob";

            Console.WriteLine($"p1 Name: {p1.Name}"); // Output: Bob
            Console.WriteLine($"p2 Name: {p2.Name}"); // Output: Bob


            /*
               QUESTION: Explain the difference between value types and reference types in terms of memory allocation.
               ANSWER:
               - Value Types (e.g., int, double, struct): Allocated directly on the Stack. Stored data is the actual value.
               - Reference Types (e.g., class, string, array): The actual object data is allocated on the Heap, 
                 while the reference (address pointer) is stored on the Stack.
            */


            // =========================================================================
            // 5. Problem: Arithmetic Operations
            // =========================================================================

            int xVal = 15;
            int yVal = 4;

            int sum = xVal + yVal;
            int difference = xVal - yVal;
            int product = xVal * yVal;
            double division = (double)xVal / yVal; // Explicit cast for decimal accuracy
            int remainder = xVal % yVal;

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Division: {division}");
            Console.WriteLine($"Remainder: {remainder}");


            /*
               QUESTION: What will be the output of the following code? Explain why:
               int a = 2, b = 7; 
               Console.WriteLine(a % b);

               ANSWER:
               - Output: 2
               - Explanation: The modulus operator (%) returns the remainder of division. Since 2 divided by 7 
                 is 0 with a remainder of 2, the result is 2 (whenever dividend < divisor, the answer is the dividend itself).
            */


            // =========================================================================
            // 6. Problem: Logical Conditions
            // =========================================================================

            int numCheck = 14;

            if (numCheck > 10 && numCheck % 2 == 0)
            {
                Console.WriteLine($"{numCheck} is greater than 10 and even.");
            }


            /*
               QUESTION: How does the && (logical AND) operator differ from the & (bitwise AND) operator?
               ANSWER:
               - '&&' (Short-circuit Logical AND): Evaluates the right side ONLY if the left side is true. 
                 Operates on boolean expressions.
               - '&' (Bitwise / Logical AND): Evaluates BOTH sides regardless of the outcome.
                 Can operate on integer bits (bitwise) or boolean values without short-circuiting.
            */


            // =========================================================================
            // 7. Problem: Type Casting (Implicit vs Explicit)
            // =========================================================================

            double myDouble = 12.89;

            // Explicit Casting (double to int) - Truncates fractional part
            int myExplicitInt = (int)myDouble;

            // Implicit Casting (int to double) - Safe conversion, no data loss
            double myImplicitDouble = myExplicitInt;

            Console.WriteLine($"Original Double: {myDouble}");
            Console.WriteLine($"Explicit Int Cast: {myExplicitInt}"); // Output: 12
            Console.WriteLine($"Implicit Double Cast: {myImplicitDouble}"); // Output: 12.0


            /*
               QUESTION: Why is explicit casting required when converting a double to an int?
               ANSWER:
               Because converting a 'double' to an 'int' carries a risk of data loss (truncation of decimal places). 
               C# prevents automatic implicit narrowing conversions to enforce safety; explicit casting confirms developer intent.
            */


            // =========================================================================
            // 8. Problem: Age Input with Parsing & Validation
            // =========================================================================

            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();

            try
            {
                int userAge = int.Parse(ageInput);

                if (userAge > 0)
                {
                    Console.WriteLine($"Valid age entered: {userAge}");
                }
                else
                {
                    Console.WriteLine("Age must be greater than 0.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Input was not in a correct numerical format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The number entered is too large or too small.");
            }


            /*
               QUESTION: What exception might occur if the input is invalid and how can you handle it?
               ANSWER:
               - Exceptions:
                 1. FormatException: If non-numeric characters (e.g., "abc") are passed to Parse.
                 2. OverflowException: If the number is too large or small for int (e.g., > 2,147,483,647).
               - Handling: Use try-catch blocks as shown above, or use 'int.TryParse()' to avoid exceptions altogether.
            */


            // =========================================================================
            // 9. Problem: Prefix vs Postfix Increment
            // =========================================================================

            int pX = 5;
            Console.WriteLine($"Initial: {pX}");
            Console.WriteLine($"Prefix (++pX): {++pX}");   // Increments pX to 6, then returns 6
            Console.WriteLine($"Postfix (pX++): {pX++}");   // Returns 6, then increments pX to 7
            Console.WriteLine($"Final Value: {pX}");         // Output: 7


            /*
               QUESTION: Given the code below, what is the value of x after execution? Explain why
               int x = 5; 
               int y = ++x + x++;

               ANSWER:
               - Value of x: 7 (Value of y: 12)
               - Explanation Step-by-Step:
                 1. Initial: x = 5.
                 2. '++x' (Prefix): Increments x immediately to 6 and evaluates to 6.
                 3. The second operand uses x, which is currently 6.
                 4. 'x++' (Postfix): Returns current value 6 for the addition, then increments x to 7 afterwards.
                 5. Calculation for y: 6 + 6 = 12.
                 6. Final value of x becomes 7.
            */
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Calculator
    {
        /**
	 *  Our data structure, used to hold operands for the postfix calculation.
	 */
        private LinkedStack stack = new LinkedStack();

        /** Scanner to get input from the user from the command line. */


        /**
         *  Entry point method. Disregards any command line arguments.
         *
         *@param  args  The command line arguments
         */
        public static void Main()
        {
            // Instantiate a "Main" object so we don't have to make everything static
            Calculator app = new Calculator();
            bool playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.doCalculation();
            }
            Console.WriteLine("Bye.");
        }


        /**
         *  Get input string from user and perform calculation, returning true when
         *  finished. If the user wishes to quit this method returns false.
         *
         *@return    true if a calculation succeeded, false if the user wishes to quit
         */
        private bool doCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            String input = "2 2 +";

            input = Console.ReadLine();
            // looks like nextLine() blocks for input when used on an InputStream (System.in).  Docs don't say that!

            // See if the user wishes to quit
            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }
            // Go ahead with calculation
            String output = "4";
            try
            {
                output = evaluatePostFixInput(input);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e.Message);
                return true;
            }
            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }


        /**
         *  Evaluate an arithmetic expression written in postfix form.
         *
         *@param  input                         Postfix mathematical expression as a String
         *@return                               Answer as a String
         *@exception  IllegalArgumentException  Something went wrong
         */
        public String evaluatePostFixInput(String input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentNullException("Null or the empty string are not valid postfix expressions.");
            // Clear our stack before doing a new calculation
            stack.clear();

            String s;   // Temporary variable for token read
            double a;   // Temporary variable for operand
            double b;   // ...for operand
            double c;   // ...for answer
            double number;

            char[] separator = { ' ' };
            String[] st = input.Split(separator);
            int i = 0;
            while (i < st.Length)
            {
                if (Double.TryParse(st[i], out number))
                {
                    stack.push(number);    // if it's a number push it on the stack
                }
                else
                {
                    // Must be an operator or some other character or word.
                    s = st[i];
                    if (s.Length > 1)
                    {
                        throw new ArgumentNullException("Input Error: " + s + " is not an allowed number or operator");
                    }
                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if (stack.isEmpty())
                    {
                        throw new ArgumentNullException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = ((Double)(stack.pop()));
                    if (stack.isEmpty()) {
                        throw new ArgumentNullException("Improper input format. Stack became empty when expecting first operand.");
                    }
                    a = ((Double)(stack.pop()));
                    // Wrap up all operations in a single method, easy to add other binary operators this way if desired
                    c = doOperation(a, b, s);
                    // push the answer back on the stack
                    stack.push(c);
                }
                i++;
            }// End while
            return ((Double)(stack.pop())).ToString();
        }


        /**
         *  Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
         *
         *@param  a                             First operand
         *@param  b                             Second operand
         *@param  s                             operator
         *@return                               The answer
         *@exception  IllegalArgumentException  Something's fishy here
         */
        public double doOperation(double a, double b, String s)
        {
            double c = 0.0;
            if (s.Equals("+"))      // Can't use a switch-case with Strings, so we do if-else
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))

            {
                try
                {
                    c = (a / b);
                    if (b == 0)
                        throw new ArgumentNullException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentNullException(e.Message);
                }
            }
            else
                throw new ArgumentNullException("Improper operator: " + s + ", is not one of +, -, *, or /");

            return c;
        }
    }
}

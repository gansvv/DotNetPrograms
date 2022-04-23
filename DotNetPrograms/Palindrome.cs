using System;

namespace DotNetPrograms
{
    // A recursive C# program to check whether a given number is palindrome or not.
    class Palindrome
    {
        // A recursive function that check a str(s..e)
        // is palindrome or not.
        static bool IsPalRec(String str, int s, int e)
        {

            // If there is only one character
            if (s == e)
                return true;

            // If first and last character do not match
            if ((str[s]) != (str[e]))
                return false;

            // If there are more than two characters, check if middle
            // substring is also palindrome or not.
            if (s < e + 1)
                return IsPalRec(str, s + 1, e - 1);
            return true;
        }

        static bool IsPalindrome(String str)
        {
            int n = str.Length;

            // An empty string is considered as palindrome
            if (n == 0)
                return true;

            return IsPalRec(str, 0, n - 1);
        }

        public static bool PalindromeStringIterative(string input)
        {
            bool isPalindromeString = true;
            for (int i = 0; i < (input.Length / 2 + 1); i++)
            {
                if (!(input[i] == input[input.Length - i - 1]))
                {
                    isPalindromeString = false;
                    break;
                }
            }
            return isPalindromeString;
        }

        static bool IsPalindromeNumberChecker(int n)
        {
            // Find the appropriate
            // divisor to extract
            // the leading digit
            int divisor = 1;
            while (n / divisor >= 10)
                divisor *= 10;

            while (n != 0)
            {
                int leading = n / divisor;
                int trailing = n % 10;

                // If first and last digit not same return false.
                if (leading != trailing)
                    return false;

                // Removing the leading and trailing digit from number.
                n = (n % divisor) / 10;

                // Reducing divisor by a factor of 2 as 2  digits are dropped.
                divisor = divisor / 100;
            }
            return true;
        }

        // Driver Code
        public static void Run()
        {
            String str = "geeg";

            if (IsPalindrome(str))
                Console.Write("Yes");
            else
                Console.Write("No");
        }
    }
}

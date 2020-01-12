using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int n ; // 0011 0000 0101

            int choice;
            bool done = false;
            while (!done)
            {
                printMenu();
                try
                {
                    choice = getNumber();
                }
                catch
                {
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Introduceti un numar fara semn");
                        try
                        {
                            n = getNumber();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        Console.WriteLine(Convert2BCDUnsigned(n));
                        break;
                    case 2:
                        Console.WriteLine("Introduceti un numar cu semn");
                        try
                        {
                            n = getNumber();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        Console.WriteLine(Convert2BCDSigned(n));
                        break;
                    case 3:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        static int complement10(int n)
        {
             int nr = Math.Abs(n);
             int value = 0;
             int cifra = 0;
             Stack<int> stack = new Stack<int>();
             while (nr != 0)
             {
                 stack.Push(9-(nr % 10));
                 nr = nr / 10;
             }
             while (stack.Count > 0)
             {
                 cifra = stack.Pop();
                value = value * 10 + cifra;
             }

             return value+1;
             /*
            int nr = Math.Abs(n);
            int lungime = 0;
            while (nr != 0)
            {
                lungime++;
                nr = nr / 10;
            }
            int[] v = new int[lungime];
            for (int i = 0; i < lungime; i++)
            {
                v[i] = n % 10;
                n = n / 10;
            }
            int nrfinal = 0;
            for (int i = lungime; i > 0; i--)

            return nrfinal;
            */
        }
       private static string Convert2BCDSigned(int n)
        {
            int complN = complement10(n);
            // throw new NotImplementedException();
            //return Convert2BCDUnsigned(complement10(n));
            int cifra;
            string[] bcd = {"0000", "0001", "0010", "0011",
            "0100", "0101", "0110", "0111", "1000", "1001"};
            Stack<int> stack = new Stack<int>();
            while (complN > 0)
            {
                cifra = complN % 10;
                complN = complN / 10;
                stack.Push(cifra);
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                cifra = stack.Pop();
                sb.Append(bcd[cifra]);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private static int getNumber()
        {
            string line;
            line = Console.ReadLine();
            int n = 0;
            try
            {
                n = int.Parse(line);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
                throw;
            }

            return n;
        }

        private static void printMenu()
        {
            Console.WriteLine("Your choice...");
            Console.WriteLine("1. Unsigned BCD");
            Console.WriteLine("2. Signed BCD - Compl'10");
            Console.WriteLine("3. Quit");
        }

        private static string Convert2BCDUnsigned(int n)
        {
            int cifra;
            string[] bcd = {"0000", "0001", "0010", "0011",
            "0100", "0101", "0110", "0111", "1000", "1001"};
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                cifra = n % 10;
                n = n / 10;
                stack.Push(cifra);
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                cifra = stack.Pop();
                sb.Append(bcd[cifra]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}

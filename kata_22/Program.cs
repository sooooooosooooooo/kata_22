using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kata_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.CountCombinations(4, new[] { 1, 2 }));
        }
    }
    public static class Kata
    {
        public static int CountCombinations(int money, int[] coins)
        {
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            int n = 0;
            SelfMultiplierCheck(coins, list, list2, money,n);
            return list.Count;
        }
        public static void SelfMultiplierCheck(int[] coins, List<string> list, List<int> list2, int money,int n)
        {
            for (int i = n; i < coins.Length; i++)
            {
                list2.Add(coins[i]);
                if (list2.Sum() < money)
                {
                    SelfMultiplierCheck(coins, list, list2, money,n);
                    list2.Remove(coins[i]);
                    n++;
                }
                else if (list2.Sum() == money)
                {
                    list2.Sort();
                    if (list.Contains(string.Join(" ",list2)))
                    {
                        list2.Remove(coins[i]);
                    }
                    else
                    {
                        list.Add(string.Join(" ",list2));
                        list2.Remove(coins[i]);
                    }
                }
                else
                {
                    list2.Remove(coins[i]);
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int time = 0, tmpTime;
            for(int i = n; i < customers.Length;)
            {
                tmpTime = customers[0];
                for (int j = 1; j < n; j++)
                    if (tmpTime > customers[j])
                        tmpTime = customers[j];
                time += tmpTime;
                for (int j = 0; j < n; j++)
                {
                    customers[j] -= tmpTime;
                    if(customers[j] == 0 && i != customers.Length)
                    {
                        customers[j] = customers[i];
                        i++;
                    }
                }
            }
            tmpTime = customers[0];
            int remaining = n > customers.Length ? customers.Length : n;
            for (int i = 1; i < remaining; i++)
                if (tmpTime < customers[i])
                    tmpTime = customers[i];
            time += tmpTime;
            return time;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 3, 10};
            long time;
            time = HW1.QueueTime(arr, 2);
            Console.WriteLine($"Time: {time}");
        }
    }
}
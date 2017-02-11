using DataStructures.Collections;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Utils
    {
        public static int queueToBase(Queue<int> number, int newbase)
        {
            int returnnumber = 0;
            while (number.Count != 0)
            {
                int digit = number.Dequeue();
                int raisedBase = (int)(Math.Pow(10, number.Count));

                returnnumber += (digit * raisedBase);
            }
            return returnnumber;
        }

        public static void numberToQueue(int number, ref Queue<int> queue)
        {
            queue.Clear();

            string parsedNumber = number.ToString();

            for (int i = 0; i < parsedNumber.Length; i++)
                queue.Enqueue(int.Parse(parsedNumber[i].ToString()));
        }
    }
}

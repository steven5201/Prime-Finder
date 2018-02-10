using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFinder
{
    class PrimeGet
    {
        double startNum;
        double endNum;
        int taskNum;

        List<double> primes = new List<double>();

        public PrimeGet(double startNum, double endNum, int taskNum)
        {
            this.startNum = startNum;
            this.endNum = endNum;
            this.taskNum = taskNum;
        }

        public List<double> GetPrimes()
        {
            return primes;
        }

        public void NumsRun()
        {
            Console.WriteLine($"Task #{taskNum} running numbers {startNum} to {endNum}.");

            for (double i = startNum; i < endNum; i++)
            {
                if (CheckPrime(i))
                {
                    primes.Add(i);
                }
            }

            Console.WriteLine($"Finished task #{taskNum}");
        }

        private bool CheckPrime(double inputNumber)
        {
            bool isPrime = true;

            for (double lcv = 2; lcv < inputNumber - 1; lcv++)
            {
                if (inputNumber % lcv == 0)
                {
                    isPrime = false;
                    lcv = inputNumber;
                    break;
                }
            }

            return isPrime;
        }
    }
}

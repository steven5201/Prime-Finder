using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace PrimeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterationNum = GetBaseValues("How many tasks would you like to run: ");
            int numChange = GetBaseValues("How many values per task would you like to run: ");

            Console.WriteLine();
            Console.WriteLine("Enter the number you wish to use on the output file.");
            Console.WriteLine("If the file already exists it will be added onto the end.");
            Console.Write("Name: ");
            string fileName = Console.ReadLine();

            double currentNum = 0;
            Task[] tasks = new Task[iterationNum];
            PrimeGet[] primeGets = new PrimeGet[iterationNum];

            for (int i = 0; i < iterationNum; i++)
            {
                currentNum += numChange;
                primeGets[i] = new PrimeGet(currentNum - numChange, currentNum, i);
                tasks[i] = Task.Run(new Action(primeGets[i].NumsRun));
            }

            Task.WaitAll(tasks);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Writing primes to file...");

            using (StreamWriter writer = File.AppendText($"{fileName}.Primes"))
            {
                List<double> primes = new List<double>();

                foreach (PrimeGet primeGet in primeGets)
                {
                    primes.AddRange(primeGet.GetPrimes());
                }

                foreach (int num in primes)
                {
                    writer.WriteLine(num);
                }
            }
        }

        private static int GetBaseValues(string outputLine)
        {
            bool inputValid = true;
            int num = 0;

            do
            {
                Console.Write(outputLine);

                inputValid = int.TryParse(Console.ReadLine(), out num);

                if (inputValid)
                {
                    inputValid = (num > 0) ? true : false;
                }

                if (!inputValid)
                {
                    Console.WriteLine("Only positive whole numbers.");
                }
            } while (!inputValid);

            return num;
        }
    }
}

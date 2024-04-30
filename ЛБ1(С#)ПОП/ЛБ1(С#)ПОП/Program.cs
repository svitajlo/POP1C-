using System;
using System.Threading;

namespace threaddemo
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start();
        }

        void Start()
        {
            int numberOfThreads = 8;
            int[] startElements = { 0, 1, 2, 3, 4, 5, 6 , 7, 8, 9 }; // Кожен потік отримує своє унікальне початкове значення
            int step = 1;

            for (int i = 0; i < numberOfThreads; i++)
            {
                // Використовуємо замикання для передачі номеру потоку та його початкового значення
                (new Thread((threadNumber) => Calcuator(startElements[(int)threadNumber], step, (int)threadNumber))).Start(i);
            }

            Thread thread1 = new Thread(Stoper);
            thread1.Start();
        }

        void Calcuator(int startElement, int step, int threadNumber)
        {
            long sum = 0;
            long count = 0;
            int currentElement = startElement;

            while (!CanStop)
            {
                sum += currentElement;
                currentElement += step;
                count++;
            }

            Console.WriteLine($"Потiк {threadNumber}: Знайдена сума - {sum}, кiлькiсть елементiв - {count}");
        }

        private bool canStop = false;
        public bool CanStop { get => canStop; }

        public void Stoper()
        {
            Thread.Sleep(30 * 1000);
            canStop = true;
        }
    }
}

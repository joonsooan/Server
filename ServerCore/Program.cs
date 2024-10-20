namespace ServerCore
{
    internal class Program
    {
        private static int number = 0;
        private static object _obj = new object();

        private static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_obj)
                {
                    number++;
                }
            }
        }

        private static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_obj)
                {
                    number--;
                }
            }
        }

        private static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
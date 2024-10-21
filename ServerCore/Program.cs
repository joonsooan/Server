namespace ServerCore
{
    internal class FastLock
    {
        public int id;
    }

    internal class SessionManager
    {
        private static object _lock = new object();

        public static void TestSession()
        {
            lock (_lock)
            {
            }
        }

        public static void Test()
        {
            lock (_lock)
            {
                UserManager.TestUser();
            }
        }
    }

    internal class UserManager
    {
        private static object _lock = new object();

        public static void TestUser()
        {
            lock (_lock)
            {
            }
        }

        public static void Test()
        {
            lock (_lock)
            {
                SessionManager.TestSession();
            }
        }
    }

    internal class Program
    {
        private static int number = 0;
        private static object _obj = new object();

        private static void Thread_1()
        {
            for (int i = 0; i < 100; i++)
            {
                SessionManager.Test();
            }
        }

        private static void Thread_2()
        {
            for (int i = 0; i < 100; i++)
            {
                UserManager.Test();
            }
        }

        private static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();

            Thread.Sleep(100);

            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
namespace ServerCore
{
    internal class Lock
    {
        // bool <- 커널
        //private AutoResetEvent _available = new AutoResetEvent(true);
        private ManualResetEvent _available = new ManualResetEvent(true);

        public void Acquire()
        {
            _available.WaitOne(); // 입장 시도
        }

        public void Release()
        {
            _available.Set(); // flag = true
        }
    }

    internal class Program
    {
        private static int _num = 0;
        private static Lock _lock = new Lock();

        private static void Thread_1()
        {
            for (int i = 0; i < 10000; i++)
            {
                _lock.Acquire();
                _num++;
                _lock.Release();
            }
        }

        private static void Thread_2()
        {
            for (int i = 0; i < 10000; i++)
            {
                _lock.Acquire();
                _num--;
                _lock.Release();
            }
        }

        private static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);
        }
    }
}
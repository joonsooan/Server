using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static void MainThread(object state)
        {
            for ( int i = 0; i < 5; i++ )
            { 
                Console.WriteLine("Hello Thread");
            }
        }

        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(1, 1); // 최소 쓰레드: 1개
            ThreadPool.SetMaxThreads(5, 5); // 최대 쓰레드: 5개

            for (int i = 0; i < 5; i++)
            {
                Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning);
                t.Start();
            }

            //for ( int i = 0; i < 4; i++) // i < 5 이면 쓰레드 5개를 모두 사용, ThreadPool.QueueUserWorkItem(MainThread)이 실행 안됨
            //{
            //    ThreadPool.QueueUserWorkItem((obj) => { while (true) { } }); // 무한 루프를 돌림
            //}

            ThreadPool.QueueUserWorkItem(MainThread);

            //Thread t = new Thread(MainThread);
            //t.Name = "Test Thread";
            //t.IsBackground = true;
            //t.Start();

            //Console.WriteLine("Waiting for Thread");

            //t.Join();
            //Console.WriteLine("Hello World");

            while (true)
            {

            }
        }
    }
}
namespace ServerCore
{
    internal class Program
    {
        private static volatile bool _stop = false;

        private static void ThreadMain()
        {
            Console.WriteLine("쓰레드 시작");
            while (_stop == false)
            {
                // stop 신호를 기다림
            }
            Console.WriteLine("쓰레드 종료");
        }

        private static void Main(string[] args)
        {
            Task t = new Task(ThreadMain);
            t.Start();

            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("Stop 호출");
            Console.WriteLine("종료 대기중");
            t.Wait();
            Console.WriteLine("종료 성공");
        }
    }
}
namespace ServerCore
{
    internal class Program
    {
        private int _answer;
        private bool _complete;

        private void A()
        {
            _answer = 123;
            Thread.MemoryBarrier(); // Barrier 1
            _complete = true;
            Thread.MemoryBarrier(); // Barrier 2
        }

        private void B()
        {
            Thread.MemoryBarrier(); // Barrier 3
            if (_complete)
            {
                Thread.MemoryBarrier(); // Barrier 4
                Console.WriteLine(_answer);
            }
        }

        private static void Main(string[] args)
        {
        }
    }
}
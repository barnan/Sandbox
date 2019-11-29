using System.Threading;

namespace CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {

            Timer timer = new Timer(new TimerCallback(TargetMethod), null, 3000, 3000);

            Thread.SpinWait(750000);

        }

        private static void TargetMethod(object state)
        {

        }
    }
}

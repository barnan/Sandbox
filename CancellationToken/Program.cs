using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationToken
{

    public class CancellableExecutor
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public Task Execute(Action<System.Threading.CancellationToken> action)
        {
            return Task.Run(() => action(cts.Token), cts.Token);
        }

        public void Cancel()
        {
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // timer: 
            //Timer timer = new Timer(new TimerCallback(TargetMethod), null, 3000, 3000);
            //Thread.SpinWait(750000);


            // ------------------------------------------
            // cts: 
            CancellableExecutor cex = new CancellableExecutor();
            
            cex.Execute(new Action<System.Threading.CancellationToken>((source) => Console.WriteLine("hehe")));

            cex.Cancel();

            Console.ReadKey();


        }

        private static void TargetMethod(object state)
        {

        }
    }
}

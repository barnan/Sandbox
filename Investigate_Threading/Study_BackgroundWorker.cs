using System;
using System.ComponentModel;

namespace Investigate_Threading
{
    static class Study_BackgroundWorker
    {

        /// <summary>
        /// BackgroundWorker
        /// </summary>
        internal static void Prog13()
        {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += Do_Work;                                   // ez a worker
            bw.RunWorkerCompleted += Work_Completed;                // event ha befejezte
            bw.ProgressChanged += ProgressChangedEventHandler;      // event, ha a progresst akarja visszajelezni
            bw.WorkerReportsProgress = true;                        // ezzel küld progress értesítéseket

            bw.RunWorkerAsync("Hello to worker");                   // indítás (+ paraméter átadás)
        }

        private static void Do_Work(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine($"Worker started: {e.Argument}");

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    (sender as BackgroundWorker).ReportProgress(i);
                }
            }
        }

        private static void Work_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine($"Result: {e.Result}");
        }

        private static void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"Done: {e.ProgressPercentage} percent");
        }

    }
}

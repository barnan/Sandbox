using System;

namespace Investigate_Threading
{
    static class Study_AssyncDelegate
    {

        /// <summary>
        /// Asynchronous delegate
        /// </summary>
        internal static void Prog11()
        {
            Func<string, int> deleg = new Func<string, int>((string input) =>
            {
                return input.Length;
            });

            AsyncCallback action = (IAsyncResult input) =>
            {
                Func<string, int> target = (Func<string, int>)input.AsyncState;
                int result = target.EndInvoke(input);
                Console.WriteLine(result);
            };                                                                          // BeginInvoke -> elindítja a szál aszinkron futását, megadható egy callback, amit a futás végén meghív

            IAsyncResult resuilt = deleg.BeginInvoke("input", action, deleg);           // EndInvoke -> bevárja a resultot (ha még nincs kész), megkapja a resultot
        }


        /// <summary>
        /// Asynchronous delegate
        /// </summary>
        internal static void Prog12()
        {
            Func<string, int> deleg = new Func<string, int>((string input) =>
            {
                throw new Exception();
            });

            AsyncCallback action = (IAsyncResult input) =>
            {
                Func<string, int> target = (Func<string, int>)input.AsyncState;
                int result = target.EndInvoke(input);                               // itt újradobja az exception-t, ha nincs kezelve leáll az program
                Console.WriteLine(result);
            };
            try
            {
                IAsyncResult resuilt = deleg.BeginInvoke("input", action, deleg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception elkapva {ex.Message}");
            }
        }

    }
}

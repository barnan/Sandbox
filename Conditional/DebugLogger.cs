using System;
using System.Diagnostics;

namespace Conditional
{
    internal static class DebugLogger
    {
        private static TraceSwitch _switch = new TraceSwitch("MyAssemblyDebugSwitch", "switch or this assembly");

        static DebugLogger()
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        internal static void Message1(string text, TraceLevel level = TraceLevel.Info)
        {
            Debug.WriteLineIf(level <= _switch.Level, text);
        }

    }
}

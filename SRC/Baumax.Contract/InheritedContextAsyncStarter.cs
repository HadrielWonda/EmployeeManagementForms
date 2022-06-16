using System.Threading;

namespace Baumax.Contract
{
    public static class InheritedContextAsyncStarter
    {
        public static void Run(ParameterizedThreadStart whatToRun, object param)
        {
            InheritedContextThreadRunner runner = new InheritedContextThreadRunner(whatToRun);
            Thread thread = new Thread(new ParameterizedThreadStart(runner.Run));
            thread.IsBackground = true;
            thread.Start(param);
        }

        public static void Run(ThreadStart whatToRun)
        {
            InheritedContextThreadRunner runner = new InheritedContextThreadRunner(whatToRun);
            Thread thread = new Thread(new ThreadStart(runner.Run));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
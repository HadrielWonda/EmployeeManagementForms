using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    public interface IJob : ITask
    {
        Tasks Tasks { get; set; }
        ITask OnErrorTask { get; set; }
        bool StopOnError { get; set; }

        void LoadValues(IDictionary<string, string> cfg, ITaskResolver taskResolver);
    }
}

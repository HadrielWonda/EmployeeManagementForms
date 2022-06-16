using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    public interface ITaskResolver
    {
        ITask GetTaskByName(string name);
    }
}

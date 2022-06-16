using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    public interface IJobResolver
    {
        IJob GetJobByName(string name);
    }
}

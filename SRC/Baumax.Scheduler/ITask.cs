using System;
using System.Collections.Generic;

namespace Baumax.Scheduler
{
    public interface ITask
    {
        /// <summary>
        /// Task name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the task is active. Inactive tasks are not executed, but participates in scheduling as active tasks
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        /// Gets whether the task is currently executing
        /// </summary>
        bool Running { get;}

        /// <summary>
        /// if false then task cannot be run while running
        /// </summary>
        bool ParallelRunEnabled { get; set; }

        /// <summary>
        /// Start task execution. For inactive task, only next execution DateTime will be recalculated
        /// </summary>
        void Run();

        void SaveValues(IDictionary<string, string> cfg);
        void LoadValues(IDictionary<string, string> cfg);
    }
}
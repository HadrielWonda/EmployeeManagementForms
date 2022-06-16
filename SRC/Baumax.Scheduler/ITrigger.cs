using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Baumax.Scheduler.Config;

namespace Baumax.Scheduler
{
    public interface ITrigger
    {
        /// <summary>
        /// Gets or sets the DateTime when trigger should start.
        /// </summary>
        /// <value>The start datetime.</value>
        DateTime Start { get; set; }

        /// <summary>
        /// Task name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the task is active. Inactive tasks are not executed, but participates in scheduling as active tasks
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        /// Next scheduled execution time; The property should be used to change NextDateTime from external
        /// </summary>
        DateTime NextDateTime { get; }

        Jobs Jobs { get; set; }

        /// <summary>
        /// Force task to recalculate NextDateTime. 
        /// </summary>
        void RecalculateNextDateTime();

        void SaveValues(IDictionary<string, string> cfg);
        void LoadValues(IDictionary<string, string> cfg, IJobResolver jobResolver);

    }
}

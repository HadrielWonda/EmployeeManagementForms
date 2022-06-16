using System;
using System.Collections.Generic;

namespace Baumax.Scheduler
{
	public interface IScheduler
	{
	    void Start();
	    void Stop();

        void AddJob(IJob job);
		void AddJobRange(IEnumerable<IJob> jobs);
		void RemoveJob(IJob job);

        void AddTrigger(ITrigger trigger);
        void AddTriggerRange(IEnumerable<ITrigger> trigger);
        void RemoveTrigger(ITrigger trigger);

        void AddTask(ITask task);
        void AddTaskRange(IEnumerable<ITask> task);
        void RemoveTask(ITask task);

        ICollection<IJob> Jobs { get;}
        ICollection<ITrigger> Triggers { get;}
        ICollection<ITask> Tasks { get;}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    [Serializable]
    public sealed class Tasks : List<ITask>
    {
        public bool Contains(string name)
        {
            ITask res = Find(
                            delegate(ITask task)
                            {
                                return task.Name == name;
                            }
                           );
            return res != null;
        }

        public void Remove(string name)
        {
            RemoveAll(
                delegate(ITask task)
                    {
                        return task.Name == name;
                    }
                );
        }

        public ITask this[string name]
        {
            get
            {
                return Find(
                        delegate(ITask task)
                            {
                                return task.Name == name;
                            }
                        );
            }
        }
    }
}

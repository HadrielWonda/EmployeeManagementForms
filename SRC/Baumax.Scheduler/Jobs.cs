using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    [Serializable]
    public sealed class Jobs : List<IJob>
    {
        public bool Contains(string name)
        {
            IJob res = Find(
                            delegate(IJob job)
                            {
                                return job.Name == name;
                            }
                           );
            return res != null;
        }

        public void Remove(string name)
        {
            RemoveAll(
                delegate(IJob job)
                {
                    return job.Name == name;
                }
                );
        }

        public IJob this[string name]
        {
            get
            {
                return Find(
                        delegate(IJob job)
                        {
                            return job.Name == name;
                        }
                        );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler
{
    [Serializable]
    public sealed class Triggers : List<ITrigger>
    {
        public bool Contains(string name)
        {
            ITrigger res = Find(
                            delegate(ITrigger trigger)
                            {
                                return trigger.Name == name;
                            }
                           );
            return res != null;
        }

        public void Remove(string name)
        {
            RemoveAll(
                delegate(ITrigger trigger)
                {
                    return trigger.Name == name;
                }
                );
        }

        public ITrigger this[string name]
        {
            get
            {
                return Find(
                        delegate(ITrigger trigger)
                        {
                            return trigger.Name == name;
                        }
                        );
            }
        }
    }
}

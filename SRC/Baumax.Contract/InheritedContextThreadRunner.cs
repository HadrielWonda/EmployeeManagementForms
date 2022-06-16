using System;
using System.Collections.Generic;
using System.Threading;

namespace Baumax.Contract
{
    public class InheritedContextThreadRunner
    {
        private static readonly string[] _slotsToSave = {"__GC__CurrentMessage", "User"};

        private readonly Dictionary<string, object> ContextData = new Dictionary<string, object>(1);

        private MulticastDelegate WhatToRun;

        private void SaveSlots()
        {
            if (_slotsToSave != null)
            {
                foreach (string s in _slotsToSave)
                {
                    ContextData.Add(s, Thread.GetData(Thread.GetNamedDataSlot(s)));
                }
            }
        }

        private void RestoreSlots()
        {
            if (_slotsToSave != null)
            {
                foreach (string s in _slotsToSave)
                {
                    Thread.SetData(Thread.GetNamedDataSlot(s), ContextData[s]);
                }
            }
        }

        private void doInit(MulticastDelegate whatToRun)
        {
            SaveSlots();
            WhatToRun = whatToRun;
        }

        public InheritedContextThreadRunner(ParameterizedThreadStart whatToRun)
        {
            doInit(whatToRun);
        }

        public InheritedContextThreadRunner(ThreadStart whatToRun)
        {
            doInit(whatToRun);
        }

        public void Run(object parameter)
        {
            ParameterizedThreadStart invocation = WhatToRun as ParameterizedThreadStart;
            if (invocation == null)
            {
                throw new NullReferenceException(
                    "InheritedContextThreadRunner.Run(object parameter) : WhatToRun is not ParameterizedThreadStart");
            }
            RestoreSlots();
            invocation(parameter);
        }

        public void Run()
        {
            ThreadStart invocation = WhatToRun as ThreadStart;
            if (invocation == null)
            {
                throw new NullReferenceException(
                    "InheritedContextThreadRunner.Run() : WhatToRun is not ThreadStart");
            }
            RestoreSlots();
            invocation();
        }
    }
}
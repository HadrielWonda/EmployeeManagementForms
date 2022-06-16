using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Baumax.Import.Scheduler
{
    internal static class Util
    {
        static public void AddTextToLogFile(string fileName, string message, bool newLine)
        {
            using (StreamWriter w = File.AppendText(fileName))
            {
                if (newLine)
                    w.Write(string.Format("{0}{1}", w.NewLine, message));
                else
                    w.Write(message);
                w.Flush();
                w.Close();
            }
        }
    }
}

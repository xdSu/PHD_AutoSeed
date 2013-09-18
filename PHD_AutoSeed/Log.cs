using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PHD_AutoSeed
{
    class Log
    {
        public static void WriteLog(string log)
        {
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\phdautoseed.log",true,Encoding.ASCII);
            sw.WriteLine(DateTime.Now + ": " + log);
            sw.Close();
        }
    }
}

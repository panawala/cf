using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CollaborativeFiltering.Utility
{
    public class Logger
    {
        private Logger()
        {
            strWriteFilePath = @"WriteLog1.txt";
            swWriteFile = File.CreateText(strWriteFilePath);
        }
        private StreamWriter swWriteFile;
        private string strWriteFilePath; 
        public static readonly Logger Instance = new Logger();

        public void WriteLine(string format, params object[] arg)
        {
            //Console.WriteLine(format, arg);
            swWriteFile.WriteLine(format, arg);
        }


    }
}

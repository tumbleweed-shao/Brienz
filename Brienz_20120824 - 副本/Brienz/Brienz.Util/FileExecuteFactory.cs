using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Brienz.Util
{
    public class FileExecuteFactory
    {
        public static void OpenFile(string FilePath)
        {
            Process.Start(fileName: FilePath); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CopyPathToClipboard
{  
    public class ShortPath
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
                  [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                  [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                  int shortPathLength
                  );

        private string Value = "";

        public ShortPath(string filepath)
        {
            StringBuilder shortPath = new StringBuilder(255);

            GetShortPathName(filepath, shortPath, shortPath.Capacity);

            Value = shortPath.ToString();
        }

        public string ToString()
        {
            return Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CopyPathToClipboard
{
    class RelativePathHelper
    {        
        
        /// <summary>
        /// Get the relative path from one main directory path and an absolute filepath
        /// </summary>
        /// <param name="mainDirPath"></param>
        /// <param name="absoluteFilePath"></param>
        /// <returns></returns>
        public static string GetRelativePath(string mainDirPath, string absoluteFilePath)
        {
            string[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (
                !firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }

            if (newPath.StartsWith(@".\") && newPath.Length>2)
            {
                newPath = newPath.Substring(2);
            }

            return newPath;
        }
                

        public static string GetAbsolutePath(string directorypath, string filepath)
        {
            if (directorypath == "")
                return filepath;
            else
            {
                string curpath = Environment.CurrentDirectory;
                try
                {
                    Environment.CurrentDirectory = directorypath;
                    string str = System.IO.Path.GetFullPath(filepath);

                    return str;

                }
                finally
                {
                    Environment.CurrentDirectory = curpath;
                }
            }
        }

    }
}

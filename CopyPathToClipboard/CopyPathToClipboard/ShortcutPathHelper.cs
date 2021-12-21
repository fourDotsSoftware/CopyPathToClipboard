using System;
using System.Collections.Generic;
using System.Text;
using Shell32;

namespace CopyPathToClipboard
{
    public class ShortcutPathHelper
    {
        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;

                //System.Windows.Forms.MessageBox.Show(link.Path);
                return link.Path;
            }

            return string.Empty;
        }
    }
}

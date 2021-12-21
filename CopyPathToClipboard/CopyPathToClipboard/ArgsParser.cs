using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyPathToClipboard
{
    class ArgsParser
    {
        public static List<string> lsSelectedFiles = new List<string>();

        public static bool OpenMainAppSelected = false;
        public static bool ParseArgs(string[] args)
        {
            OpenMainAppSelected = false;

            /*
            string sa = "";
            for (int k = 0; k < args.Length; k++)
            {
                sa += args[k] + " ";
            }

            MessageBox.Show(sa);
            */

            if (args.Length == 0)
            {
                frmSettings fs = new frmSettings();
                fs.ShowDialog();
                return true;
            }
            else if (args.Length > 0)
            {               
                try
                {
                    if (args[0].ToLower().StartsWith("-tempfile:"))
                    {
                        string tempfile = GetParameter(args[0]);

                        //MessageBox.Show(tempfile);

                        using (StreamReader sr = new StreamReader(tempfile,Encoding.Unicode))
                        {
                            string scont = sr.ReadToEnd();

                            //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            args = SplitArguments(scont);
                            Module.args = args;

                            //MessageBox.Show(scont);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Module.ShowError("Error could not parse Arguments !", ex);
                    return false;
                }

                /*
                string sa = "";
                for (int k = 0; k < args.Length; k++)
                {
                    sa += args[k] + "|";
                }

                MessageBox.Show(sa);
                  */                              
                try
                {
                    for (int k = 0; k < args.Length; k++)
                    {
                        string arg = args[k];

                        //MessageBox.Show("0:"+arg);

                        if (args[k].ToLower().Trim().EndsWith(".lnk"))
                        {
                            try
                            {
                                lsSelectedFiles.Add(ShortcutPathHelper.GetShortcutTargetFile(args[k].Trim()));
                            }
                            catch (Exception exsh)       
                            {
                                Module.ShowError(exsh);
                            }

                        }
                        else if (System.IO.Directory.Exists(args[k]) || System.IO.File.Exists(args[k]))
                        {
                            lsSelectedFiles.Add(args[k]);
                        }                        
                    }

                    for (int k = 0; k < args.Length; k++)
                    {
                        string arg = args[k];
                        /*
                        
	 
	 
	 
	 int iCopyRelativePath;
	 int iCopyRelativePathSpace;
	 int iCopyRelativePathCRLF;

	 int iCopyURLEncodedRelativePath;
	 int iCopyURLEncodedRelativePathSpace;
	 int iCopyURLEncodedRelativePathCRLF;
	 int iCopyUNCPath;
	 int iCopyUNCPathSpace;
	 int iCopyUNCPathCRLF;
	 int iSettings;
         
                         */
                        Clipboard.Clear();
                        if (lsSelectedFiles.Count == 0) return false;

                        //MessageBox.Show("|"+arg+"|");
                        if (arg == "-CopyFullPath")
                        {
                            if (lsSelectedFiles.Count >0)
                            {
                                Clipboard.SetText(lsSelectedFiles[0]);
                            }
                        }
                        else if (arg == "-CopyFilename")
                        {
                            if (lsSelectedFiles.Count > 0)
                            {
                                Clipboard.SetText(System.IO.Path.GetFileName(lsSelectedFiles[0]));
                            }
                        }
                        else if (arg == "-CopyShortFullPath")
                        {
                            if (lsSelectedFiles.Count > 0)
                            {
                                Clipboard.SetText(new ShortPath(lsSelectedFiles[0]).ToString());
                            }
                        }
                        else if (arg == "-CopyShortFilename")
                        {
                            if (lsSelectedFiles.Count > 0)
                            {
                                Clipboard.SetText(new ShortPath(System.IO.Path.GetFileName(lsSelectedFiles[0])).ToString());
                            }
                        }
                        else if (arg == "-CopyFilenameNoExt")
                        {
                            if (lsSelectedFiles.Count > 0)
                            {                                
                                Clipboard.SetText(System.IO.Path.GetFileNameWithoutExtension(lsSelectedFiles[0]));
                            }
                        }
                        else if (arg == "-CopyParentFolderPath")
                        {
                            Clipboard.SetText(System.IO.Path.GetDirectoryName(lsSelectedFiles[0]));                            
                        }
                        else if (arg == "-CopyURLEncodedPath")
                        {
                            Clipboard.SetText(Uri.EscapeUriString(System.IO.Path.GetFileName(lsSelectedFiles[0])));

                        }
                        else if (arg == "-CopyUNCPath")
                        {
                            Clipboard.SetText(UNCHelper.GetUNCPath(lsSelectedFiles[0]));
                        }
                        else if (arg == "-CopyUNCPathSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = UNCHelper.GetUNCPath(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += " " + UNCHelper.GetUNCPath(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyUNCPathCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = UNCHelper.GetUNCPath(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += "\r\n" + UNCHelper.GetUNCPath(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyRelativePath")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";                                
                                txt = RelativePathHelper.GetRelativePath(fr.cmbBaseDir.Text, lsSelectedFiles[0]);
                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyRelativePathSpace")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";

                                for (int m = 0; m < lsSelectedFiles.Count; m++)
                                {
                                    if (m == 0)
                                    {
                                        txt = RelativePathHelper.GetRelativePath(fr.cmbBaseDir.Text,lsSelectedFiles[0]);
                                    }
                                    else
                                    {
                                        txt += " "+RelativePathHelper.GetRelativePath(fr.cmbBaseDir.Text, lsSelectedFiles[m]);
                                    }
                                }

                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyRelativePathCRLF")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";

                                for (int m = 0; m < lsSelectedFiles.Count; m++)
                                {
                                    if (m == 0)
                                    {
                                        txt = RelativePathHelper.GetRelativePath(fr.cmbBaseDir.Text, lsSelectedFiles[0]);
                                    }
                                    else
                                    {
                                        txt += "\r\n" + RelativePathHelper.GetRelativePath(fr.cmbBaseDir.Text, lsSelectedFiles[m]);
                                    }
                                }

                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyURLEncodedRelativePath")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";
                                Uri uri = new Uri(lsSelectedFiles[0]);
                                Uri uri_root=new Uri(fr.cmbBaseDir.Text);
                                
                                txt = uri_root.MakeRelativeUri(uri).ToString();
                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyURLEncodedRelativePathSpace")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";

                                for (int m = 0; m < lsSelectedFiles.Count; m++)
                                {
                                    if (m == 0)
                                    {
                                        
                                        Uri uri = new Uri(lsSelectedFiles[0]);
                                        Uri uri_root = new Uri(fr.cmbBaseDir.Text);

                                        txt = uri_root.MakeRelativeUri(uri).ToString();                                        
                                    }
                                    else
                                    {
                                        Uri uri = new Uri(lsSelectedFiles[m]);
                                        Uri uri_root = new Uri(fr.cmbBaseDir.Text);

                                        txt += " "+uri_root.MakeRelativeUri(uri).ToString();                                                                                
                                    }
                                }

                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyURLEncodedRelativePathCRLF")
                        {
                            frmRelativePath fr = new frmRelativePath();

                            if (fr.ShowDialog() == DialogResult.OK)
                            {
                                string txt = "";

                                for (int m = 0; m < lsSelectedFiles.Count; m++)
                                {
                                    if (m == 0)
                                    {

                                        Uri uri = new Uri(lsSelectedFiles[0]);
                                        Uri uri_root = new Uri(fr.cmbBaseDir.Text);

                                        txt = uri_root.MakeRelativeUri(uri).ToString();
                                    }
                                    else
                                    {
                                        Uri uri = new Uri(lsSelectedFiles[m]);
                                        Uri uri_root = new Uri(fr.cmbBaseDir.Text);

                                        txt += "\r\n" + uri_root.MakeRelativeUri(uri).ToString();
                                    }
                                }

                                Clipboard.SetText(txt);
                            }
                        }
                        else if (arg == "-CopyURLEncodedPathSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {                                    
                                    txt = Uri.EscapeUriString(System.IO.Path.GetFileName(lsSelectedFiles[0]));
                                }
                                else
                                {                                    
                                    txt += " " + Uri.EscapeUriString(System.IO.Path.GetFileName(lsSelectedFiles[m]));
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyURLEncodedPathCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = Uri.EscapeUriString(System.IO.Path.GetFileName(lsSelectedFiles[0]));
                                }
                                else
                                {
                                    txt += "\r\n" + Uri.EscapeUriString(System.IO.Path.GetFileName(lsSelectedFiles[m]));
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFilenameSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = System.IO.Path.GetFileName(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += " " + System.IO.Path.GetFileName(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFilenameCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = System.IO.Path.GetFileName(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += "\r\n" + System.IO.Path.GetFileName(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyShortFilenameSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = new ShortPath(System.IO.Path.GetFileName(lsSelectedFiles[0])).ToString();
                                }
                                else
                                {
                                    txt += " " + new ShortPath(System.IO.Path.GetFileName(lsSelectedFiles[m])).ToString();
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyShortFilenameCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = new ShortPath(System.IO.Path.GetFileName(lsSelectedFiles[0])).ToString();
                                }
                                else
                                {
                                    txt += "\r\n" + new ShortPath(System.IO.Path.GetFileName(lsSelectedFiles[m])).ToString();
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFilenameNoExtSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = System.IO.Path.GetFileNameWithoutExtension(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += " " + System.IO.Path.GetFileNameWithoutExtension(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFilenameNoExtCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = System.IO.Path.GetFileNameWithoutExtension(lsSelectedFiles[0]);
                                }
                                else
                                {
                                    txt += "\r\n" + System.IO.Path.GetFileNameWithoutExtension(lsSelectedFiles[m]);
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFullPathSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = lsSelectedFiles[0];
                                }
                                else
                                {
                                    txt += " " + lsSelectedFiles[m];
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyFullPathCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = lsSelectedFiles[0];
                                }
                                else
                                {
                                    txt += "\r\n" + lsSelectedFiles[m];
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyShortFullPathSpace")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = new ShortPath(lsSelectedFiles[0]).ToString();
                                }
                                else
                                {
                                    txt += " " + new ShortPath(lsSelectedFiles[m]).ToString();
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-CopyShortFullPathCRLF")
                        {
                            string txt = "";

                            for (int m = 0; m < lsSelectedFiles.Count; m++)
                            {
                                if (m == 0)
                                {
                                    txt = new ShortPath(lsSelectedFiles[0]).ToString();
                                }
                                else
                                {
                                    txt += "\r\n" + new ShortPath(lsSelectedFiles[m]).ToString();
                                }
                            }

                            Clipboard.SetText(txt);
                        }
                        else if (arg == "-Settings")
                        {
                            frmSettings fs = new frmSettings();
                            fs.ShowDialog();
                            return true;
                        }



                    }
                }
                catch (Exception ex)
                {
                    Module.ShowError("Error could not parse Arguments !", ex);
                }
                finally
                {
                    
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                return arg.Substring(spos + 1);
            }
        }

        private static List<string> GetParameterValues(string arg)
        {
            string str = GetParameter(arg);

            string[] spl = str.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> parval = new List<string>();

            for (int k = 0; k < spl.Length; k++)
            {
                parval.Add(spl[k]);
            }

            return parval;
        }               

        public static string[] SplitArguments(string commandLine)
    {
        char[] parmChars = commandLine.ToCharArray();
        bool inSingleQuote = false;
        bool inDoubleQuote = false;
        for (int index = 0; index < parmChars.Length; index++)
        {
            if (parmChars[index] == '"' && !inSingleQuote)
            {
                inDoubleQuote = !inDoubleQuote;
                parmChars[index] = '\n';
            }
            if (parmChars[index] == '\'' && !inDoubleQuote)
            {
                inSingleQuote = !inSingleQuote;
                parmChars[index] = '\n';
            }
            if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                parmChars[index] = '\n';
        }
        return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
     }
    }
}

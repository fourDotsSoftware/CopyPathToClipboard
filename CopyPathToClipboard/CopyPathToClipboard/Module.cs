using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CopyPathToClipboard
{
    class Module
    {
        public static string ApplicationTitle = "ImgTransformer V1.0.9 - 4dots Software";
        public static string ShortApplicationTitle = "ImgTransformer V1.0.9";
        public static string[] args = null;

        public static string StoreUrl = "http://www.imgtransformer.com/store/";
        public static List<string> SelectedFilepaths = new List<string>();
        public static List<string> SelectedOperations = new List<string>();
        public static List<string> SelectedParameters = new List<string>();

        public static string PresetFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ImgTransformer\Presets.xml";
        public static string ImageFilter = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png|Jpeg 2000 Images (*.jp2)|*.jp2|Images Files (*.jpg;*.jpeg;*.gif;*.png;*.bmp)|" +
        "*.jpg;*.jpeg;*.gif;*.png;*.bmp|All Files (*.*)|*.*";

        public static string ImageFilterForSave = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png";

        public static string ImagePattern = "*.jpeg;*.jpg;*.gif;*.bmp;*.png;*.tiff;*.ico;*.jp2;*.wmf;*.exif";
        public static bool DoNotOverwriteFiles = false;
        public static bool AskBeforeOverwrite = false;
        public static bool LeaveSameDateTime = false;


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
                
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
            return newPath;
        }

        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public static DialogResult ShowQuestionDialog(string msg, string caption)
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2,MessageBoxOptions.ServiceNotification);
        }


        public static void ShowError(Exception ex)
        {
            ShowError("Error", ex);
        }

        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        public static void ShowError(string msg, Exception ex)
        {
            ShowError(msg + "\n\n" + ex.Message);
        }

        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {           
            
        }

        public static bool IsImage(string filepath)
        {
            try
            {
                filepath = filepath.ToLower();
                FileInfo fi = new FileInfo(filepath);

                if (fi.Extension != String.Empty && Module.ImagePattern.IndexOf(fi.Extension) >= 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public static int _Modex64 = -1;

        public static bool Modex64
        {
            get
            {
                if (_Modex64 == -1)
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        _Modex64 = 1;
                        return true;
                    }
                    else
                    {
                        _Modex64 = 0;
                        return false;
                    }
                }
                else if (_Modex64 == 1)
                {
                    return true;
                }
                else if (_Modex64 == 0)
                {
                    return false;
                }
                return false;
            }
        }

    }     
}

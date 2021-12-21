using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CopyPathToClipboard
{
    class ExceptionsHelper
    {
        public static void AddUnhandledExceptionHandlers()
        {
            //1TODO remove
            //return;
            // Define a handler for unhandled exceptions.
            AppDomain.CurrentDomain.UnhandledException +=
                new System.UnhandledExceptionEventHandler(myExceptionHandler);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(
                myThreadExceptionHandler);


        }

        private static void myExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Module.ShowError("Unspecified Error", ex);


            /*
            Dim EX As Exception 
            EX = e.ExceptionObject 
            Console.WriteLine(EX.StackTrace) 
            End Sub 
            */
        }
        private static void myThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Module.ShowError("Unspecified Error", e.Exception);
            /*
            Private Sub MYThreadHandler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs) 
            Console.WriteLine(e.Exception.StackTrace) 
            End Sub
            */
        }

    }
}

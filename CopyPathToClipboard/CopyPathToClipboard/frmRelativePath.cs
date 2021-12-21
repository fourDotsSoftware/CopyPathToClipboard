using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CopyPathToClipboard
{
    public partial class frmRelativePath : CopyPathToClipboard.CustomForm
    {
        public frmRelativePath()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbBaseDir.Text.Trim() == String.Empty || !System.IO.Directory.Exists(cmbBaseDir.Text.Trim()))
            {
                Module.ShowMessage("Please insert a valid Base Directory !");
                return;
            }

            List<string> ls = new List<string>();                       

            for (int k = 0; k < cmbBaseDir.Items.Count; k++)
            {
                ls.Add(cmbBaseDir.Items[k].ToString());
            }

            ls.Remove(cmbBaseDir.Text);
            ls.Insert(0,cmbBaseDir.Text);

            RegistryKey reg = Registry.CurrentUser;
            RegistryKey reg2 = reg.OpenSubKey(@"Software\4dots Software");

            if (reg2==null)
            {
                reg2=reg.CreateSubKey("4dots Software");                
            }

            reg = reg2;
            reg2 = reg.OpenSubKey("CopyPathToClipboard",true);

            if (reg2 == null)
            {
                reg2 = reg.CreateSubKey("CopyPathToClipboard");
            }

            reg = reg2;

            reg2 = reg.OpenSubKey("RecentRelativePaths", true);
            if (reg2 == null)
            {
                reg2=reg.CreateSubKey("RecentRelativePaths");
            }

            string[] dirnames = reg2.GetValueNames();

            for (int k = 0; k < dirnames.Length; k++)
            {
                reg2.DeleteValue(dirnames[k]);
            }

            for (int k = 0; k < ls.Count && k < 20; k++)
            {
                reg2.SetValue("Dir #" + k.ToString(), ls[k]);
            }

            if (!cmbBaseDir.Text.EndsWith("\\"))
            {
                cmbBaseDir.Text += "\\";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = cmbBaseDir.Text;
            }
            catch { }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                cmbBaseDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void frmRelativePath_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser;

                reg=reg.OpenSubKey(@"Software\4dots Software\CopyPathToClipboard\RecentRelativePaths");

                if (reg == null) return;

                string[] dirnames = reg.GetValueNames();

                for (int k = 0; k < dirnames.Length; k++)
                {
                    cmbBaseDir.Items.Add(reg.GetValue(dirnames[k]));
                }

            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
            }
        }
    }
}


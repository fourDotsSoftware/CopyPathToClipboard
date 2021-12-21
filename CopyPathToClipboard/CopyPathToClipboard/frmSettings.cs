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
    public partial class frmSettings : CopyPathToClipboard.CustomForm
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser;

            RegistryKey reg2 = reg.OpenSubKey(@"Software\4dots Software",true);

            if (reg2 == null)
            {
                reg2=reg.CreateSubKey(@"Software\4dots Software");
            }

            reg=reg2;
            reg2=reg.OpenSubKey("CopyPathToClipboard",true);

            if (reg2==null)
            {
                reg2=reg.CreateSubKey("CopyPathToClipboard");
            }

            reg=reg2;

            reg2 = reg.OpenSubKey("MenuItems", true);

            if (reg2 == null)
            {
                reg2 = reg.CreateSubKey("MenuItems");
            }

            reg = reg2;

            chkFullpath.Checked=bool.Parse(reg.GetValue("Fullpath","True").ToString());
            chkFilename.Checked = bool.Parse(reg.GetValue("Filename", "True").ToString());

            chkShortFullpath.Checked = bool.Parse(reg.GetValue("ShortFullpath", "True").ToString());
            chkShortFilename.Checked = bool.Parse(reg.GetValue("ShortFilename", "True").ToString());

            chkParentFolder.Checked = bool.Parse(reg.GetValue("ParentFolder", "True").ToString());

            chkURLFilename.Checked = bool.Parse(reg.GetValue("Copy URL Filename", "True").ToString());
            chkRelativePath.Checked = bool.Parse(reg.GetValue("Copy Relative Path", "True").ToString());
            chkURLRelativePath.Checked = bool.Parse(reg.GetValue("Copy URL Relative Path", "True").ToString());

            chkFilenameNoExt.Checked = bool.Parse(reg.GetValue("Filename Without Extension", "True").ToString());
            chkUNCPath.Checked = bool.Parse(reg.GetValue("Copy UNC Path", "True").ToString());
            chkSettings.Checked = bool.Parse(reg.GetValue("Settings", "True").ToString());
            
            /*
            reg.DeleteValue("Fullpath",false);
            reg.DeleteValue("Filename",false);

            reg.DeleteValue("ParentFolder",false);
            reg.DeleteValue("Copy URL Filename",false);

            reg.DeleteValue("Copy Relative Path",false);
            reg.DeleteValue("Copy URL Relative Path",false);

            reg.DeleteValue("Filename Without Extension",false);
            reg.DeleteValue("Copy UNC Path",false);

            reg.DeleteValue("Settings",false);
            */

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser;

            RegistryKey reg2 = reg.OpenSubKey(@"Software\4dots Software",true);

            if (reg2 == null)
            {
                reg2=reg.CreateSubKey(@"Software\4dots Software");
            }

            reg=reg2;
            reg2=reg.OpenSubKey("CopyPathToClipboard",true);

            if (reg2==null)
            {
                reg2=reg.CreateSubKey("CopyPathToClipboard");
            }

            reg=reg2;

            reg2 = reg.OpenSubKey("MenuItems", true);

            if (reg2 == null)
            {
                reg2 = reg.CreateSubKey("MenuItems");
            }

            reg = reg2;

            reg.SetValue("Fullpath",chkFullpath.Checked.ToString());
            reg.SetValue("Filename",chkFilename.Checked.ToString());

            reg.SetValue("ShortFullpath", chkShortFullpath.Checked.ToString());
            reg.SetValue("ShortFilename", chkShortFilename.Checked.ToString());

            reg.SetValue("ParentFolder",chkParentFolder.Checked.ToString());
            reg.SetValue("Copy URL Filename",chkURLFilename.Checked.ToString());

            reg.SetValue("Copy Relative Path",chkRelativePath.Checked.ToString());
            reg.SetValue("Copy URL Relative Path",chkURLRelativePath.Checked.ToString());

            reg.SetValue("Filename Without Extension",chkFilenameNoExt.Checked.ToString());
            reg.SetValue("Copy UNC Path",chkUNCPath.Checked.ToString());

            reg.SetValue("Settings",chkSettings.Checked.ToString());

            this.DialogResult = DialogResult.OK;
        }

        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSettings.Checked)
            {
                Module.ShowMessage("Warning : If you hide the Settings Menu Item, then you can access in the Future the Settings Screen by running the Executable CopyPathToClipboard or by clicking its Shortcut on the Start Menu or Desktop");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}


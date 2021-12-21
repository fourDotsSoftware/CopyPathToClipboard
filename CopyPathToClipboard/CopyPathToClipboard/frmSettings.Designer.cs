namespace CopyPathToClipboard
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFullpath = new System.Windows.Forms.CheckBox();
            this.chkFilename = new System.Windows.Forms.CheckBox();
            this.chkParentFolder = new System.Windows.Forms.CheckBox();
            this.chkURLFilename = new System.Windows.Forms.CheckBox();
            this.chkRelativePath = new System.Windows.Forms.CheckBox();
            this.chkURLRelativePath = new System.Windows.Forms.CheckBox();
            this.chkFilenameNoExt = new System.Windows.Forms.CheckBox();
            this.chkUNCPath = new System.Windows.Forms.CheckBox();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.chkShortFullpath = new System.Windows.Forms.CheckBox();
            this.chkShortFilename = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(223, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(85, 407);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose which Items will be visible in the Context Menu";
            // 
            // chkFullpath
            // 
            this.chkFullpath.AutoSize = true;
            this.chkFullpath.BackColor = System.Drawing.Color.Transparent;
            this.chkFullpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkFullpath.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFullpath.Location = new System.Drawing.Point(33, 47);
            this.chkFullpath.Name = "chkFullpath";
            this.chkFullpath.Size = new System.Drawing.Size(127, 20);
            this.chkFullpath.TabIndex = 8;
            this.chkFullpath.Text = "Copy Full Path";
            this.chkFullpath.UseVisualStyleBackColor = false;
            // 
            // chkFilename
            // 
            this.chkFilename.AutoSize = true;
            this.chkFilename.BackColor = System.Drawing.Color.Transparent;
            this.chkFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkFilename.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFilename.Location = new System.Drawing.Point(33, 79);
            this.chkFilename.Name = "chkFilename";
            this.chkFilename.Size = new System.Drawing.Size(131, 20);
            this.chkFilename.TabIndex = 9;
            this.chkFilename.Text = "Copy Filename";
            this.chkFilename.UseVisualStyleBackColor = false;
            // 
            // chkParentFolder
            // 
            this.chkParentFolder.AutoSize = true;
            this.chkParentFolder.BackColor = System.Drawing.Color.Transparent;
            this.chkParentFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkParentFolder.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkParentFolder.Location = new System.Drawing.Point(33, 111);
            this.chkParentFolder.Name = "chkParentFolder";
            this.chkParentFolder.Size = new System.Drawing.Size(196, 20);
            this.chkParentFolder.TabIndex = 10;
            this.chkParentFolder.Text = "Copy Parent Folder Path";
            this.chkParentFolder.UseVisualStyleBackColor = false;
            // 
            // chkURLFilename
            // 
            this.chkURLFilename.AutoSize = true;
            this.chkURLFilename.BackColor = System.Drawing.Color.Transparent;
            this.chkURLFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkURLFilename.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkURLFilename.Location = new System.Drawing.Point(33, 207);
            this.chkURLFilename.Name = "chkURLFilename";
            this.chkURLFilename.Size = new System.Drawing.Size(165, 20);
            this.chkURLFilename.TabIndex = 11;
            this.chkURLFilename.Text = "Copy URL Filename";
            this.chkURLFilename.UseVisualStyleBackColor = false;
            // 
            // chkRelativePath
            // 
            this.chkRelativePath.AutoSize = true;
            this.chkRelativePath.BackColor = System.Drawing.Color.Transparent;
            this.chkRelativePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkRelativePath.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkRelativePath.Location = new System.Drawing.Point(33, 239);
            this.chkRelativePath.Name = "chkRelativePath";
            this.chkRelativePath.Size = new System.Drawing.Size(160, 20);
            this.chkRelativePath.TabIndex = 12;
            this.chkRelativePath.Text = "Copy Relative Path";
            this.chkRelativePath.UseVisualStyleBackColor = false;
            // 
            // chkURLRelativePath
            // 
            this.chkURLRelativePath.AutoSize = true;
            this.chkURLRelativePath.BackColor = System.Drawing.Color.Transparent;
            this.chkURLRelativePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkURLRelativePath.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkURLRelativePath.Location = new System.Drawing.Point(33, 271);
            this.chkURLRelativePath.Name = "chkURLRelativePath";
            this.chkURLRelativePath.Size = new System.Drawing.Size(194, 20);
            this.chkURLRelativePath.TabIndex = 13;
            this.chkURLRelativePath.Text = "Copy URL Relative Path";
            this.chkURLRelativePath.UseVisualStyleBackColor = false;
            // 
            // chkFilenameNoExt
            // 
            this.chkFilenameNoExt.AutoSize = true;
            this.chkFilenameNoExt.BackColor = System.Drawing.Color.Transparent;
            this.chkFilenameNoExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkFilenameNoExt.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFilenameNoExt.Location = new System.Drawing.Point(33, 303);
            this.chkFilenameNoExt.Name = "chkFilenameNoExt";
            this.chkFilenameNoExt.Size = new System.Drawing.Size(253, 20);
            this.chkFilenameNoExt.TabIndex = 14;
            this.chkFilenameNoExt.Text = "Copy Filename without Extension";
            this.chkFilenameNoExt.UseVisualStyleBackColor = false;
            // 
            // chkUNCPath
            // 
            this.chkUNCPath.AutoSize = true;
            this.chkUNCPath.BackColor = System.Drawing.Color.Transparent;
            this.chkUNCPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkUNCPath.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkUNCPath.Location = new System.Drawing.Point(33, 335);
            this.chkUNCPath.Name = "chkUNCPath";
            this.chkUNCPath.Size = new System.Drawing.Size(134, 20);
            this.chkUNCPath.TabIndex = 15;
            this.chkUNCPath.Text = "Copy UNC Path";
            this.chkUNCPath.UseVisualStyleBackColor = false;
            // 
            // chkSettings
            // 
            this.chkSettings.AutoSize = true;
            this.chkSettings.BackColor = System.Drawing.Color.Transparent;
            this.chkSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkSettings.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkSettings.Location = new System.Drawing.Point(33, 367);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(83, 20);
            this.chkSettings.TabIndex = 16;
            this.chkSettings.Text = "Settings";
            this.chkSettings.UseVisualStyleBackColor = false;
            this.chkSettings.CheckedChanged += new System.EventHandler(this.chkSettings_CheckedChanged);
            // 
            // chkShortFullpath
            // 
            this.chkShortFullpath.AutoSize = true;
            this.chkShortFullpath.BackColor = System.Drawing.Color.Transparent;
            this.chkShortFullpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkShortFullpath.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkShortFullpath.Location = new System.Drawing.Point(33, 143);
            this.chkShortFullpath.Name = "chkShortFullpath";
            this.chkShortFullpath.Size = new System.Drawing.Size(167, 20);
            this.chkShortFullpath.TabIndex = 17;
            this.chkShortFullpath.Text = "Copy Short Full Path";
            this.chkShortFullpath.UseVisualStyleBackColor = false;
            // 
            // chkShortFilename
            // 
            this.chkShortFilename.AutoSize = true;
            this.chkShortFilename.BackColor = System.Drawing.Color.Transparent;
            this.chkShortFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkShortFilename.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkShortFilename.Location = new System.Drawing.Point(33, 175);
            this.chkShortFilename.Name = "chkShortFilename";
            this.chkShortFilename.Size = new System.Drawing.Size(171, 20);
            this.chkShortFilename.TabIndex = 18;
            this.chkShortFilename.Text = "Copy Short Filename";
            this.chkShortFilename.UseVisualStyleBackColor = false;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 449);
            this.Controls.Add(this.chkShortFilename);
            this.Controls.Add(this.chkShortFullpath);
            this.Controls.Add(this.chkSettings);
            this.Controls.Add(this.chkUNCPath);
            this.Controls.Add(this.chkFilenameNoExt);
            this.Controls.Add(this.chkURLRelativePath);
            this.Controls.Add(this.chkRelativePath);
            this.Controls.Add(this.chkURLFilename);
            this.Controls.Add(this.chkParentFolder);
            this.Controls.Add(this.chkFilename);
            this.Controls.Add(this.chkFullpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Copy Path To Clipboard - Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFullpath;
        private System.Windows.Forms.CheckBox chkFilename;
        private System.Windows.Forms.CheckBox chkParentFolder;
        private System.Windows.Forms.CheckBox chkURLFilename;
        private System.Windows.Forms.CheckBox chkRelativePath;
        private System.Windows.Forms.CheckBox chkURLRelativePath;
        private System.Windows.Forms.CheckBox chkFilenameNoExt;
        private System.Windows.Forms.CheckBox chkUNCPath;
        private System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.CheckBox chkShortFullpath;
        private System.Windows.Forms.CheckBox chkShortFilename;
    }
}

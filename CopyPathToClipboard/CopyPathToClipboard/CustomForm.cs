using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CopyPathToClipboard
{
    public partial class CustomForm : Form
    {
        private bool LoadComplete=false;

        public CustomForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.ResizeRedraw = true;
            this.Icon = Properties.Resources.copy_path_to_clipboard;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            if (!LoadComplete) return;

            try
            {
                
                System.Drawing.Graphics g = e.Graphics;
                int x = this.Width;
                int y = this.Height;

                System.Drawing.Drawing2D.LinearGradientBrush
                    lgBrush = new System.Drawing.Drawing2D.LinearGradientBrush
                    (new System.Drawing.Point(0, 0), new System.Drawing.Point(x, y),
                    Color.White, Color.FromArgb(190, 190, 190));
                lgBrush.GammaCorrection = true;
                g.FillRectangle(lgBrush, 0, 0, x, y);

            }
            catch
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                
                //System.Windows.Forms.Application.UseWaitCursor = true;
                //base.Cursor = Cursors.WaitCursor;
                base.OnLoad(e);
                //base.Cursor = null;

                foreach (Control co in this.Controls)
                {
                    if (co is Button)
                    {
                        if (co.Name == "btnOK")
                        {
                            this.AcceptButton = (Button)co;
                        }
                        else if (co.Name == "btnCancel")
                        {
                            this.CancelButton = (Button)co;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
            }
            finally
            {
                Cursor.Current = null;
                System.Windows.Forms.Application.UseWaitCursor = false;
                LoadComplete = true;
                
                this.Invalidate();
            }
        }

        private void CustomForm_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
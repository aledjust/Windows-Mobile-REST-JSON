namespace WMRESTJSON
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuSearchItunes = new System.Windows.Forms.MenuItem();
            this.grdITunesSearchResult = new System.Windows.Forms.DataGrid();
            this.statusMain = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuExit);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.mnuSearchItunes);
            this.menuItem2.Text = "Menu";
            // 
            // mnuSearchItunes
            // 
            this.mnuSearchItunes.Text = "Get Data";
            this.mnuSearchItunes.Click += new System.EventHandler(this.mnuSearchItunes_Click);
            // 
            // grdITunesSearchResult
            // 
            this.grdITunesSearchResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdITunesSearchResult.BackgroundColor = System.Drawing.Color.White;
            this.grdITunesSearchResult.Location = new System.Drawing.Point(3, 0);
            this.grdITunesSearchResult.Name = "grdITunesSearchResult";
            this.grdITunesSearchResult.Size = new System.Drawing.Size(234, 236);
            this.grdITunesSearchResult.TabIndex = 4;
            // 
            // statusMain
            // 
            this.statusMain.Location = new System.Drawing.Point(0, 246);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(240, 22);
            this.statusMain.Text = "Consume JSON web service.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.grdITunesSearchResult);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdITunesSearchResult;
        private System.Windows.Forms.StatusBar statusMain;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuSearchItunes;
    }
}


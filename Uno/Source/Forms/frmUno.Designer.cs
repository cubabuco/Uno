using System.ComponentModel;
using System.Windows.Forms;

namespace Uno
{
    partial class FrmUno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

            menuStrip?.Dispose();
            fileToolStripMenuItem?.Dispose();
            newToolStripMenuItem?.Dispose();
            exitToolStripMenuItem?.Dispose();
            helpToolStripMenuItem?.Dispose();
            aboutToolStripMenuItem?.Dispose();
            tableLayoutPanel?.Dispose();
            outerTableLayout?.Dispose();
            tableSidePanel?.Dispose();
            lblScore?.Dispose();
            lblPlayerScoreHeader?.Dispose();
            lblOpponentHeader?.Dispose();
            lblColorRunningHeader?.Dispose();
            btnPass?.Dispose();
            lblOpponentScore?.Dispose();
            lblPlayerScore?.Dispose();
            lblColorRunning?.Dispose();

            menuStrip = null;
            fileToolStripMenuItem = null;
            newToolStripMenuItem = null;
            exitToolStripMenuItem = null;
            helpToolStripMenuItem = null;
            aboutToolStripMenuItem = null;
            tableLayoutPanel = null;
            outerTableLayout = null;
            tableSidePanel = null;
            lblScore = null;
            lblPlayerScoreHeader = null;
            lblOpponentHeader = null;
            lblColorRunningHeader = null;
            btnPass = null;
            lblOpponentScore = null;
            lblPlayerScore = null;
            lblColorRunning = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUno));
            this.outerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableSidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblColorRunningHeader = new System.Windows.Forms.Label();
            this.lblColorRunning = new System.Windows.Forms.Label();
            this.lblOpponentScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblOpponentHeader = new System.Windows.Forms.Label();
            this.lblPlayerScoreHeader = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnPass = new System.Windows.Forms.Button();
            this.outerTableLayout.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tableSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerTableLayout
            // 
            this.outerTableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.outerTableLayout.ColumnCount = 2;
            this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.outerTableLayout.Controls.Add(this.tableLayoutPanel, 0, 1);
            this.outerTableLayout.Controls.Add(this.menuStrip, 0, 0);
            this.outerTableLayout.Controls.Add(this.tableSidePanel, 1, 1);
            this.outerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerTableLayout.Location = new System.Drawing.Point(0, 0);
            this.outerTableLayout.Name = "outerTableLayout";
            this.outerTableLayout.RowCount = 2;
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outerTableLayout.Size = new System.Drawing.Size(743, 525);
            this.outerTableLayout.TabIndex = 6;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(557, 498);
            this.tableLayoutPanel.TabIndex = 7;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            this.tableLayoutPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel_MouseUp);
            // 
            // menuStrip
            // 
            this.outerTableLayout.SetColumnSpan(this.menuStrip, 2);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(743, 21);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 17);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 17);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableSidePanel
            // 
            this.tableSidePanel.ColumnCount = 2;
            this.tableSidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSidePanel.Controls.Add(this.lblColorRunningHeader, 0, 4);
            this.tableSidePanel.Controls.Add(this.lblColorRunning, 0, 4);
            this.tableSidePanel.Controls.Add(this.lblOpponentScore, 1, 2);
            this.tableSidePanel.Controls.Add(this.lblPlayerScore, 0, 2);
            this.tableSidePanel.Controls.Add(this.lblOpponentHeader, 1, 1);
            this.tableSidePanel.Controls.Add(this.lblPlayerScoreHeader, 0, 1);
            this.tableSidePanel.Controls.Add(this.lblScore, 0, 0);
            this.tableSidePanel.Controls.Add(this.btnPass, 0, 6);
            this.tableSidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSidePanel.Location = new System.Drawing.Point(566, 24);
            this.tableSidePanel.Name = "tableSidePanel";
            this.tableSidePanel.RowCount = 8;
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableSidePanel.Size = new System.Drawing.Size(174, 498);
            this.tableSidePanel.TabIndex = 8;
            // 
            // lblColorRunningHeader
            // 
            this.lblColorRunningHeader.AutoSize = true;
            this.lblColorRunningHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorRunningHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorRunningHeader.ForeColor = System.Drawing.Color.White;
            this.lblColorRunningHeader.Location = new System.Drawing.Point(3, 107);
            this.lblColorRunningHeader.Name = "lblColorRunningHeader";
            this.lblColorRunningHeader.Size = new System.Drawing.Size(81, 28);
            this.lblColorRunningHeader.TabIndex = 9;
            this.lblColorRunningHeader.Text = "Color";
            this.lblColorRunningHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColorRunning
            // 
            this.lblColorRunning.AutoSize = true;
            this.lblColorRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorRunning.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorRunning.ForeColor = System.Drawing.Color.White;
            this.lblColorRunning.Location = new System.Drawing.Point(90, 107);
            this.lblColorRunning.Name = "lblColorRunning";
            this.lblColorRunning.Size = new System.Drawing.Size(81, 28);
            this.lblColorRunning.TabIndex = 8;
            this.lblColorRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpponentScore
            // 
            this.lblOpponentScore.AutoSize = true;
            this.lblOpponentScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOpponentScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOpponentScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentScore.ForeColor = System.Drawing.Color.White;
            this.lblOpponentScore.Location = new System.Drawing.Point(90, 49);
            this.lblOpponentScore.Name = "lblOpponentScore";
            this.lblOpponentScore.Size = new System.Drawing.Size(81, 33);
            this.lblOpponentScore.TabIndex = 5;
            this.lblOpponentScore.Text = "0";
            this.lblOpponentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPlayerScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.ForeColor = System.Drawing.Color.White;
            this.lblPlayerScore.Location = new System.Drawing.Point(3, 49);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(81, 33);
            this.lblPlayerScore.TabIndex = 4;
            this.lblPlayerScore.Text = "0";
            this.lblPlayerScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpponentHeader
            // 
            this.lblOpponentHeader.AutoSize = true;
            this.lblOpponentHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOpponentHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentHeader.ForeColor = System.Drawing.Color.White;
            this.lblOpponentHeader.Location = new System.Drawing.Point(90, 23);
            this.lblOpponentHeader.Name = "lblOpponentHeader";
            this.lblOpponentHeader.Size = new System.Drawing.Size(81, 26);
            this.lblOpponentHeader.TabIndex = 3;
            this.lblOpponentHeader.Text = "Opponent";
            this.lblOpponentHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScoreHeader
            // 
            this.lblPlayerScoreHeader.AutoSize = true;
            this.lblPlayerScoreHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerScoreHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScoreHeader.ForeColor = System.Drawing.Color.White;
            this.lblPlayerScoreHeader.Location = new System.Drawing.Point(3, 23);
            this.lblPlayerScoreHeader.Name = "lblPlayerScoreHeader";
            this.lblPlayerScoreHeader.Size = new System.Drawing.Size(81, 26);
            this.lblPlayerScoreHeader.TabIndex = 2;
            this.lblPlayerScoreHeader.Text = "Player";
            this.lblPlayerScoreHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.tableSidePanel.SetColumnSpan(this.lblScore, 2);
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(3, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(168, 23);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score total";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPass
            // 
            this.btnPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPass.Enabled = false;
            this.btnPass.Location = new System.Drawing.Point(3, 391);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(81, 31);
            this.btnPass.TabIndex = 10;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // frmUno
            // 
            this.AcceptButton = this.btnPass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(743, 525);
            this.Controls.Add(this.outerTableLayout);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUno";
            this.Text = "Uno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmUno_Resize);
            this.Load += new System.EventHandler(this.frmUno_Load);
            this.outerTableLayout.ResumeLayout(false);
            this.outerTableLayout.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableSidePanel.ResumeLayout(false);
            this.tableSidePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        public TableLayoutPanel tableLayoutPanel;
        public TableLayoutPanel outerTableLayout;
        private TableLayoutPanel tableSidePanel;
        private Label lblScore;
        private Label lblPlayerScoreHeader;
        private Label lblOpponentHeader;
        private Label lblColorRunningHeader;
        public Button btnPass;
        public Label lblOpponentScore;
        public Label lblPlayerScore;
        public Label lblColorRunning;


    }
}


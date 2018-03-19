namespace PDF_Downloader
{
    partial class PDFDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFDownloader));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importUrlsFromTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importUrlsFromXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSiteFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSiteQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRssToXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanelInnerTop = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.labelLogs = new System.Windows.Forms.Label();
            this.labelProgressandTools = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelTools = new System.Windows.Forms.TableLayoutPanel();
            this.btnPDFSave = new System.Windows.Forms.Button();
            this.tableLayoutPanelToolsLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLinksFound = new System.Windows.Forms.Label();
            this.labelLinksCrawled = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.tableLayoutPanelToolsRight = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelPDFFound = new System.Windows.Forms.Label();
            this.labelPDFDownload = new System.Windows.Forms.Label();
            this.labelRSSFound = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.btnExportRss = new System.Windows.Forms.Button();
            this.tableLayoutPanelToolsCurrentSite = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCurrentSite = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCurrentLink = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelInnerTop.SuspendLayout();
            this.tableLayoutPanelCenter.SuspendLayout();
            this.tableLayoutPanelTools.SuspendLayout();
            this.tableLayoutPanelToolsLeft.SuspendLayout();
            this.tableLayoutPanelToolsRight.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelToolsCurrentSite.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuProgram";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importUrlsFromTxtToolStripMenuItem,
            this.importUrlsFromXlsxToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importUrlsFromTxtToolStripMenuItem
            // 
            this.importUrlsFromTxtToolStripMenuItem.Name = "importUrlsFromTxtToolStripMenuItem";
            this.importUrlsFromTxtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.importUrlsFromTxtToolStripMenuItem.Text = "Import From Text";
            this.importUrlsFromTxtToolStripMenuItem.Click += new System.EventHandler(this.importUrlsFromTxtToolStripMenuItem_Click_1);
            // 
            // importUrlsFromXlsxToolStripMenuItem
            // 
            this.importUrlsFromXlsxToolStripMenuItem.Name = "importUrlsFromXlsxToolStripMenuItem";
            this.importUrlsFromXlsxToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.importUrlsFromXlsxToolStripMenuItem.Text = "Import From Excel";
            this.importUrlsFromXlsxToolStripMenuItem.Click += new System.EventHandler(this.importUrlsFromXlsxToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSiteFromDatabaseToolStripMenuItem,
            this.clearSiteQueueToolStripMenuItem,
            this.clearDatabaseToolStripMenuItem,
            this.clearLogToolStripMenuItem,
            this.exportRssToXlsxToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.editToolStripMenuItem.Text = "Tools";
            // 
            // loadSiteFromDatabaseToolStripMenuItem
            // 
            this.loadSiteFromDatabaseToolStripMenuItem.Name = "loadSiteFromDatabaseToolStripMenuItem";
            this.loadSiteFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.loadSiteFromDatabaseToolStripMenuItem.Text = "Load From Database";
            this.loadSiteFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadSiteFromDatabaseToolStripMenuItem_Click);
            // 
            // clearSiteQueueToolStripMenuItem
            // 
            this.clearSiteQueueToolStripMenuItem.Name = "clearSiteQueueToolStripMenuItem";
            this.clearSiteQueueToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearSiteQueueToolStripMenuItem.Text = "Clear Site Queue";
            this.clearSiteQueueToolStripMenuItem.Click += new System.EventHandler(this.clearSiteQueueToolStripMenuItem_Click);
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearDatabaseToolStripMenuItem.Text = "Clear Database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // exportRssToXlsxToolStripMenuItem
            // 
            this.exportRssToXlsxToolStripMenuItem.Name = "exportRssToXlsxToolStripMenuItem";
            this.exportRssToXlsxToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportRssToXlsxToolStripMenuItem.Text = "Export RSS";
            this.exportRssToXlsxToolStripMenuItem.Click += new System.EventHandler(this.exportRssToXlsxToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Cursor = System.Windows.Forms.Cursors.No;
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelCopyright.Location = new System.Drawing.Point(3, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(220, 23);
            this.labelCopyright.TabIndex = 0;
            this.labelCopyright.Text = "PDF Downloader. All rights reserved";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanelBottom.ColumnCount = 2;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelBottom.Controls.Add(this.labelCopyright, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.labelMessage, 1, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 421);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(756, 23);
            this.tableLayoutPanelBottom.TabIndex = 2;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Location = new System.Drawing.Point(229, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(524, 23);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTop.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.btnStop, 2, 0);
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelInnerTop, 1, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(756, 54);
            this.tableLayoutPanelTop.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.SpringGreen;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(183, 51);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(570, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(183, 51);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tableLayoutPanelInnerTop
            // 
            this.tableLayoutPanelInnerTop.ColumnCount = 1;
            this.tableLayoutPanelInnerTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInnerTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelInnerTop.Controls.Add(this.textBoxUrl, 0, 1);
            this.tableLayoutPanelInnerTop.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelInnerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInnerTop.Location = new System.Drawing.Point(192, 3);
            this.tableLayoutPanelInnerTop.Name = "tableLayoutPanelInnerTop";
            this.tableLayoutPanelInnerTop.RowCount = 2;
            this.tableLayoutPanelInnerTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInnerTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInnerTop.Size = new System.Drawing.Size(372, 51);
            this.tableLayoutPanelInnerTop.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.BackColor = System.Drawing.Color.Azure;
            this.textBoxUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUrl.Location = new System.Drawing.Point(3, 28);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(366, 20);
            this.textBoxUrl.TabIndex = 0;
            this.textBoxUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUrl.TextChanged += new System.EventHandler(this.textBoxUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Base URL Here";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelCenter
            // 
            this.tableLayoutPanelCenter.ColumnCount = 2;
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelCenter.Controls.Add(this.labelLogs, 0, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.labelProgressandTools, 1, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.listBoxLog, 0, 2);
            this.tableLayoutPanelCenter.Controls.Add(this.tableLayoutPanelTools, 1, 2);
            this.tableLayoutPanelCenter.Controls.Add(this.tableLayoutPanelToolsCurrentSite, 1, 1);
            this.tableLayoutPanelCenter.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCenter.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tableLayoutPanelCenter.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanelCenter.Name = "tableLayoutPanelCenter";
            this.tableLayoutPanelCenter.RowCount = 3;
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelCenter.Size = new System.Drawing.Size(756, 343);
            this.tableLayoutPanelCenter.TabIndex = 4;
            // 
            // labelLogs
            // 
            this.labelLogs.AutoSize = true;
            this.labelLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLogs.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelLogs.Location = new System.Drawing.Point(3, 0);
            this.labelLogs.Name = "labelLogs";
            this.labelLogs.Size = new System.Drawing.Size(296, 34);
            this.labelLogs.TabIndex = 0;
            this.labelLogs.Text = "Logs";
            this.labelLogs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelProgressandTools
            // 
            this.labelProgressandTools.AutoSize = true;
            this.labelProgressandTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgressandTools.Location = new System.Drawing.Point(305, 0);
            this.labelProgressandTools.Name = "labelProgressandTools";
            this.labelProgressandTools.Size = new System.Drawing.Size(448, 34);
            this.labelProgressandTools.TabIndex = 1;
            this.labelProgressandTools.Text = "Progress and Tools";
            this.labelProgressandTools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 71);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(296, 269);
            this.listBoxLog.TabIndex = 2;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            // 
            // tableLayoutPanelTools
            // 
            this.tableLayoutPanelTools.ColumnCount = 2;
            this.tableLayoutPanelTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTools.Controls.Add(this.btnPDFSave, 1, 1);
            this.tableLayoutPanelTools.Controls.Add(this.tableLayoutPanelToolsLeft, 0, 0);
            this.tableLayoutPanelTools.Controls.Add(this.tableLayoutPanelToolsRight, 1, 0);
            this.tableLayoutPanelTools.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanelTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTools.Location = new System.Drawing.Point(305, 71);
            this.tableLayoutPanelTools.Name = "tableLayoutPanelTools";
            this.tableLayoutPanelTools.RowCount = 2;
            this.tableLayoutPanelTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanelTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelTools.Size = new System.Drawing.Size(448, 269);
            this.tableLayoutPanelTools.TabIndex = 3;
            // 
            // btnPDFSave
            // 
            this.btnPDFSave.AutoSize = true;
            this.btnPDFSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPDFSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPDFSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPDFSave.Location = new System.Drawing.Point(227, 231);
            this.btnPDFSave.Name = "btnPDFSave";
            this.btnPDFSave.Size = new System.Drawing.Size(218, 35);
            this.btnPDFSave.TabIndex = 1;
            this.btnPDFSave.Text = "PDF Save Path";
            this.btnPDFSave.UseVisualStyleBackColor = false;
            this.btnPDFSave.Click += new System.EventHandler(this.btnPDFSave_Click);
            // 
            // tableLayoutPanelToolsLeft
            // 
            this.tableLayoutPanelToolsLeft.ColumnCount = 2;
            this.tableLayoutPanelToolsLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelToolsLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelToolsLeft.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelToolsLeft.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelToolsLeft.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanelToolsLeft.Controls.Add(this.labelLinksFound, 1, 0);
            this.tableLayoutPanelToolsLeft.Controls.Add(this.labelLinksCrawled, 1, 1);
            this.tableLayoutPanelToolsLeft.Controls.Add(this.labelErrors, 1, 2);
            this.tableLayoutPanelToolsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelToolsLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelToolsLeft.Name = "tableLayoutPanelToolsLeft";
            this.tableLayoutPanelToolsLeft.RowCount = 3;
            this.tableLayoutPanelToolsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelToolsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelToolsLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelToolsLeft.Size = new System.Drawing.Size(218, 222);
            this.tableLayoutPanelToolsLeft.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 73);
            this.label2.TabIndex = 0;
            this.label2.Text = "Links Found:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 73);
            this.label3.TabIndex = 1;
            this.label3.Text = "Links Crawled:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 76);
            this.label4.TabIndex = 2;
            this.label4.Text = "Errors:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLinksFound
            // 
            this.labelLinksFound.AutoSize = true;
            this.labelLinksFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLinksFound.ForeColor = System.Drawing.Color.Green;
            this.labelLinksFound.Location = new System.Drawing.Point(133, 0);
            this.labelLinksFound.Name = "labelLinksFound";
            this.labelLinksFound.Size = new System.Drawing.Size(82, 73);
            this.labelLinksFound.TabIndex = 3;
            this.labelLinksFound.Text = "-";
            this.labelLinksFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLinksCrawled
            // 
            this.labelLinksCrawled.AutoSize = true;
            this.labelLinksCrawled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLinksCrawled.ForeColor = System.Drawing.Color.Blue;
            this.labelLinksCrawled.Location = new System.Drawing.Point(133, 73);
            this.labelLinksCrawled.Name = "labelLinksCrawled";
            this.labelLinksCrawled.Size = new System.Drawing.Size(82, 73);
            this.labelLinksCrawled.TabIndex = 4;
            this.labelLinksCrawled.Text = "-";
            this.labelLinksCrawled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrors.ForeColor = System.Drawing.Color.Red;
            this.labelErrors.Location = new System.Drawing.Point(133, 146);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(82, 76);
            this.labelErrors.TabIndex = 5;
            this.labelErrors.Text = "-";
            this.labelErrors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelToolsRight
            // 
            this.tableLayoutPanelToolsRight.ColumnCount = 2;
            this.tableLayoutPanelToolsRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelToolsRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelToolsRight.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanelToolsRight.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanelToolsRight.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanelToolsRight.Controls.Add(this.labelPDFFound, 1, 0);
            this.tableLayoutPanelToolsRight.Controls.Add(this.labelPDFDownload, 1, 1);
            this.tableLayoutPanelToolsRight.Controls.Add(this.labelRSSFound, 1, 2);
            this.tableLayoutPanelToolsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelToolsRight.Location = new System.Drawing.Point(227, 3);
            this.tableLayoutPanelToolsRight.Name = "tableLayoutPanelToolsRight";
            this.tableLayoutPanelToolsRight.RowCount = 3;
            this.tableLayoutPanelToolsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelToolsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelToolsRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelToolsRight.Size = new System.Drawing.Size(218, 222);
            this.tableLayoutPanelToolsRight.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 73);
            this.label8.TabIndex = 0;
            this.label8.Text = "PDF Found:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(3, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 73);
            this.label9.TabIndex = 1;
            this.label9.Text = "PDF Download:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(3, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 76);
            this.label10.TabIndex = 2;
            this.label10.Text = "RSS Found:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPDFFound
            // 
            this.labelPDFFound.AutoSize = true;
            this.labelPDFFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPDFFound.ForeColor = System.Drawing.Color.Green;
            this.labelPDFFound.Location = new System.Drawing.Point(112, 0);
            this.labelPDFFound.Name = "labelPDFFound";
            this.labelPDFFound.Size = new System.Drawing.Size(103, 73);
            this.labelPDFFound.TabIndex = 3;
            this.labelPDFFound.Text = "-";
            this.labelPDFFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPDFDownload
            // 
            this.labelPDFDownload.AutoSize = true;
            this.labelPDFDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPDFDownload.ForeColor = System.Drawing.Color.Blue;
            this.labelPDFDownload.Location = new System.Drawing.Point(112, 73);
            this.labelPDFDownload.Name = "labelPDFDownload";
            this.labelPDFDownload.Size = new System.Drawing.Size(103, 73);
            this.labelPDFDownload.TabIndex = 4;
            this.labelPDFDownload.Text = "-";
            this.labelPDFDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRSSFound
            // 
            this.labelRSSFound.AutoSize = true;
            this.labelRSSFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRSSFound.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelRSSFound.Location = new System.Drawing.Point(112, 146);
            this.labelRSSFound.Name = "labelRSSFound";
            this.labelRSSFound.Size = new System.Drawing.Size(103, 76);
            this.labelRSSFound.TabIndex = 5;
            this.labelRSSFound.Text = "-";
            this.labelRSSFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnExportLog, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportRss, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 231);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(218, 35);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnExportLog
            // 
            this.btnExportLog.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnExportLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLog.ForeColor = System.Drawing.Color.Black;
            this.btnExportLog.Location = new System.Drawing.Point(112, 3);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(103, 31);
            this.btnExportLog.TabIndex = 3;
            this.btnExportLog.Text = "Export Logs";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);
            // 
            // btnExportRss
            // 
            this.btnExportRss.BackColor = System.Drawing.Color.Yellow;
            this.btnExportRss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportRss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportRss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportRss.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExportRss.Location = new System.Drawing.Point(3, 3);
            this.btnExportRss.Name = "btnExportRss";
            this.btnExportRss.Size = new System.Drawing.Size(103, 31);
            this.btnExportRss.TabIndex = 1;
            this.btnExportRss.Text = "Export RSS";
            this.btnExportRss.UseVisualStyleBackColor = false;
            this.btnExportRss.Click += new System.EventHandler(this.btnExportRss_Click);
            // 
            // tableLayoutPanelToolsCurrentSite
            // 
            this.tableLayoutPanelToolsCurrentSite.ColumnCount = 2;
            this.tableLayoutPanelToolsCurrentSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelToolsCurrentSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelToolsCurrentSite.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanelToolsCurrentSite.Controls.Add(this.labelCurrentSite, 1, 0);
            this.tableLayoutPanelToolsCurrentSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelToolsCurrentSite.Location = new System.Drawing.Point(305, 37);
            this.tableLayoutPanelToolsCurrentSite.Name = "tableLayoutPanelToolsCurrentSite";
            this.tableLayoutPanelToolsCurrentSite.RowCount = 1;
            this.tableLayoutPanelToolsCurrentSite.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelToolsCurrentSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelToolsCurrentSite.Size = new System.Drawing.Size(448, 28);
            this.tableLayoutPanelToolsCurrentSite.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current Site:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentSite
            // 
            this.labelCurrentSite.AutoSize = true;
            this.labelCurrentSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentSite.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentSite.Location = new System.Drawing.Point(137, 0);
            this.labelCurrentSite.Name = "labelCurrentSite";
            this.labelCurrentSite.Size = new System.Drawing.Size(308, 28);
            this.labelCurrentSite.TabIndex = 1;
            this.labelCurrentSite.Text = "-";
            this.labelCurrentSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCurrentLink, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 28);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Current Link:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentLink
            // 
            this.labelCurrentLink.AutoSize = true;
            this.labelCurrentLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentLink.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentLink.Location = new System.Drawing.Point(91, 0);
            this.labelCurrentLink.Name = "labelCurrentLink";
            this.labelCurrentLink.Size = new System.Drawing.Size(202, 28);
            this.labelCurrentLink.TabIndex = 1;
            this.labelCurrentLink.Text = "-";
            this.labelCurrentLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCurrentLink.Click += new System.EventHandler(this.labelCurrentLink_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // PDFDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 444);
            this.Controls.Add(this.tableLayoutPanelCenter);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.Controls.Add(this.tableLayoutPanelBottom);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(770, 480);
            this.Name = "PDFDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Downloader 1.0.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelInnerTop.ResumeLayout(false);
            this.tableLayoutPanelInnerTop.PerformLayout();
            this.tableLayoutPanelCenter.ResumeLayout(false);
            this.tableLayoutPanelCenter.PerformLayout();
            this.tableLayoutPanelTools.ResumeLayout(false);
            this.tableLayoutPanelTools.PerformLayout();
            this.tableLayoutPanelToolsLeft.ResumeLayout(false);
            this.tableLayoutPanelToolsLeft.PerformLayout();
            this.tableLayoutPanelToolsRight.ResumeLayout(false);
            this.tableLayoutPanelToolsRight.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanelToolsCurrentSite.ResumeLayout(false);
            this.tableLayoutPanelToolsCurrentSite.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInnerTop;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCenter;
        private System.Windows.Forms.Label labelLogs;
        private System.Windows.Forms.Label labelProgressandTools;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTools;
        private System.Windows.Forms.Button btnPDFSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelToolsLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelToolsRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLinksFound;
        private System.Windows.Forms.Label labelLinksCrawled;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelPDFFound;
        private System.Windows.Forms.Label labelPDFDownload;
        private System.Windows.Forms.Label labelRSSFound;
        private System.Windows.Forms.ToolStripMenuItem exportRssToXlsxToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelToolsCurrentSite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCurrentSite;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCurrentLink;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnExportRss;
        private System.Windows.Forms.Button btnExportLog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem importUrlsFromTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importUrlsFromXlsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSiteFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSiteQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
    }
}


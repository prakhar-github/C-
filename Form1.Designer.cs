namespace WindowsFormsApp1
{
    partial class Form1
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
            this.QueryBox = new System.Windows.Forms.TextBox();
            this.QueryLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DatafileLabel = new System.Windows.Forms.Label();
            this.DataFileButton = new System.Windows.Forms.Button();
            this.openDataFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.IndexFolderSelectButton = new System.Windows.Forms.Button();
            this.DataFileTextBox = new System.Windows.Forms.TextBox();
            this.IndexFolderTextBox = new System.Windows.Forms.TextBox();
            this.IndexFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CreateIndexButton = new System.Windows.Forms.Button();
            this.IndexingCompleteLabel = new System.Windows.Forms.Label();
            this.LoadIndexButton = new System.Windows.Forms.Button();
            this.UniNameLabel = new System.Windows.Forms.Label();
            this.resultsTable = new System.Windows.Forms.DataGridView();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassageText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueryTextLabel = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.SearchTimeLabel = new System.Windows.Forms.Label();
            this.queryExpansionCheckBox = new System.Windows.Forms.CheckBox();
            this.multiTermCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // QueryBox
            // 
            this.QueryBox.Location = new System.Drawing.Point(30, 79);
            this.QueryBox.Name = "QueryBox";
            this.QueryBox.Size = new System.Drawing.Size(250, 20);
            this.QueryBox.TabIndex = 0;
            this.QueryBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryBox_KeyDown);
            // 
            // QueryLabel
            // 
            this.QueryLabel.AutoSize = true;
            this.QueryLabel.Location = new System.Drawing.Point(27, 63);
            this.QueryLabel.Name = "QueryLabel";
            this.QueryLabel.Size = new System.Drawing.Size(35, 13);
            this.QueryLabel.TabIndex = 1;
            this.QueryLabel.Text = "Query";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(292, 76);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DatafileLabel
            // 
            this.DatafileLabel.AutoSize = true;
            this.DatafileLabel.Location = new System.Drawing.Point(510, 86);
            this.DatafileLabel.Name = "DatafileLabel";
            this.DatafileLabel.Size = new System.Drawing.Size(93, 13);
            this.DatafileLabel.TabIndex = 4;
            this.DatafileLabel.Text = "Data File Location";
            // 
            // DataFileButton
            // 
            this.DataFileButton.Location = new System.Drawing.Point(683, 97);
            this.DataFileButton.Name = "DataFileButton";
            this.DataFileButton.Size = new System.Drawing.Size(86, 23);
            this.DataFileButton.TabIndex = 7;
            this.DataFileButton.Text = "Select File";
            this.DataFileButton.UseVisualStyleBackColor = true;
            this.DataFileButton.Click += new System.EventHandler(this.DataFileButton_Click);
            // 
            // openDataFileDialog
            // 
            this.openDataFileDialog.FileName = "openDataFileDialog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Index Folder Location";
            // 
            // IndexFolderSelectButton
            // 
            this.IndexFolderSelectButton.Location = new System.Drawing.Point(683, 165);
            this.IndexFolderSelectButton.Name = "IndexFolderSelectButton";
            this.IndexFolderSelectButton.Size = new System.Drawing.Size(86, 23);
            this.IndexFolderSelectButton.TabIndex = 10;
            this.IndexFolderSelectButton.Text = "Select Folder";
            this.IndexFolderSelectButton.UseVisualStyleBackColor = true;
            this.IndexFolderSelectButton.Click += new System.EventHandler(this.IndexFolderSelectButton_Click);
            // 
            // DataFileTextBox
            // 
            this.DataFileTextBox.Location = new System.Drawing.Point(516, 103);
            this.DataFileTextBox.Name = "DataFileTextBox";
            this.DataFileTextBox.ReadOnly = true;
            this.DataFileTextBox.Size = new System.Drawing.Size(147, 20);
            this.DataFileTextBox.TabIndex = 11;
            // 
            // IndexFolderTextBox
            // 
            this.IndexFolderTextBox.Location = new System.Drawing.Point(516, 171);
            this.IndexFolderTextBox.Name = "IndexFolderTextBox";
            this.IndexFolderTextBox.ReadOnly = true;
            this.IndexFolderTextBox.Size = new System.Drawing.Size(147, 20);
            this.IndexFolderTextBox.TabIndex = 12;
            // 
            // CreateIndexButton
            // 
            this.CreateIndexButton.Location = new System.Drawing.Point(566, 218);
            this.CreateIndexButton.Name = "CreateIndexButton";
            this.CreateIndexButton.Size = new System.Drawing.Size(128, 34);
            this.CreateIndexButton.TabIndex = 13;
            this.CreateIndexButton.Text = "Create Lucene Index";
            this.CreateIndexButton.UseVisualStyleBackColor = true;
            this.CreateIndexButton.Click += new System.EventHandler(this.CreateIndexButton_Click);
            // 
            // IndexingCompleteLabel
            // 
            this.IndexingCompleteLabel.AutoSize = true;
            this.IndexingCompleteLabel.Location = new System.Drawing.Point(513, 265);
            this.IndexingCompleteLabel.Name = "IndexingCompleteLabel";
            this.IndexingCompleteLabel.Size = new System.Drawing.Size(0, 13);
            this.IndexingCompleteLabel.TabIndex = 14;
            // 
            // LoadIndexButton
            // 
            this.LoadIndexButton.Location = new System.Drawing.Point(566, 292);
            this.LoadIndexButton.Name = "LoadIndexButton";
            this.LoadIndexButton.Size = new System.Drawing.Size(128, 35);
            this.LoadIndexButton.TabIndex = 15;
            this.LoadIndexButton.Text = "Load Lucene Index";
            this.LoadIndexButton.UseVisualStyleBackColor = true;
            this.LoadIndexButton.Click += new System.EventHandler(this.LoadIndexButton_Click);
            // 
            // UniNameLabel
            // 
            this.UniNameLabel.AutoSize = true;
            this.UniNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniNameLabel.Location = new System.Drawing.Point(24, 23);
            this.UniNameLabel.Name = "UniNameLabel";
            this.UniNameLabel.Size = new System.Drawing.Size(473, 31);
            this.UniNameLabel.TabIndex = 16;
            this.UniNameLabel.Text = "Kingsland University of Technology";
            // 
            // resultsTable
            // 
            this.resultsTable.AllowUserToAddRows = false;
            this.resultsTable.AllowUserToDeleteRows = false;
            this.resultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.PassageID,
            this.PassageText,
            this.url});
            this.resultsTable.Location = new System.Drawing.Point(30, 154);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.ReadOnly = true;
            this.resultsTable.Size = new System.Drawing.Size(460, 387);
            this.resultsTable.TabIndex = 17;
            this.resultsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultsTableCellClick);
            this.resultsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Rank
            // 
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            // 
            // PassageID
            // 
            this.PassageID.HeaderText = "PassageID";
            this.PassageID.Name = "PassageID";
            this.PassageID.ReadOnly = true;
            // 
            // PassageText
            // 
            this.PassageText.HeaderText = "PassageText";
            this.PassageText.Name = "PassageText";
            this.PassageText.ReadOnly = true;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            // 
            // QueryTextLabel
            // 
            this.QueryTextLabel.AutoSize = true;
            this.QueryTextLabel.Location = new System.Drawing.Point(27, 106);
            this.QueryTextLabel.Name = "QueryTextLabel";
            this.QueryTextLabel.Size = new System.Drawing.Size(59, 13);
            this.QueryTextLabel.TabIndex = 18;
            this.QueryTextLabel.Text = "Query Text";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(30, 123);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.ReadOnly = true;
            this.queryTextBox.Size = new System.Drawing.Size(250, 20);
            this.queryTextBox.TabIndex = 19;
            this.queryTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.queryTextBox_Clicked);
            // 
            // SearchTimeLabel
            // 
            this.SearchTimeLabel.AutoSize = true;
            this.SearchTimeLabel.Location = new System.Drawing.Point(118, 106);
            this.SearchTimeLabel.Name = "SearchTimeLabel";
            this.SearchTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.SearchTimeLabel.TabIndex = 20;
            // 
            // queryExpansionCheckBox
            // 
            this.queryExpansionCheckBox.AutoSize = true;
            this.queryExpansionCheckBox.Location = new System.Drawing.Point(292, 126);
            this.queryExpansionCheckBox.Name = "queryExpansionCheckBox";
            this.queryExpansionCheckBox.Size = new System.Drawing.Size(106, 17);
            this.queryExpansionCheckBox.TabIndex = 21;
            this.queryExpansionCheckBox.Text = "Query Expansion";
            this.queryExpansionCheckBox.UseVisualStyleBackColor = true;
            this.queryExpansionCheckBox.CheckedChanged += new System.EventHandler(this.queryExpansionCheckBox_CheckedChanged);
            // 
            // multiTermCheckBox
            // 
            this.multiTermCheckBox.AutoSize = true;
            this.multiTermCheckBox.Location = new System.Drawing.Point(404, 126);
            this.multiTermCheckBox.Name = "multiTermCheckBox";
            this.multiTermCheckBox.Size = new System.Drawing.Size(86, 17);
            this.multiTermCheckBox.TabIndex = 22;
            this.multiTermCheckBox.Text = "Exact Match";
            this.multiTermCheckBox.UseVisualStyleBackColor = true;
            this.multiTermCheckBox.CheckedChanged += new System.EventHandler(this.multiTermCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 543);
            this.Controls.Add(this.multiTermCheckBox);
            this.Controls.Add(this.queryExpansionCheckBox);
            this.Controls.Add(this.SearchTimeLabel);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.QueryTextLabel);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.UniNameLabel);
            this.Controls.Add(this.LoadIndexButton);
            this.Controls.Add(this.IndexingCompleteLabel);
            this.Controls.Add(this.CreateIndexButton);
            this.Controls.Add(this.IndexFolderTextBox);
            this.Controls.Add(this.DataFileTextBox);
            this.Controls.Add(this.IndexFolderSelectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataFileButton);
            this.Controls.Add(this.DatafileLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.QueryLabel);
            this.Controls.Add(this.QueryBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QueryBox;
        private System.Windows.Forms.Label QueryLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label DatafileLabel;
        private System.Windows.Forms.Button DataFileButton;
        private System.Windows.Forms.OpenFileDialog openDataFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IndexFolderSelectButton;
        private System.Windows.Forms.TextBox DataFileTextBox;
        private System.Windows.Forms.TextBox IndexFolderTextBox;
        private System.Windows.Forms.FolderBrowserDialog IndexFolderBrowserDialog;
        private System.Windows.Forms.Button CreateIndexButton;
        private System.Windows.Forms.Label IndexingCompleteLabel;
        private System.Windows.Forms.Button LoadIndexButton;
        private System.Windows.Forms.Label UniNameLabel;
        private System.Windows.Forms.DataGridView resultsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassageText;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.Label QueryTextLabel;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Label SearchTimeLabel;
        private System.Windows.Forms.CheckBox queryExpansionCheckBox;
        private System.Windows.Forms.CheckBox multiTermCheckBox;
    }
}


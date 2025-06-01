namespace CampoMinato2
{
    partial class FCarica
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
            fileSystemWatcher1 = new FileSystemWatcher();
            dgv_files = new DataGridView();
            C1 = new DataGridViewTextBoxColumn();
            C2 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_files).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // dgv_files
            // 
            dgv_files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_files.Columns.AddRange(new DataGridViewColumn[] { C1, C2 });
            dgv_files.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv_files.Location = new Point(10, 57);
            dgv_files.Name = "dgv_files";
            dgv_files.RowHeadersVisible = false;
            dgv_files.RowTemplate.Height = 25;
            dgv_files.ScrollBars = ScrollBars.Vertical;
            dgv_files.Size = new Size(555, 374);
            dgv_files.TabIndex = 1;
            // 
            // C1
            // 
            C1.HeaderText = "Nome File";
            C1.MinimumWidth = 275;
            C1.Name = "C1";
            C1.Width = 275;
            // 
            // C2
            // 
            C2.HeaderText = "Carica";
            C2.MinimumWidth = 275;
            C2.Name = "C2";
            C2.Width = 275;
            // 
            // FCarica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 470);
            Controls.Add(dgv_files);
            Name = "FCarica";
            Text = "FCarica";
            Load += FCarica_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_files).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private DataGridView dgv_files;
        private DataGridViewTextBoxColumn C1;
        private DataGridViewButtonColumn C2;
    }
}
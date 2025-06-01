namespace CampoMinato2
{
    partial class FPartita
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
            dgv_main = new DataGridView();
            btn_salva = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_main).BeginInit();
            SuspendLayout();
            // 
            // dgv_main
            // 
            dgv_main.AllowUserToAddRows = false;
            dgv_main.AllowUserToDeleteRows = false;
            dgv_main.AllowUserToResizeColumns = false;
            dgv_main.AllowUserToResizeRows = false;
            dgv_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_main.ColumnHeadersVisible = false;
            dgv_main.Cursor = Cursors.Hand;
            dgv_main.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv_main.Location = new Point(97, 27);
            dgv_main.MultiSelect = false;
            dgv_main.Name = "dgv_main";
            dgv_main.RowHeadersVisible = false;
            dgv_main.RowHeadersWidth = 51;
            dgv_main.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_main.RowTemplate.Height = 25;
            dgv_main.ScrollBars = ScrollBars.None;
            dgv_main.Size = new Size(656, 562);
            dgv_main.TabIndex = 0;
            dgv_main.CellContentClick += dgv_main_CellClick;
            // 
            // btn_salva
            // 
            btn_salva.Location = new Point(747, 197);
            btn_salva.Name = "btn_salva";
            btn_salva.Size = new Size(123, 75);
            btn_salva.TabIndex = 1;
            btn_salva.Text = "btn_salva";
            btn_salva.UseVisualStyleBackColor = true;
            btn_salva.Click += btn_salva_Click;
            // 
            // FPartita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 595);
            Controls.Add(btn_salva);
            Controls.Add(dgv_main);
            Name = "FPartita";
            Text = "FPartita";
            ((System.ComponentModel.ISupportInitialize)dgv_main).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_main;
        private Button btn_salva;
    }
}
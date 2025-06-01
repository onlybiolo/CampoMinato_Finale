namespace CampoMinato2
{
    partial class FSalva
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
            btn_Salva = new Button();
            tbx_NomeFile = new TextBox();
            lbl_avviso = new Label();
            SuspendLayout();
            // 
            // btn_Salva
            // 
            btn_Salva.BackColor = Color.Transparent;
            btn_Salva.FlatStyle = FlatStyle.Flat;
            btn_Salva.Font = new Font("Sylfaen", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Salva.ForeColor = Color.Transparent;
            btn_Salva.Location = new Point(305, 280);
            btn_Salva.Margin = new Padding(3, 2, 3, 2);
            btn_Salva.Name = "btn_Salva";
            btn_Salva.Size = new Size(40, 39);
            btn_Salva.TabIndex = 1;
            btn_Salva.UseVisualStyleBackColor = false;
            btn_Salva.Click += btn_Salva_Click;
            // 
            // tbx_NomeFile
            // 
            tbx_NomeFile.Font = new Font("Sylfaen", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbx_NomeFile.Location = new Point(94, 283);
            tbx_NomeFile.Margin = new Padding(3, 2, 3, 2);
            tbx_NomeFile.Name = "tbx_NomeFile";
            tbx_NomeFile.Size = new Size(188, 35);
            tbx_NomeFile.TabIndex = 0;
            // 
            // lbl_avviso
            // 
            lbl_avviso.BackColor = Color.Transparent;
            lbl_avviso.Font = new Font("Sylfaen", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_avviso.Location = new Point(103, 215);
            lbl_avviso.Name = "lbl_avviso";
            lbl_avviso.Size = new Size(242, 32);
            lbl_avviso.TabIndex = 2;
            lbl_avviso.Text = "Usare nomi diversi, altrimenti verranno sovrascritti i file\r\n\r\n";
            // 
            // FSalva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.salva1;
            ClientSize = new Size(424, 401);
            Controls.Add(lbl_avviso);
            Controls.Add(tbx_NomeFile);
            Controls.Add(btn_Salva);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FSalva";
            Text = "FSalva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Salva;
        private TextBox tbx_NomeFile;
        private Label lbl_avviso;
    }
}
namespace CampoMinato2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_Impostazioni = new Button();
            btn_esci = new Button();
            btn_gioca = new Button();
            EntrateEsplosive = new PictureBox();
            btn_carica = new Button();
            ((System.ComponentModel.ISupportInitialize)EntrateEsplosive).BeginInit();
            SuspendLayout();
            // 
            // btn_Impostazioni
            // 
            btn_Impostazioni.BackColor = Color.Transparent;
            btn_Impostazioni.Location = new Point(0, 0);
            btn_Impostazioni.Margin = new Padding(3, 2, 3, 2);
            btn_Impostazioni.Name = "btn_Impostazioni";
            btn_Impostazioni.Size = new Size(438, 150);
            btn_Impostazioni.TabIndex = 0;
            btn_Impostazioni.UseVisualStyleBackColor = false;
            btn_Impostazioni.Click += btn_Impostazioni_Click;
            // 
            // btn_esci
            // 
            btn_esci.BackColor = Color.Transparent;
            btn_esci.Location = new Point(512, 310);
            btn_esci.Margin = new Padding(3, 2, 3, 2);
            btn_esci.Name = "btn_esci";
            btn_esci.Size = new Size(438, 150);
            btn_esci.TabIndex = 2;
            btn_esci.UseVisualStyleBackColor = false;
            btn_esci.Click += btn_esci_Click;
            // 
            // btn_gioca
            // 
            btn_gioca.BackColor = Color.Transparent;
            btn_gioca.Location = new Point(137, 224);
            btn_gioca.Margin = new Padding(3, 2, 3, 2);
            btn_gioca.Name = "btn_gioca";
            btn_gioca.Size = new Size(438, 150);
            btn_gioca.TabIndex = 3;
            btn_gioca.UseVisualStyleBackColor = false;
            btn_gioca.Click += btn_gioca_Click;
            // 
            // EntrateEsplosive
            // 
            EntrateEsplosive.BackColor = Color.Transparent;
            EntrateEsplosive.Image = (Image)resources.GetObject("EntrateEsplosive.Image");
            EntrateEsplosive.Location = new Point(388, 19);
            EntrateEsplosive.Margin = new Padding(3, 2, 3, 2);
            EntrateEsplosive.Name = "EntrateEsplosive";
            EntrateEsplosive.Size = new Size(512, 232);
            EntrateEsplosive.SizeMode = PictureBoxSizeMode.StretchImage;
            EntrateEsplosive.TabIndex = 4;
            EntrateEsplosive.TabStop = false;
            // 
            // btn_carica
            // 
            btn_carica.Location = new Point(362, 437);
            btn_carica.Name = "btn_carica";
            btn_carica.Size = new Size(178, 46);
            btn_carica.TabIndex = 5;
            btn_carica.Text = "button1";
            btn_carica.UseVisualStyleBackColor = true;
            btn_carica.Click += btn_carica_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1003, 509);
            Controls.Add(btn_carica);
            Controls.Add(EntrateEsplosive);
            Controls.Add(btn_gioca);
            Controls.Add(btn_esci);
            Controls.Add(btn_Impostazioni);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)EntrateEsplosive).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Impostazioni;
        private Button btn_esci;
        private Button btn_gioca;
        private PictureBox EntrateEsplosive;
        private Button btn_carica;
    }
}

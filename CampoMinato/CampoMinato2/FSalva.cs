using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato2
{
    public partial class FSalva : Form
    {
        int[,] matrix;
        DataGridView dgv;
        public FSalva(int[,] matrix, DataGridView dgv)
        {
            InitializeComponent();
            this.matrix = matrix;
            this.dgv = dgv;
        }

        private void btn_Salva_Click(object sender, EventArgs e)
        {
            string nomeFile = tbx_NomeFile.Text;

            if (string.IsNullOrEmpty(nomeFile))
            {
                MessageBox.Show("Inserire un nome corretto");
            }
            else
            {
                string path = $@"salvataggi/{nomeFile}";
                File.Create(path);
                using (StreamWriter sw = new StreamWriter(path))
                {
                 //   for()
                }
            }

        }
    }
}

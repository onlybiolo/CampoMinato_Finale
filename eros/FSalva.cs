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
        int righe;
        int colonne;
        int ncelle;
        public FSalva(int[,] matrix, int righe, int ncelle)
        {
            InitializeComponent();
            this.matrix = matrix;
            this.righe = righe;
            colonne = righe;
            this.ncelle = ncelle;
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
                string path = $@"salvataggi/{nomeFile}.csv";
                string matrice = $"{ncelle}\n";

                for (int r = 0; r < righe; r++)
                {
                    for (int c = 0; c < colonne; c++)
                    {
                        matrice += matrix[r, c].ToString();

                        if (c < colonne - 1)
                            matrice += ", ";
                    }
                    matrice += "\n";
                }

                File.WriteAllText(path, matrice);
                this.Close();
            }

        }
    }
}

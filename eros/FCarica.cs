using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // AGGIUNGI QUESTA RIGA

namespace CampoMinato2
{
    public partial class FCarica : Form
    {
        FImpostazioni i;
        public FCarica(FImpostazioni i)
        {
            this.i = i;
            InitializeComponent();
        }

        private void FCarica_Load(object sender, EventArgs e)
        {
            dgv_files.CellContentClick += dgv_files_CellContentClick;

            string path = @"salvataggi";

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*");
                for (int i = 0; i < files.Length; i++)
                {
                    dgv_files.Rows.Add();
                    dgv_files.Rows[i].Cells[0].Value = Path.GetFileName(files[i]);
                    dgv_files.Rows[i].Cells[1].Value = "Genera";
                }
            }
            else
            {
                MessageBox.Show("Cartella 'salvataggi' non trovata!");
            }
        }

        private void dgv_files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0) 
            {
                string nomeFile = dgv_files.Rows[e.RowIndex].Cells[0].Value?.ToString();
                LeggiFile(nomeFile);
                
            }
        }

        private void LeggiFile(string nomefile)
        {
            string[] matrice;
            
            using(StreamReader sr = new StreamReader($"salvataggi/{nomefile}"))
            {
                matrice = sr.ReadToEnd().Replace("\r", "").Split('\n');
            }
            CaricaPartita(matrice);
        }

        private void CaricaPartita(string[] matrice)
        {
            double ncelle;
            int nbombe;
            //prendi informazioni generali(bombe e celle)
            string[] riga = matrice[0].Split(",");
            ncelle = double.Parse(riga[0].Trim());


            int[,] matrix = new int[(int)ncelle, (int)ncelle];

            // calcolo i numeri delle celle
            for (int r = 1; r < matrice.Length; r++)
            {
                string[] rig = matrice[r].Split(',');

                for (int c = 0; c < rig.Length; c++)
                {
                    string valore = rig[c].Trim();
                    if (!string.IsNullOrEmpty(valore))
                    {
                        int elemento = int.Parse(valore);
                        matrix[r - 1, c] = elemento;
                    }
                }
            }

            FPartita partitacaricata = new(matrix, ncelle/10, i);

            partitacaricata.Show();
            this.Hide();
        }


    }
}
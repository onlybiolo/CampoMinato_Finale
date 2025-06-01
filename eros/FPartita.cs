using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato2
{
    public partial class FPartita : Form
    {

        int[,] campo;
        bool firstClick = true; // per gestire il primo click
        FImpostazioni impostazioni;
        int numeroCelle;
        int bombe;

        public FPartita(double ncelle, int bombe, FImpostazioni i)
        {
            impostazioni = i;
            InitializeComponent();
            CreaTabellone(ncelle);
            Inizializzazioni();
            generaMine(bombe, ncelle);
            this.bombe = bombe;
        }

        // costruttore per matrice in input(caricapartita)
        public FPartita(int[,] matrice, double ncelle, FImpostazioni i)
        {
            impostazioni = i;
            InitializeComponent();
            campo = matrice;
            CreaTabellone(ncelle); 
            Inizializzazioni();
            this.bombe = bombe;
            // Eventualmente aggiorna la griglia con la matrice già data
            PopolaTabelloneDaMatrice(matrice);
        }



        private void CreaTabellone(double ncelle)
        {
            ncelle *= 10;
            numeroCelle = (int)ncelle;

            dgv_main.CellClick += dgv_main_CellClick;
            dgv_main.CellMouseDown += dgv_main_CellMouseDown;

            dgv_main.RowHeadersVisible = false;
            dgv_main.ColumnHeadersVisible = false;
            dgv_main.ScrollBars = ScrollBars.None;
            dgv_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv_main.ColumnCount = numeroCelle;
            dgv_main.RowCount = numeroCelle;

            int cellWidth = dgv_main.ClientSize.Width / numeroCelle;
            int cellHeight = dgv_main.ClientSize.Height / numeroCelle;

            for (int i = 0; i < numeroCelle; i++)
            {
                dgv_main.Columns[i].Width = cellWidth;
                dgv_main.Rows[i].Height = cellHeight;
            }

            for (int i = 0; i < numeroCelle; i++)
            {
                for (int j = 0; j < numeroCelle; j++)
                {
                    var cell = dgv_main.Rows[i].Cells[j];
                    cell.Value = "";
                    cell.Style.BackColor = Color.LightGray;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    cell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    cell.Style.Padding = new Padding(0);
                }
            }

            dgv_main.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgv_main.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_main.ClearSelection();
        } //FUNZIONE PER CREARE IL TABELLONE



        public void PopolaTabelloneDaMatrice(int[,] matrice)
        {
            for (int i = 0; i < numeroCelle; i++)
            {
                for (int j = 0; j < numeroCelle; j++)
                {
                    if (matrice[i, j] >= 30)
                    {
                        matrice[i, j] -= 30;
                        dgv_main.Rows[i].Cells[j].Value = "F";
                        dgv_main.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                    }
                    // Gestione celle scoperte (valore >= 10, escluse quelle già gestite)
                    else if (matrice[i, j] >= 10)
                    {
                        matrice[i, j] -= 10;
                        ScopriCelle(i, j);
                        if (matrice[i, j] == 0)
                        {
                            dgv_main.Rows[i].Cells[j].Value = "";
                        }
                    }
                }
            }
            campo = matrice;
        }


        private void Inizializzazioni()
        {
            this.FormBorderStyle = FormBorderStyle.None; //Tolgo il bordo della finestra
            this.WindowState = FormWindowState.Maximized; //Metto a schermo intero
            this.BackgroundImage = Image.FromFile("background_main.png"); //Immagine di sfondo
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //metto il campo in centro a sinistra
            int width = this.Width = Screen.PrimaryScreen.Bounds.Width; //Larghezza della finestra
            int height = this.Height = Screen.PrimaryScreen.Bounds.Height; //Altezza della finestra

            dgv_main.Left = (width - dgv_main.Width) / 2; //centro in orizzontale
            dgv_main.Top = ((height - dgv_main.Height) / 2) - 100; //centro in verticale

            dgv_main.ClearSelection();
        }


        private void generaMine(int nMine, double larghezza)
        {
            larghezza *= 10;
            Random rnd = new Random();
            int area = (int)(larghezza * larghezza); // calcolo l'area del campo di gioco


            //le mine sono passate come percentuale del numero di celle
            nMine = (int)((area * nMine) / 100.0); // calcolo il numero di mine in base alla percentuale

            // genero una matrice di interi per gestire il campo di gioco
            campo = new int[(int)larghezza, (int)larghezza];

            // genero le mine
            for (int i = 0; i < nMine; i++)
            {
                int x, y;
                do
                {
                    x = rnd.Next(0, (int)larghezza);
                    y = rnd.Next(0, (int)larghezza);
                } while (campo[x, y] == -1);
                campo[x, y] = -1;
            }

            // calcolo i numeri delle celle
            for (int i = 0; i < larghezza; i++)
            {
                for (int j = 0; j < larghezza; j++)
                {
                    if (campo[i, j] != -1)
                    {
                        int count = 0;
                        // controllo le celle vicine
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                if (x == 0 && y == 0) continue; // salto la cella corrente
                                int newX = i + x;
                                int newY = j + y;
                                if (newX >= 0 && newX < larghezza && newY >= 0 && newY < larghezza && campo[newX, newY] == -1)
                                {
                                    count++;
                                }
                            }
                        }
                        campo[i, j] = count;
                    }
                }
            }
        }

        private void dgv_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //impostazioni.cellaCliccata(); // trigger del suono quando si preme una cella

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // esce se la cella non è valida
            int x = e.RowIndex;
            int y = e.ColumnIndex;

            // se clicco una cella con un numero gia scoperta, scopro le 8 circostanti anche se hanno una bomba, ma non scopro quelle con il flag
            if (campo[x, y] > 0 && dgv_main.Rows[x].Cells[y].Value.ToString() != "")
            {
                ScopriCircostanti(x + 1, y + 1);
                ScopriCircostanti(x + 1, y);
                ScopriCircostanti(x + 1, y - 1);
                ScopriCircostanti(x, y + 1);
                ScopriCircostanti(x, y - 1);
                ScopriCircostanti(x - 1, y + 1);
                ScopriCircostanti(x - 1, y);
                ScopriCircostanti(x - 1, y - 1);
                campo[x, y] = campo[x, y] + 10;
            }

            if (campo[x, y] == -1)
            {
                dgv_main.Rows[x].Cells[y].Value = "B"; // mostra una mina
                dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Red; // cambio colore della cella
                LoseGame();
            }
            if (campo[x, y] >= 0)
            {
                //"scopro" tutte le celle che hanno 0 nelle vicinanze fino to a che non trovo celle con numeri
                if (campo[x, y] == 0)
                {
                    ScopriCelle(x, y);
                }
                else
                {
                    dgv_main.Rows[x].Cells[y].Value = campo[x, y]; // mostra il numero della cella
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.LightBlue; // cambio colore della cella
                }
            }

            

            dgv_main.ClearSelection(); // rimuove la selezione della cella dopo il click
        }

        private void ScopriCircostanti(int x, int y)
        {
            // Controllo se le coordinate sono valide
            if (x < 0 || x >= campo.GetLength(0) || y < 0 || y >= campo.GetLength(1)) return; // esce se la cella non è valida




            if (dgv_main.Rows[x].Cells[y].Value.ToString() != "F")
            { // Controllo prima se la cella è flaggata
                ScopriCelle(x, y);

                // Controllo se la cella scoperta è una mina
                if (campo[x, y] == -1)
                {
                    dgv_main.Rows[x].Cells[y].Value = "B"; // mostra una mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Red; // cambio colore della cella
                    LoseGame(); // funzione per perdere la partita
                }
            }
        }

        private void LoseGame()
        {
            this.BackgroundImage = Image.FromFile("ah.png");
            dgv_main.Hide();
            MessageBox.Show("Hai perso! Hai cliccato su una mina.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit(); // chiude l'applicazione
        }

        private void ScopriCelle(int x, int y)
        {
            if (x < 0 || x >= campo.GetLength(0) || y < 0 || y >= campo.GetLength(1)) return;//controlla se cella valida

            if (campo[x, y] >= 10) return;//controlla se flag

            if (dgv_main.Rows[x].Cells[y].Value != null && dgv_main.Rows[x].Cells[y].Value.ToString() == "F") return;

            int valoreCella = campo[x, y];
            campo[x, y] += 10;

            if (valoreCella == 0)
            {
                dgv_main.Rows[x].Cells[y].Value = ""; 
            }
            else
            {
                dgv_main.Rows[x].Cells[y].Value = valoreCella;
            }

            dgv_main.Rows[x].Cells[y].Style.BackColor = Color.LightBlue;

            if (valoreCella == 0)
            {
                //scopro le celle vicine
                ScopriCelle(x - 1, y - 1);
                ScopriCelle(x - 1, y);
                ScopriCelle(x - 1, y + 1);
                ScopriCelle(x, y - 1);
                ScopriCelle(x, y + 1);
                ScopriCelle(x + 1, y - 1);
                ScopriCelle(x + 1, y);
                ScopriCelle(x + 1, y + 1);
            }
        }

        private void dgv_main_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // esce se la cella non è valida

                //prendo le coordinate della cella
                int x = e.RowIndex;
                int y = e.ColumnIndex;

                //se la cella è flaggata la rimuovo, altrimenti la flaggo come mina

                if (dgv_main.Rows[x].Cells[y].Value == null || dgv_main.Rows[x].Cells[y].Value.ToString() == "")
                {
                    dgv_main.Rows[x].Cells[y].Value = "F"; // segna la cella come mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.Yellow; // cambio colore della cella
                    campo[x, y] += 40;
                }

                else if (dgv_main.Rows[x].Cells[y].Value.ToString() == "F")
                {
                    dgv_main.Rows[x].Cells[y].Value = ""; // rimuove la segnalazione della mina
                    dgv_main.Rows[x].Cells[y].Style.BackColor = Color.LightGray; // ripristina il colore originale della cella
                    campo[x, y] -= 40;
                }
                ControllaFlag();
            }
        }

        private void ControllaFlag()
        {
            int righe = campo.GetLength(0);
            int colonne = campo.GetLength(1);

            int[,] campoMine = new int[righe, colonne];
            int[,] campoFlag = new int[righe, colonne];
            int numeroMine = 0;
            int numeroFlag = 0;

            // 1. Scansiona la matrice per segnare le mine
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if (campo[i, j] == -1)
                    {
                        campoMine[i, j] = 1;
                        numeroMine++;
                    }
                }
            }

            // 2. Scansiona la griglia per segnare le flag
            foreach (DataGridViewRow row in dgv_main.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == "F")
                    {
                        campoFlag[cell.RowIndex, cell.ColumnIndex] = 1;
                        numeroFlag++;
                    }
                }
            }

            // 3. Verifica che il numero di flag sia corretto
            if (numeroFlag != numeroMine)
                return; // numero sbagliato, quindi niente vittoria

            // 4. Verifica che ogni flag sia su una mina
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if (campoFlag[i, j] == 1 && campoMine[i, j] != 1)
                    {
                        return; // flag su una cella che non è mina => no vittoria
                    }
                }
            }

            // 5. Se siamo qui, la vittoria è corretta
            MessageBox.Show("Hai vinto! Hai scoperto tutte le mine.", "Vittoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void btn_salva_Click(object sender, EventArgs e)
        {
            FSalva salva = new FSalva(campo, numeroCelle, numeroCelle);
            salva.Show();
        }
    }

}

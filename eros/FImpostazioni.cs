using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace CampoMinato2
{
    public partial class FImpostazioni : Form
    {/*
        
        private AudioFileReader audio; // lettore audio di NAudio (libreria installata)
        private WaveOutEvent player; // riproduttore dell'audio

        public AudioFileReader suono;
        public WaveOutEvent playerSuono;



        public FImpostazioni()
        {
            InitializeComponent();
            Inizializzazioni(); // funzione per le inizializzazioni
        }

        private void Inizializzazioni()
        {
            //Fullscreen
            this.FormBorderStyle = FormBorderStyle.None; //no bordo
            this.WindowState = FormWindowState.Maximized; //fullscreen
            this.TopMost = true; //finesra in primo piano

            //Centramenti
            int larghezza = this.Width = Screen.PrimaryScreen.Bounds.Width; // larghezza
            int altezza = this.Height = Screen.PrimaryScreen.Bounds.Height; // altezza

            lbl_title.Left = (larghezza - lbl_title.Width) / 2;
            lbl_title.Top = (altezza - lbl_title.Height) / 2 - 400;
            trk_AudioMusica.Left = (larghezza - trk_AudioMusica.Width) / 2;
            trk_AudioMusica.Top = (altezza - trk_AudioMusica.Height) / 2 - 150;
            trk_Sounds.Left = (larghezza - trk_Sounds.Width) / 2;
            trk_Sounds.Top = (altezza - trk_Sounds.Height) / 2 + 50;

            //metto il label in alto a sinistra della trackbar
            lbl_titleMusica.Left = trk_AudioMusica.Left - 150;
            lbl_titleMusica.Top = trk_AudioMusica.Top - 57;
            lbl_titleSuoni.Left = trk_Sounds.Left - 150;
            lbl_titleSuoni.Top = trk_Sounds.Top - 57;

            //pulsanti mute / max vol
            btn_MuteMusic.Left = trk_AudioMusica.Left - btn_MuteMusic.Width - 20;
            btn_MuteMusic.Top = trk_AudioMusica.Top - 20;
            btn_MaxMusic.Left = trk_AudioMusica.Left + trk_AudioMusica.Width + 20;
            btn_MaxMusic.Top = trk_AudioMusica.Top - 20;

            //pulsanti mute / max vol suoni
            btn_MuteSounds.Left = trk_Sounds.Left - btn_MuteSounds.Width - 20;
            btn_MuteSounds.Top = trk_Sounds.Top - 20;
            btn_MaxSounds.Left = trk_Sounds.Left + trk_Sounds.Width + 20;
            btn_MaxSounds.Top = trk_Sounds.Top - 20;

            //pulsante esci
            btn_Esci.Width = 452;
            btn_Esci.Height = 190;
            btn_Esci.Left = (larghezza - btn_Esci.Width) / 2;
            btn_Esci.Top = (altezza - btn_Esci.Height) / 2 + 250;
            btn_Esci.BackgroundImage = Image.FromFile("Esci.png");
            btn_Esci.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Esci.FlatStyle = FlatStyle.Flat;
            btn_Esci.FlatAppearance.BorderSize = 0;
            btn_Esci.FlatAppearance.MouseOverBackColor = Color.Transparent;



            //MUSICA IMPOSTAZIONI
            trk_AudioMusica.Minimum = 0;
            trk_AudioMusica.Maximum = 100;
            trk_AudioMusica.Value = 50;
            trk_AudioMusica.TickFrequency = 10;
            trk_AudioMusica.Scroll += Trk_AudioMusica_Scroll;

            audio = new AudioFileReader("musica.mp3");
            player = new WaveOutEvent();
            player.Init(audio);
            player.Play();

            player.Volume = trk_AudioMusica.Value / 100f; // Imposta il volume iniziale

            //prendo l'immagine di background del pulsante dalla cartella del progetto
            btn_MaxMusic.BackgroundImage = Image.FromFile("maxvol.png");
            btn_MaxMusic.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MuteMusic.BackgroundImage = Image.FromFile("muta.png");
            btn_MuteMusic.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MaxMusic.FlatStyle = FlatStyle.Flat;
            btn_MaxMusic.FlatAppearance.BorderSize = 0;
            btn_MuteMusic.FlatStyle = FlatStyle.Flat;
            btn_MuteMusic.FlatAppearance.BorderSize = 0;

            btn_MaxSounds.BackgroundImage = Image.FromFile("maxvol.png");
            btn_MaxSounds.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MuteSounds.BackgroundImage = Image.FromFile("muta.png");
            btn_MuteSounds.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MaxSounds.FlatStyle = FlatStyle.Flat;
            btn_MaxSounds.FlatAppearance.BorderSize = 0;
            btn_MuteSounds.FlatStyle = FlatStyle.Flat;
            btn_MuteSounds.FlatAppearance.BorderSize = 0;

            //SUONI IMPOSTAZIONI
            trk_Sounds.Minimum = 0;
            trk_Sounds.Maximum = 100;
            trk_Sounds.Value = 50;
            trk_Sounds.TickFrequency = 10;
            trk_Sounds.Scroll += Trk_Sounds_Scroll;

            suono = new AudioFileReader("buttonSounds.mp3");
            player = new WaveOutEvent();
            player.Init(suono);
        }

        private void Trk_Sounds_Scroll(object? sender, EventArgs e)
        {
            if (suono != null)
            {
                suono.Volume = trk_Sounds.Value / 100f;
            }
        }

        private void Trk_AudioMusica_Scroll(object? sender, EventArgs e)
        {
            if (audio != null)
            {
                audio.Volume = trk_AudioMusica.Value / 100f;
            }
        }

        private void FImpostazioni_Load(object sender, EventArgs e)
        {
            trk_AudioMusica_Scroll(sender, e);
            trk_Sounds_Scroll(sender, e);
        }

        private void trk_AudioMusica_Scroll(object sender, EventArgs e)
        {
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX, trk_AudioMusica.Top - lbl_Musica.Height);
        }

        private void trk_Sounds_Scroll(object sender, EventArgs e)
        {
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX, trk_Sounds.Top - lbl_Suoni.Height);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Controlla se l'utente ha richiesto la chiusura (non l'applicazione che termina)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;   // Annulla la chiusura
                this.Hide();       // Nasconde la finestra
            }
        }

        private void btn_MuteMusic_Click(object sender, EventArgs e)
        {
            trk_AudioMusica.Value = 0; // Imposta il volume a 0
            audio.Volume = 0; // Imposta il volume a 0
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX, trk_AudioMusica.Top - lbl_Musica.Height);


        }

        private void btn_MaxMusic_Click(object sender, EventArgs e)
        {
            trk_AudioMusica.Value = 100; // Imposta il volume a 100
            audio.Volume = 1; // Imposta il volume a 100
            lbl_Musica.Text = trk_AudioMusica.Value.ToString();
            float percentuale = (float)(trk_AudioMusica.Value - trk_AudioMusica.Minimum) / (trk_AudioMusica.Maximum - trk_AudioMusica.Minimum);
            int lunghezzaUtilizzabile = trk_AudioMusica.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_AudioMusica.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Musica.Location = new Point(posizioneX, trk_AudioMusica.Top - lbl_Musica.Height);
        }

        private void btn_MuteSounds_Click(object sender, EventArgs e)
        {
            trk_Sounds.Value = 0; // Imposta il volume a 0
            suono.Volume = 0; // Imposta il volume a 0
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX, trk_Sounds.Top - lbl_Suoni.Height);
        }

        private void btn_MaxSounds_Click(object sender, EventArgs e)
        {
            trk_Sounds.Value = 100; // Imposta il volume a 100
            suono.Volume = 1; // Imposta il volume a 100
            lbl_Suoni.Text = trk_Sounds.Value.ToString();
            float percentuale = (float)(trk_Sounds.Value - trk_Sounds.Minimum) / (trk_Sounds.Maximum - trk_Sounds.Minimum);
            int lunghezzaUtilizzabile = trk_Sounds.Width - 16; // 16 ≈ margine del cursore
            int posizioneX = trk_Sounds.Left + (int)(percentuale * lunghezzaUtilizzabile);
            lbl_Suoni.Location = new Point(posizioneX, trk_Sounds.Top - lbl_Suoni.Height);
        }
        
        public void pulsantePremuto()
        {
            // trigger del suono quando si preme un pulsante
            if (playerSuono != null)
            {
                playerSuono.Stop();
                playerSuono.Dispose();
            }
            playerSuono = new WaveOutEvent();
            playerSuono.Init(new AudioFileReader("buttonSounds.mp3"));
            playerSuono.Volume = trk_Sounds.Value / 100f; // volume con trackbar
            playerSuono.Play();
        }
        
        public void cellaCliccata()
        {
            if (playerSuono != null)
            {
                playerSuono.Stop();
                playerSuono.Dispose();
            }

            playerSuono = new WaveOutEvent();
            playerSuono.Init(new AudioFileReader("btnGameplay.mp3"));
            playerSuono.Volume = trk_Sounds.Value / 100f;
            playerSuono.Play();
        }

        private void btn_Esci_Click(object sender, EventArgs e)
        {
            this.Hide(); // Nasconde la finestra delle impostazioni
        }
        */
    }
}

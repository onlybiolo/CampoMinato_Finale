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
    public partial class FGioca : Form
    {
        int valoreScroll;

        public double grandezza { get; private set; }
        public int bombe { get; private set; }

        FImpostazioni impostazioni;
        public FGioca(FImpostazioni i)
        {
            InitializeComponent();
            impostazioni = i;
            tbr_Bombe.Value = 1;
        }

        private void btn_Esci_Click(object sender, EventArgs e)
        {
//            impostazioni.pulsantePremuto();
            this.Close();
        }

        private void btn_Gioca_Click(object sender, EventArgs e)
        {
            //impostazioni.pulsantePremuto();
            int gScelta = tbr_Griglia.Value;
            int bScelta = valoreScroll;

            switch (gScelta)
            {
                case 1:
                    grandezza = 0.5;
                    break;

                case 2:
                    grandezza = 1;
                    break;

                case 3:
                    grandezza = 1.5;
                    break;
            }

            switch (bScelta)
            {
                case 0:
                    bombe = 10;
                    break;
                case 1:
                    bombe = 10;
                    break;
                case 2:
                    bombe = 15;
                    break;
                    case 3:
                    bombe = 25;
                    break;
            }

            var tabella = new FPartita(grandezza, bombe, impostazioni);
            tabella.Show();
            this.Close();
        }

        private void tbr_Bombe_Scroll(object sender, EventArgs e)
        {
            valoreScroll = tbr_Bombe.Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebCene.UI
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

      
        private void noviProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProizvodi proizvod = new frmProizvodi(null);
            proizvod.ShowDialog();

        }

        private void listaProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProizvodiLista listaProizvoda = new frmProizvodiLista();
            listaProizvoda.MdiParent = this;
            listaProizvoda.Show();

        }

        private void noviProdavacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdavci prodavac = new frmProdavci(null);
            prodavac.ShowDialog();
        }

        private void listaProdavacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdavciLista listaProdavaca = new frmProdavciLista();
            listaProdavaca.MdiParent = this;
            listaProdavaca.Show();
        }

        private void noviKrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStartKrol novitKrol = new frmStartKrol();
            novitKrol.ShowDialog();
        }


        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void toolStripGrouped_Click(object sender, EventArgs e)
        {
            frmListaKrolova dosadasnjiKrolovi = new frmListaKrolova();
            dosadasnjiKrolovi.MdiParent = this;
            dosadasnjiKrolovi.Show();
        }

        private void toolStripCrosstab_Click(object sender, EventArgs e)
        {
            // child form

            frmListaKrolovaCrosstab listaKrolovaCrosstab = new frmListaKrolovaCrosstab();
            listaKrolovaCrosstab.MdiParent = this;
            listaKrolovaCrosstab.Show();
        }
    }
}

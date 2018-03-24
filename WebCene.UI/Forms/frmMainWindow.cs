using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using WebCene.UI.Forms.B2B;
using WebCene.UI.Forms.Kroler;


namespace WebCene.UI.Forms
{
    public partial class frmMainWindow : Form
    {
        public static Form thisForm;

        public frmMainWindow()
        {
            InitializeComponent();

            thisForm = this;

            // naslovna linija (ispis trenutne verzije)
            string windowTitle = "Elbraco Web Kroler - Verzija ";

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment cd =
                System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                windowTitle += cd.CurrentVersion;
            }

            this.Text = windowTitle;
        }

        private Version getRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

      
        private void noviProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProizvodi proizvod = new frmProizvodi(null);
            //proizvod.MdiParent = this;
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
            //prodavac.MdiParent = this;
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
            frmStartKrol noviKrol = new frmStartKrol();
            noviKrol.MdiParent = this;
            noviKrol.Show();
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
            frmListaKrolovaCrosstab listaKrolovaCrosstab = new frmListaKrolovaCrosstab();
            listaKrolovaCrosstab.MdiParent = this;
            listaKrolovaCrosstab.Show();
        }

        private void mainTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // provera da li frmMainB2B forma već otvorena
            if (isFormOpened(Application.OpenForms, typeof(frmMainB2B))) return;            

            
            // nova instanca tempPwd forme
            tempPwd pwd = new tempPwd();
            pwd.ShowDialog();

            DialogResult dr = pwd.dialogResult;

            if (pwd.dialogResult == DialogResult.OK)
            {
                frmMainB2B mainB2B = new frmMainB2B();
                mainB2B.MdiParent = this;
                mainB2B.Show();
            }
            else return;
            
        }


        private bool isFormOpened(FormCollection formCollection, Type formType)
        {
            return Application.OpenForms.Cast<Form>().Any(f => f.GetType() == formType);
        }
       

    }
}

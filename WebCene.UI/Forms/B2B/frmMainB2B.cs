using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;
using WebCene.Model.B2B;
using WebCene.Helper;
using System.Xml;
using System.Threading;
using WebCene.Model.PIN_ServiceReference;
using WebCene.Model.CT_ServiceReference;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml.Serialization;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmMainB2B : Form
    {


        // podaci koji se prikazuju u datagrid-u
        private List<B2B_Results_RowItem> B2B_Results_Rows_AllSuppliers;          


        public frmMainB2B()
        {
            InitializeComponent();

            // background worker - učitava xml fajlove dobavljača
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;            


            B2B_Results_Rows_AllSuppliers = new List<B2B_Results_RowItem>();
            SetXmlLoadingStatusMessage("", true);
        }
        

        private void btnWebService_Click(object sender, EventArgs e)
        {                                 

        }
        

        private void btnLoadXmls_Click(object sender, EventArgs e)
        {
         
            if (backgroundWorker1.IsBusy != true)
            {
                // clear results and status views
                ClearResultsControls();

                // run loader image
                loaderPictureBox.Visible = true;

                // run worker
                backgroundWorker1.RunWorkerAsync();
            }
        }


        private void ClearResultsControls()
        {
            // lista učitanih rezultata - clear
            B2B_Results_Rows_AllSuppliers.Clear();

            // prikaz svih rezultata - clear
            DisplayB2B_Results_Rows(B2B_Results_Rows_AllSuppliers);

            ClearXmlLoadingStatuses();

            SetXmlLoadingStatusMessage("Učitavanje konfiguracija dobavljača ", true);
        }


        private void LoadXmlFilesForAllSuppliers(object sender, DoWorkEventArgs e)
        {
  
            // Xml rezultat za jednog dobavljača
            List<B2B_Results_RowItem> b2B_Results_RowItems;
            List<KonfigDobavljaca> suppliersConfigurations = DBHelper.Instance.GetAllSupplierConfigurations();

   
            BackgroundWorker worker = sender as BackgroundWorker;

            int totalSuppliers = suppliersConfigurations.Count();            
           

            for ( int currentSupplierIndex = 0; currentSupplierIndex < totalSuppliers; currentSupplierIndex++)
            {

                // progress bar percentage
                decimal progressBarPercentage =  (currentSupplierIndex + 1) * (decimal)( 100 / totalSuppliers);
                // kod poslednjeg dobavljača progress je 100%
                if (currentSupplierIndex + 1 == totalSuppliers) progressBarPercentage = 100;



                // cancelled backgroung worker
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                b2B_Results_RowItems = new List<B2B_Results_RowItem>();

                // učitavanje podataka
                LoadedXmlStatus loadedXmlStatus = new LoadedXmlStatus();
                bool isLoaded = true;
                int numberOfRecords = 0;                             
               
                
                try
                {
                    
                    b2B_Results_RowItems = XMLHelper.Instance.GetB2B_Results_RowItems_PerSupplier(suppliersConfigurations[currentSupplierIndex]);

                    // set loading status
                    numberOfRecords = b2B_Results_RowItems.Count;

                    if (numberOfRecords == 0) isLoaded = false;

                    // set loaded xmlStatuses
                    loadedXmlStatus = SetXmlLoadingStatus(currentSupplierIndex + 1, isLoaded, numberOfRecords, XMLHelper.StatusDescription, suppliersConfigurations[currentSupplierIndex]);

                    // background worker report status
                    worker.ReportProgress((int)progressBarPercentage, loadedXmlStatus);
                }

                catch (Exception xcp)
                { 

                    //SetXmlLoadingStatusMessage("Greška " + suppliersConfigurations[currentSupplierIndex].Naziv, true);

                    // set loaded xmlStatuses
                    isLoaded = false;
                    loadedXmlStatus = SetXmlLoadingStatus(currentSupplierIndex + 1, isLoaded, numberOfRecords, XMLHelper.StatusDescription, suppliersConfigurations[currentSupplierIndex]);

                    // background worker report status                    
                    worker.ReportProgress((int)progressBarPercentage, loadedXmlStatus);
          
                    continue;
                }                                              

                // dodavanje u listu rezultata učitavanja
                B2B_Results_Rows_AllSuppliers.AddRange(b2B_Results_RowItems);
            }                     
        }
               

        public void SetXmlLoadingStatusMessage(string text, bool visibility)
        {
            lblStatus.Text = text + " ...";
            lblStatus.Refresh();

            //lblStatus.Visible = visibility;
        }


        private void ClearXmlLoadingStatuses()
        {
            // status label
            SetXmlLoadingStatusMessage("", true);

            // status tabela
            dgvStatus.Rows.Clear();
            dgvStatus.Refresh();
        }


        private LoadedXmlStatus SetXmlLoadingStatus(int redniBroj, bool isLoaded, int numberOfRecords, string statusDescription, KonfigDobavljaca konfigDobavljaca)
        {
            // status učitavanja
            LoadedXmlStatus status = new LoadedXmlStatus()
            {
                Number = redniBroj,
                Naziv = konfigDobavljaca.Naziv,
                URL = konfigDobavljaca.URL,
                NumberOfRecords = numberOfRecords,
                IsLoaded = isLoaded,
                StatusDescription = statusDescription,
                DataSource = konfigDobavljaca.WebProtokol,
                konfigDobavljaca = konfigDobavljaca
                
            };

            return status;
        }


        private void DisplayB2B_Results_Rows(List<B2B_Results_RowItem> podaciZaPrikaz)
        {
            // prikaz podataka

            DataTable dt = Helpers.Instance.ListToDataTable<B2B_Results_RowItem>(podaciZaPrikaz);
            dgvZbirniXml.DataSource = dt;
        }


        private void DisplayXmlLoadingStatusMessageRow(LoadedXmlStatus status)
        {
            // prikaz statusa učitavanja 

            DataGridViewRow row = new DataGridViewRow();

            string isLoaded = status.IsLoaded ? "OK" : "Greška";

            row.CreateCells(dgvStatus);

            // prkaz kolona u prikazu statusa učitavanja
            row.SetValues (
                status.Number, 
                status.Naziv, 
                isLoaded, 
                status.NumberOfRecords,
                status.StatusDescription,
                status.DataSource
                );

            // markira kolonu u crveno ako deserijalizacija xml-a nije uspela 
            if (!status.IsLoaded)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Yellow;
                style.ForeColor = Color.DarkRed;
                row.DefaultCellStyle = style;
            }

            dgvStatus.Rows.Add(row);

            dgvStatus.ClearSelection();
            dgvStatus.Refresh();
        }


        private void btnCancelXmlLoading_Click(object sender, EventArgs e)
        {
            // Cancel xml loading dugme

            // loader image
            loaderPictureBox.Visible = false;

            // bsackground worker
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }



        /** BACKGROUND WORKER - učitavanje xml fajlova dobavljača */

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                // loader image
                loaderPictureBox.Visible = false;

                DisplayPopUpMessage("Korisnik je prekinuo učitavanje podataka!", "Učitavanje podataka", null);

                // progress bar
                progressBgWorker1.Value = 0;
                progressLabel.Text = "0";               
            }

            else if (e.Error != null)
            {
                // loader image
                loaderPictureBox.Visible = false;

                DisplayPopUpMessage("Greška prilikom učitavanje podataka!\r\nPokušaj ponovo ili kontaktiraj podršku ukoliko se greška ponovi.\r\nErr: " + e.Error, "Učitavanje podataka", null);
               
            }

            else
            {
                // loader image
                loaderPictureBox.Visible = false;

                // status
                DisplayB2B_Results_Rows(B2B_Results_Rows_AllSuppliers);
                SetXmlLoadingStatusMessage("Učitavanje je završeno. Učitano je " + B2B_Results_Rows_AllSuppliers.Count.ToString() + " zapisa", true);

                // message box
                DisplayPopUpMessage("Učitavanje je završeno. Učitano je " + B2B_Results_Rows_AllSuppliers.Count.ToString() + " zapisa", "Učitavanje podataka", null);
            }
        }


        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Refresh UI controls

            LoadedXmlStatus loadedXmlStatus = e.UserState as LoadedXmlStatus;

            SetXmlLoadingStatusMessage("Učitavanje podataka " + loadedXmlStatus.Naziv, true);

            DisplayXmlLoadingStatusMessageRow(loadedXmlStatus);

            // progress bar 
            progressBgWorker1.Value = e.ProgressPercentage;
            progressLabel.Text = e.ProgressPercentage.ToString() + "%";
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;               
            }
            else
            {                
                // sender se šalje kao argument zbog prijavljivanja progress changed događaja
                LoadXmlFilesForAllSuppliers(sender, e);                
            }
        }



        private void DisplayPopUpMessage(string message, string title, string err)
        {
            // prikazivanje poruka iz background workera
            MessageBox.Show(message, title );
        }


      



    }
}

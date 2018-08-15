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

            B2B_Results_Rows_AllSuppliers = new List<B2B_Results_RowItem>();
            SetXmlLoadingStatusMessage("", true);
        }
        


        private void btnWebService_Click(object sender, EventArgs e)
        {

                                  

        }



        private void btnLoadXmls_Click(object sender, EventArgs e)
        {           

            // lista učitanih rezultata - clear
            B2B_Results_Rows_AllSuppliers.Clear();

            // prikaz svih rezultata - clear
            DisplayB2B_Results_Rows(B2B_Results_Rows_AllSuppliers);


            // Xml rezultat za jednog dobavljača
            List<B2B_Results_RowItem> b2B_Results_RowItems;
            List<KonfigDobavljaca> suppliersConfigurations = DBHelper.Instance.GetAllSupplierConfigurations();
            int itemNumber = 1;

            ClearXmlLoadingStatuses();
            SetXmlLoadingStatusMessage("Učitavanje konfiguracija ", true);           
            

            foreach (KonfigDobavljaca supplierConfiguration in suppliersConfigurations)
            {
                b2B_Results_RowItems = new List<B2B_Results_RowItem>();

                // učitavanje podataka
                LoadedXmlStatus loadedXmlStatus = new LoadedXmlStatus();
                bool isLoaded = true;
                int numberOfRecords = 0;

                try
                {
                    SetXmlLoadingStatusMessage("Učitavanje podataka " + supplierConfiguration.Naziv, true);

                    b2B_Results_RowItems = XMLHelper.Instance.GetB2B_Results_RowItems_PerSupplier(supplierConfiguration);

                    // set loading status
                    numberOfRecords = b2B_Results_RowItems.Count;

                    if (numberOfRecords == 0) isLoaded = false;
                    loadedXmlStatus = SetXmlLoadingStatus(itemNumber, supplierConfiguration.Naziv, supplierConfiguration.URL, isLoaded, numberOfRecords, XMLHelper.StatusDescription, supplierConfiguration);
                }
                catch (Exception xcp)
                {                    

                    SetXmlLoadingStatusMessage("Greška " + supplierConfiguration.Naziv, true);

                    // set loading status
                    isLoaded = false;
                    loadedXmlStatus = SetXmlLoadingStatus(itemNumber, supplierConfiguration.Naziv, supplierConfiguration.URL, isLoaded, numberOfRecords, XMLHelper.StatusDescription, supplierConfiguration);
                    DisplayXmlLoadingStatusMessageRow(loadedXmlStatus);

                    itemNumber++;
                    continue;
                }

                DisplayXmlLoadingStatusMessageRow(loadedXmlStatus);
                itemNumber++;

                // dodavanje u listu rezultata učitavanja
                B2B_Results_Rows_AllSuppliers.AddRange(b2B_Results_RowItems);
            }

            // prikaz svih rezultata učitavanja
            DisplayB2B_Results_Rows(B2B_Results_Rows_AllSuppliers);

            SetXmlLoadingStatusMessage("Završeno.", true);

            SetXmlLoadingStatusMessage("Učitavanje je završeno. Učitano je " + B2B_Results_Rows_AllSuppliers.Count.ToString() + " zapisa", true);
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

        private LoadedXmlStatus SetXmlLoadingStatus(int redniBroj, string nazivDobavljaca, string url, bool isLoaded, int numberOfRecords, string statusDescription, KonfigDobavljaca konfigDobavljaca)
        {
            // status učitavanja
            LoadedXmlStatus status = new LoadedXmlStatus()
            {
                Number = redniBroj,
                Naziv = nazivDobavljaca,
                URL = url,
                NumberOfRecords = numberOfRecords,
                IsLoaded = isLoaded,
                StatusDescription = statusDescription,
                DataSource = konfigDobavljaca.WebProtokol
                
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
            row.SetValues
                (
                status.Number, 
                status.Naziv, 
                isLoaded, 
                status.NumberOfRecords,
                status.StatusDescription,
                status.DataSource
                );

            // if isLoaded == false then row is marked
            if (!status.IsLoaded)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.OrangeRed;
                style.ForeColor = Color.WhiteSmoke;
                row.DefaultCellStyle = style;
            }

            dgvStatus.Rows.Add(row);

            dgvStatus.ClearSelection();
            dgvStatus.Refresh();
        }






    }
}

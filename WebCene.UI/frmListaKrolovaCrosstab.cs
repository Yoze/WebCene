﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;
using WebCene.UI;

namespace WebCene.UI
{
    public partial class frmListaKrolovaCrosstab : Form
    {
        /*
         TO DO
         dinamički crosstab datagridview
         redovi sadrže proizvode
         kolone sadrže prodavce


         filter po kategoriji
         filter po brendu
        */


        private List<KrolGlava> ListaKrolGlava { get; set; }
        private List<viewKrolStavke> ListaKrolStavke { get; set; }
        private List<KATARTIK> ListaKategorija { get; set; }
        private List<BRAND> ListaBrendova { get; set; }
        private int? OdabraniKrolGlavaId { get; set; }
        private DataTable KrolStavkeDataTable { get; set; }


        public frmListaKrolovaCrosstab()
        {
            InitializeComponent();

            NapuniListeZaCombo();

            UcitajComboKategorije();
            UcitajComboBrendovi();

            PrikaziListuKrolGlava();

        }

        private void NapuniListeZaCombo()
        {
            try
            {
                using (ELBSModel db = new ELBSModel())
                {
                    ListaKategorija = new List<KATARTIK>();
                    ListaKategorija = db.KATARTIK
                        .OrderBy(k => k.KAT2)
                        .ToList();

                    ListaBrendova = new List<BRAND>();
                    ListaBrendova = db.BRAND
                        .OrderBy(b => b.PROIZVODJAC)
                        .ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greška pri učitavanju podataka za combo.", "Greška");
            }
        }

        private void PrikaziListuKrolGlava()
        {

            lstViewKrolGlava.Items.Clear();
            try
            {
                using (WebCeneModel db = new WebCeneModel())
                {
                    ListaKrolGlava = new List<KrolGlava>();

                    ListaKrolGlava = db.KrolGlava
                        .OrderByDescending(d => d.DatumKrola)
                        .ToList();

                    int brojElemenataListe = ListaKrolGlava.Count;

                    if (brojElemenataListe == 0)
                    {
                        lblKrolGlavaPoruka.Visible = true;
                        return;
                    }
                    if (brojElemenataListe > 0)
                    {
                        lblKrolGlavaPoruka.Visible = false;
                        lstViewKrolGlava.BeginUpdate();

                        foreach (KrolGlava krolGlavaStavka in ListaKrolGlava)
                        {
                            var item = new ListViewItem(new string[] {
                                krolGlavaStavka.DatumKrola.ToShortDateString(),
                                krolGlavaStavka.NazivKrola,
                                krolGlavaStavka.IzvrsilacKrola,
                                krolGlavaStavka.Id.ToString()
                            });

                            lstViewKrolGlava.Items.Add(item);
                        }

                        lstViewKrolGlava.EndUpdate();
                    }
                }
            }
            catch (Exception xcp)
            {
                MessageBox.Show("Greška pri učitavanju KrolGlava.\r\nGreška: " + xcp.Message, "Greška");
            }
        }


        private void UcitajDetaljeKrola(int _odabraniKrolGlavaId)
        {
            // tabela sa detaljima odabranog krola

            string connString = ConfigurationManager.ConnectionStrings["WebCeneADOConn"].ConnectionString;

            if (_odabraniKrolGlavaId > 0)
            {
                KrolStavkeDataTable = new DataTable();

                using (SqlConnection connMSSQLPlus = new SqlConnection(connString))
                {
                    try
                    {
                        SqlDataAdapter da =
                            new SqlDataAdapter("SELECT KrolGLId, Naziv, NazivProdavca, Cena FROM viewKrolStavke WHERE KrolGLId ='"
                            + _odabraniKrolGlavaId.ToString() + "'"
                            , connMSSQLPlus);

                        da.Fill(KrolStavkeDataTable);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška u preuzimanju podataka sa servera.", "Greška");
                        return;
                    }
                    PrikaziDetaljeKrola();
                }
            }
            else return;
        }

        private void PrikaziDetaljeKrola()
        {
            DataTable inversedKrolStavkeDataTable = new DataTable();

            inversedKrolStavkeDataTable = GetInversedDataTable(KrolStavkeDataTable, "NazivProdavca", "Naziv", "Cena", "-", false);

            // dgview props

            int brojKolona = inversedKrolStavkeDataTable.Columns.Count;
            int brojRedova = inversedKrolStavkeDataTable.Rows.Count;

            if (brojRedova > 0)
            {
                lblDetaljPoruka.Visible = false;

                dgViewKrolDetalj.DataSource = inversedKrolStavkeDataTable;

                dgViewKrolDetalj.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                for (int i = 1; i < brojKolona; i++)
                {
                    // 1.kolona
                    dgViewKrolDetalj.Columns[0].Width = 180;
                    dgViewKrolDetalj.Columns[0].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    // ostale kolone
                    dgViewKrolDetalj.Columns[i].Width = 110;
                    dgViewKrolDetalj.Columns[i].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
            }
            if (brojRedova == 0)
            {
                dgViewKrolDetalj.DataSource = null;
                dgViewKrolDetalj.Refresh();
                lblDetaljPoruka.Visible = true;
                return;
            }
            

           
        }



        public static DataTable GetInversedDataTable(DataTable table, string columnX, string columnY, string columnZ, string nullValue, bool sumValues)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            //Add a Column at the beginning of the table
            returnTable.Columns.Add(columnY);


            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {

                string columnXTemp = dr[columnX].ToString();
                if (!columnXValues.Contains(columnXTemp))
                {
                    //Read each row value, if it's different from others provided, add to 
                    //the list of values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
            }

            //Verify if Y and Z Axis columns re provided
            if (columnY != "" && columnZ != "")
            {
                //Read DISTINCT Values for Y Axis Column
                List<string> columnYValues = new List<string>();

                foreach (DataRow dr in table.Rows)
                {
                    if (!columnYValues.Contains(dr[columnY].ToString()))
                        columnYValues.Add(dr[columnY].ToString());
                }

                //Loop all Column Y Distinct Value
                foreach (string columnYValue in columnYValues)
                {
                    //Creates a new Row
                    DataRow drReturn = returnTable.NewRow();
                    drReturn[0] = columnYValue;
                    //foreach column Y value, The rows are selected distincted
                    DataRow[] rows = table.Select(columnY + "='" + columnYValue + "'");

                    //Read each row to fill the DataTable
                    foreach (DataRow dr in rows)
                    {
                        string rowColumnTitle = dr[columnX].ToString();

                        //Read each column to fill the DataTable
                        foreach (DataColumn dc in returnTable.Columns)
                        {
                            if (dc.ColumnName == rowColumnTitle)
                            {
                                //If Sum of Values is True it try to perform a Sum
                                //If sum is not possible due to value types, the value 
                                // displayed is the last one read
                                if (sumValues)
                                {
                                    try
                                    {
                                        drReturn[rowColumnTitle] =
                                             Convert.ToDecimal(drReturn[rowColumnTitle]) +
                                             Convert.ToDecimal(dr[columnZ]);
                                    }
                                    catch
                                    {
                                        drReturn[rowColumnTitle] = dr[columnZ];
                                    }
                                }
                                else
                                {
                                    drReturn[rowColumnTitle] = dr[columnZ];
                                }
                            }
                        }
                    }
                    returnTable.Rows.Add(drReturn);
                }
            }
            else
            {
                throw new Exception("The columns to perform inversion are not provided");
            }

            //if a nullValue is provided, fill the datable with it
            if (nullValue != "")
            {
                foreach (DataRow dr in returnTable.Rows)
                {
                    foreach (DataColumn dc in returnTable.Columns)
                    {
                        if (dr[dc.ColumnName].ToString() == "")
                            dr[dc.ColumnName] = nullValue;
                    }
                }
            }
            return returnTable;
        }




        private void UcitajComboKategorije()
        {
            comboKategorije.DataSource = ListaKategorija;
            comboKategorije.ValueMember = "SHKAT";
            comboKategorije.DisplayMember = "KAT2";
            comboKategorije.SelectedIndex = -1;

        }

        private void UcitajComboBrendovi()
        {
            comboBrendovi.DataSource = ListaBrendova;
            comboBrendovi.ValueMember = "PROIZVODJAC";
            comboBrendovi.DisplayMember = "PROIZVODJAC";
            comboBrendovi.SelectedIndex = -1;
        }


        private void Enter_NextControl(object sender, KeyEventArgs e)
        {

            Control nextControl;

            if (e.KeyCode == Keys.Enter)
            {
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                {
                    nextControl = GetNextControl(null, true);
                }
                nextControl.Focus();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FiltrirajPrikazKrolova();

        }

        private void FiltrirajPrikazKrolova()
        {
            // TO DO

            string odabraniBrend =
                (string)comboBrendovi.SelectedValue;

            string odabranaKategorija =
                (string)comboKategorije.SelectedValue;

            MessageBox.Show("Kat2: " + odabranaKategorija + "\r\nBrend: " + odabraniBrend);

        }

        private void lstViewKrolGlava_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewKrolGlava.SelectedItems.Count == 0) return;

            ListViewItem _odabraniKrolGlavaListItem = lstViewKrolGlava.SelectedItems[0];

            if (_odabraniKrolGlavaListItem != null)
            {
                OdabraniKrolGlavaId =
                    Convert.ToInt32(_odabraniKrolGlavaListItem.SubItems[3].Text);

                UcitajDetaljeKrola((int)OdabraniKrolGlavaId);
            }
            if (_odabraniKrolGlavaListItem == null) return;
        }

        private void linkResetFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBrendovi.SelectedIndex = -1;
            comboKategorije.SelectedIndex = -1;


        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNoviKrol_Click(object sender, EventArgs e)
        {
            frmStartKrol noviKrol = new frmStartKrol();
            noviKrol.ShowDialog();

            NapuniListeZaCombo();

            UcitajComboKategorije();
            UcitajComboBrendovi();

            PrikaziListuKrolGlava();
        }
    }
}
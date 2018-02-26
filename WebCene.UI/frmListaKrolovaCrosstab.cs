using System;
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

        private List<KrolGlava> ListaKrolGlava { get; set; }
        private List<viewKrolStavke> ListaKrolStavke { get; set; }
        private List<KATARTIK> ListaKategorija { get; set; }
        private List<BRAND> ListaBrendova { get; set; }
        private int? OdabraniKrolGlavaId { get; set; }
        private DataTable KrolStavkeDataTable { get; set; }
        private DataTable filteredKrolStavkeDataTable { get; set; }


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
                    connMSSQLPlus.Open();

                    if (connMSSQLPlus.State == ConnectionState.Open)
                    {
                        try
                        {
                            SqlDataAdapter da =
                                new SqlDataAdapter("SELECT KrolGLId, Naziv, NazivProdavca, Cena, ElKat, Brend FROM infoekon_Bane.viewKrolStavke WHERE KrolGLId ='"
                                + _odabraniKrolGlavaId.ToString() + "'"
                                , connMSSQLPlus);

                            da.Fill(KrolStavkeDataTable);
                        }
                        catch (Exception xcp)
                        {
                            MessageBox.Show("Greška u preuzimanju podataka sa servera.\r\n:Err: " + xcp.Message, "Greška");
                            return;
                        }
                        PrikaziDetaljeKrola(KrolStavkeDataTable);
                    }
                    else
                    {
                        MessageBox.Show("Konekcija sa serverom nije uspostavljena.", "Greška u konekciji");
                        return;
                    }
                    
                }
            }
            else return;
        }


        private void FiltrirajListuDetalja(string _ElKat, string _Brend)
        {
            // ispitivanje parametara radi kreiranja sql upita
            string sqlParametri = string.Empty;

            // obaNull
            if (string.IsNullOrEmpty(_ElKat) && string.IsNullOrEmpty(_Brend)) sqlParametri = "obaNull";

            // KatNullBrendNotNull
            if (string.IsNullOrEmpty(_ElKat) && !(string.IsNullOrEmpty(_Brend))) sqlParametri = "KatNullBrendNotNull";

            // KatNotNullBrendNull
            if (!(string.IsNullOrEmpty(_ElKat)) && string.IsNullOrEmpty(_Brend)) sqlParametri = "KatNotNullBrendNull";

            // obaNotNull
            if (!(string.IsNullOrEmpty(_ElKat)) && !(string.IsNullOrEmpty(_Brend))) sqlParametri = "obaNotNull";


            if (OdabraniKrolGlavaId != null)
            {
                filteredKrolStavkeDataTable = new DataTable();

                string connString = ConfigurationManager.ConnectionStrings["WebCeneADOConn"].ConnectionString;

                using (SqlConnection connMSSQLPlus = new SqlConnection(connString))
                {
                    SqlDataAdapter da;

                    try
                    {
                        switch (sqlParametri)
                        {
                            case "obaNull":
                                MessageBox.Show("Odaberi parametre filtera iz padajućih menija.", "Filter podataka");
                                picFilter.Visible = false;
                                filteredKrolStavkeDataTable = KrolStavkeDataTable;
                                break;

                            case "KatNullBrendNotNull":
                                {
                                    string _BrendTrimmed = _Brend.TrimEnd();

                                    da = new SqlDataAdapter("SELECT KrolGLId, Naziv, NazivProdavca, Cena, ElKat, Brend FROM infoekon_Bane.viewKrolStavke WHERE KrolGLId ='"
                                        + OdabraniKrolGlavaId + "' AND Brend='" + _BrendTrimmed + "'", connMSSQLPlus);

                                    da.Fill(filteredKrolStavkeDataTable);
                                    break;
                                }

                            case "KatNotNullBrendNull":
                                {
                                    string _ElKatTrimmed = _ElKat.TrimEnd();
                                    da = new SqlDataAdapter("SELECT KrolGLId, Naziv, NazivProdavca, Cena, ElKat, Brend FROM infoekon_Bane.viewKrolStavke WHERE KrolGLId ='"
                                        + OdabraniKrolGlavaId + "' AND ElKat='" + _ElKatTrimmed + "'", connMSSQLPlus);

                                    da.Fill(filteredKrolStavkeDataTable);
                                    break;
                                }

                            case "obaNotNull":
                                {
                                    string _BrendTrimmed = _Brend.TrimEnd();
                                    string _ElKatTrimmed = _ElKat.TrimEnd();

                                    da = new SqlDataAdapter("SELECT KrolGLId, Naziv, NazivProdavca, Cena, ElKat, Brend FROM infoekon_Bane.viewKrolStavke WHERE KrolGLId ='"
                                        + OdabraniKrolGlavaId + "' AND ElKat='" + _ElKatTrimmed + "' AND Brend='" + _BrendTrimmed + "'"
                                        , connMSSQLPlus);

                                    da.Fill(filteredKrolStavkeDataTable);
                                    break;
                                }

                                //default:
                                //    break;
                        }
                        PrikaziDetaljeKrola(filteredKrolStavkeDataTable);
                    }
                    catch (Exception xcp)
                    {
                        MessageBox.Show("Greška pri filtriranju podataka.\r\nGreška: " + xcp.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            else return;
        }



        private void PrikaziDetaljeKrola(DataTable _tableToTransform)
        {
            /* OVA METODA POZIVA GetInversedDataTable ZA KREIRANJE PIVOT TABELE I VRŠI ISPIS U DGV*/

            DataTable inversedKrolStavkeDataTable = new DataTable();

            inversedKrolStavkeDataTable = GetInversedDataTable(_tableToTransform, "NazivProdavca", "Naziv", "Cena", "-", false);


            int brojKolona = inversedKrolStavkeDataTable.Columns.Count;
            int brojRedova = inversedKrolStavkeDataTable.Rows.Count;

            if (brojRedova > 0)
            {
                lblDetaljPoruka.Visible = false;

                dgViewKrolDetalj.DataSource = inversedKrolStavkeDataTable;

                dgViewKrolDetalj.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                // 1.kolona
                dgViewKrolDetalj.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgViewKrolDetalj.Columns[0].Width = 195;

                for (int i = 1; i < brojKolona; i++)
                {

                    // ostale kolone
                    dgViewKrolDetalj.Columns[i].Width = 90;
                }


                //// formatiranje boje pozadine minimalne vrednosti u redu
                //// redovi
                //for (int red = 0; red < brojRedova; red++)
                //{
                //    int indeksMinimalneCene = 0;
                //    decimal minCena = 0;
                //    decimal parsedCena;


                //    // kolone
                //    for (int kol = 0; kol < brojKolona; kol++)
                //    {

                //        var cellValue = dgViewKrolDetalj.Rows[red].Cells[kol].Value;

                //        bool isParsedToDecimal = decimal.TryParse(cellValue.ToString(), out parsedCena);

                //        if (isParsedToDecimal)
                //        {
                //            if (minCena == 0)
                //            {
                //                minCena = parsedCena;
                //                indeksMinimalneCene = kol;
                //            }

                //            if (parsedCena < minCena)
                //            {
                //                minCena = parsedCena;
                //                indeksMinimalneCene = kol;
                //            }
                //        }
                //        if (!isParsedToDecimal)
                //        {
                //            parsedCena = minCena;
                //        }
                //    }

                //    // ovde farbanje ćelije
                //    if (indeksMinimalneCene > 0)
                //    {
                //        dgViewKrolDetalj.Rows[red].Cells[indeksMinimalneCene].Style.BackColor = Color.Tan;
                //    }
                //}

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
            string odabraniBrend =
                (string)comboBrendovi.SelectedValue;

            string odabranaKategorija =
                (string)comboKategorije.SelectedValue;

            //MessageBox.Show("Kat2: " + odabranaKategorija + "\r\nBrend: " + odabraniBrend);

            picFilter.Visible = true;

            FiltrirajListuDetalja(odabranaKategorija, odabraniBrend);

        }


        private void lstViewKrolGlava_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewKrolGlava.SelectedItems.Count == 0) return;

            ListViewItem _odabraniKrolGlavaListItem = lstViewKrolGlava.SelectedItems[0];

            if (_odabraniKrolGlavaListItem != null)
            {
                OdabraniKrolGlavaId =
                    Convert.ToInt32(_odabraniKrolGlavaListItem.SubItems[3].Text);

                lblNazivKrola.Visible = true;
                lblNazivKrola.Text =
                    _odabraniKrolGlavaListItem.SubItems[0].Text + "   " +
                    _odabraniKrolGlavaListItem.SubItems[1].Text;

                btnFilter.Enabled = true;
                linkResetFilter.Enabled = true;

                PonistiFilter();
                UcitajDetaljeKrola((int)OdabraniKrolGlavaId);
            }
            if (_odabraniKrolGlavaListItem == null) return;
        }

        private void linkResetFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PonistiFilter();
            filteredKrolStavkeDataTable = KrolStavkeDataTable;
            PrikaziDetaljeKrola(filteredKrolStavkeDataTable);
        }

        private void PonistiFilter()
        {
            comboBrendovi.SelectedIndex = -1;
            comboKategorije.SelectedIndex = -1;

            picFilter.Visible = false;
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

        private void toolStripObrisiKrol_Click(object sender, EventArgs e)
        {
            if (OdabraniKrolGlavaId != null)
            {
                KrolGlava stavkaZaBrisanje = new KrolGlava();

                using (WebCeneModel db = new WebCeneModel())
                {
                    stavkaZaBrisanje = db.KrolGlava
                        .Where(x => x.Id == OdabraniKrolGlavaId)
                        .FirstOrDefault();

                    DialogResult dr =
                        MessageBox.Show("Odabrani krol i njegovi detalji će biti obrisani! Da li želite da nastavite sa brisanjem?", "Brisanje krola", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            db.Entry(stavkaZaBrisanje).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();

                            MessageBox.Show("Krol je obrisan.", "Brisanje");
                        }
                        catch (Exception xcp)
                        {
                            MessageBox.Show("Greška prilikom brisanja.\r\n" + xcp.Message, "Greška");
                            return;
                        }
                    }
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                PrikaziListuKrolGlava();
            }
            else
            {
                MessageBox.Show("Odaberi stavku za brisanje.", "Brisanje");
                return;
            }
        }
    }
}

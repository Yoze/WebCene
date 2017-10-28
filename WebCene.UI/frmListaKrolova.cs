using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;

namespace WebCene.UI
{
    public partial class frmListaKrolova : Form
    {
        private List<viewKrolStavke> ListaKrolDetalja { get; set; }
        private List<KrolGlava> ListaKrolGlava { get; set; }

        private int? OdabraniKrolGlavaId { get; set; }


        public frmListaKrolova()
        {
            InitializeComponent();

            lblDetaljPoruka.Text = string.Empty;

            PrikaziListuKrolGlava();

        }


        private void PrikaziListuKrolGlava()
        {
            lstViewKrolGlava.Items.Clear();

            using (WebCeneModel db = new WebCeneModel())
            {
                ListaKrolGlava = new List<KrolGlava>(db.KrolGlava);

                lstViewKrolGlava.BeginUpdate();

                foreach (KrolGlava krolGlavaStavka in ListaKrolGlava)
                {
                    var item = new ListViewItem(new string[]
                    {
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


        private void PrikaziListuKrolDetalja()
        {
            int brElemenata = ListaKrolDetalja.Count;

            lstViewKrolDetalj.BeginUpdate();
            lstViewKrolDetalj.Groups.Clear();
            lstViewKrolDetalj.Items.Clear();

            if (brElemenata == 0)
            {
                lblDetaljPoruka.Text = "Odabrani krol ne sadrži detalje.";
            }
            else if (brElemenata > 0)
            {
                lblDetaljPoruka.Text = string.Empty;

                foreach (viewKrolStavke krolDetaljStavke in ListaKrolDetalja)
                {
                    var item = new ListViewItem(new string[]
                    {
                    krolDetaljStavke.Naziv,
                    krolDetaljStavke.NazivProdavca,
                    krolDetaljStavke.Cena.ToString("N2")
                    });

                    lstViewKrolDetalj.Items.Add(item);
                }
            }

            lstViewKrolDetalj.EndUpdate();
        }


        private void UcitajDetaljeKrola(int _odabraniKrolGlavaId)
        {
            List<viewKrolStavke> query = null;

            using (WebCeneModel db = new WebCeneModel())
            {
                query = (from krols in db.viewKrolStavke
                         where krols.KrolGLId == _odabraniKrolGlavaId
                         select krols).ToList();
            }

            ListaKrolDetalja = new List<viewKrolStavke>();

            foreach (viewKrolStavke item in query)
            {
                ListaKrolDetalja.Add(item);
            }

            PrikaziListuKrolDetalja();
        }



        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
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



        private void lstViewKrolGlava_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewKrolGlava.SelectedItems.Count == 0) return;

            ListViewItem _odabraniKrolGlavaListItem = lstViewKrolGlava.SelectedItems[0];

            //int odabranListItemKrolId

            if (_odabraniKrolGlavaListItem != null)
            {
                OdabraniKrolGlavaId =
                    Convert.ToInt32(_odabraniKrolGlavaListItem.SubItems[3].Text);

                UcitajDetaljeKrola((int)OdabraniKrolGlavaId);
            }
            if (_odabraniKrolGlavaListItem == null) return;
            

            //MessageBox.Show(odabranListItemKrolId.ToString());

            //OdabraniKrolGlavaId = odabranListItemKrolId;

            

        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
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

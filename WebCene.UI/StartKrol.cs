using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCene.UI
{
    public partial class StartKrol : Form
    {
        public StartKrol()
        {
            InitializeComponent();
        }

        private void btnStartKrol_Click(object sender, EventArgs e)
        {

            SetTimer();

        }


        private void SetTimer()
        {
            for (int i = 0; i < 5; i++)
            {
                Random rnd = new Random();
                int _rnd = rnd.Next(1000, 3500);

                MessageBox.Show(_rnd.ToString());

            }

            
             
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WebCene.UI
{
    public partial class frmStartKrol : Form
    {
        private static System.Timers.Timer krolTimer;

        public frmStartKrol()
        {
            InitializeComponent();
        }

        private void btnStartKrol_Click(object sender, EventArgs e)
        {
            //List<int> listaIntervala = new List<int>();


            StartTimer();



        }


        public static void IzvrsiKrol(object source, ElapsedEventArgs e)
        {


            krolTimer.Interval = GetRandomTimerInterval();

            System.Timers.Timer _timer = (System.Timers.Timer)source;

            int interval = Convert.ToInt32(_timer.Interval);

            Console.WriteLine("interval: {0}", interval.ToString());


        }


        private void StartTimer()
        {
            krolTimer = new System.Timers.Timer();

            krolTimer.Elapsed += new ElapsedEventHandler(IzvrsiKrol);
            krolTimer.AutoReset = false;
            krolTimer.Enabled = true;

            

        }

        private void StopTimer()
        {
            // zaustavlja izvršavanje timera
            try
            {
                krolTimer.Close();
                MessageBox.Show("Timer stopped and disposed");
            }
            catch (Exception)
            {
                MessageBox.Show("Timer is not initialized.");
            }

            
        }

        private void btnStopKrol_Click(object sender, EventArgs e)
        {
            StopTimer();
        }



        private static int GetRandomTimerInterval()
        {

            Random rnd = new Random();
            int _rnd = rnd.Next(1000, 3500); // miliseconds           

            return _rnd;
        }
    }


}

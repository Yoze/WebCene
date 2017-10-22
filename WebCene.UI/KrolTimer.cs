using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace WebCene.UI
{
    public static class KrolTimer
    {

        static Timer _timer;
        static int timerInterval;
        static List<int> _l;

        public static List<int> IntervalList
        {
            get
            {
                if (_l == null)
                {
                    Start();
                }
                return _l;
            }
        }


        static void Start()
        {
            timerInterval = GetRandomTimerInterval();
            _l = new List<int>();            
            _timer = new Timer(timerInterval);

            _timer.Elapsed += new ElapsedEventHandler(_timerElapsed);
            _timer.Enabled = true;

        }


        static void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
        }


        static void _timerElapsed(object sender, ElapsedEventArgs e)
        {
            _l.Add(timerInterval);
        }
        

        private static int GetRandomTimerInterval()
        {

            Random rnd = new Random();
            int _rnd = rnd.Next(1000, 3500); // miliseconds           

            return _rnd;
        }
    }
}

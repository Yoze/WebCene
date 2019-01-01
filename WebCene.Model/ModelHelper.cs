using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCene.Model.B2B;

namespace WebCene.Model
{
    public sealed class ModelHelper
    {
        public static ModelHelper Instance { get; } = new ModelHelper();

        ModelHelper()
        {
            // initialize here
        }


        public double CalculateNNC(double unnc, KonfigDobavljaca konfigDobavljaca)
        {
            double calculatedNNC = 0;
            double kursEvra = konfigDobavljaca.KursEvra;
            double rabat = 1 + (konfigDobavljaca.RabatProc / 100);
            string _stopaPdv = ConfigurationManager.AppSettings["stopaPDV"];

            if (double.TryParse(_stopaPdv, out double koefPDV))
            {
                koefPDV = 1 + (koefPDV / 100);
            }

            calculatedNNC = Convert.ToDouble(unnc * rabat * koefPDV * kursEvra);
            return calculatedNNC;
        }


    }
}

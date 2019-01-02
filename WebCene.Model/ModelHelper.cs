using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        public bool IsValidBarcode(string barcode)
        {
            bool isValid = true;

            // ako je barcode = null - preskoči
            if (string.IsNullOrEmpty(barcode))  return isValid = false;

            // ako je barcode = 0 - preskoči    
            if (barcode.Equals("0")) return isValid = false;

            // ako je barcode.Length < 8 - preskoči ga
            if (barcode.Length < 8) return isValid = false;

            // barkod mora da se sastoji samo od brojeva
            Regex onlyNumbers = new Regex(@"^\d+$");
            if (!onlyNumbers.IsMatch(barcode)) return isValid = false;

            return isValid;
        }

    }
}

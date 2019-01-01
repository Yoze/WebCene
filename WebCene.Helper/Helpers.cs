using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebCene.Model;
using WebCene.Model.B2B;
using System.Configuration;



namespace WebCene.Helper
{
    public sealed class Helpers
    {

        static readonly Helpers _instance = new Helpers();
        //private double koeficijentRabata;

        public static Helpers Instance
        {
            get { return _instance; }
        }

        Helpers()
        {
            // initialize here
        }


        public DataTable ListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable
            return dataTable;
        }


        //public double CalculateNNC(double unnc, KonfigDobavljaca konfigDobavljaca)
        //{
        //    double calculatedNNC = 0;
        //    double kursEvra = konfigDobavljaca.KursEvra;
        //    double rabat = 1 + (konfigDobavljaca.RabatProc / 100);
        //    string _stopaPdv = ConfigurationManager.AppSettings["stopaPDV"];

        //    if (double.TryParse(_stopaPdv, out double koefPDV))
        //    {
        //        koefPDV = 1 + (koefPDV / 100);
        //    }

        //    calculatedNNC = Convert.ToDouble( unnc * rabat * koefPDV * kursEvra);
        //    return calculatedNNC;
        //}

    }


   


}

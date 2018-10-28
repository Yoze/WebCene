using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCene.Model.Kroler;
using WebCene.Model.B2B;


namespace WebCene.Helper
{
    public sealed class DBHelper
    {
        // C# Singleton pattern
        // https://www.dotnetperls.com/singleton
        //

        static readonly DBHelper _instance = new DBHelper();

        public static DBHelper Instance {
            get { return _instance; }
        }

        DBHelper()
        {
            // Initialize here

        }



        /** Public methods */
        public KonfigDobavljaca GetSingleSupplierConfigurationById(int supplierId)
        {
            KonfigDobavljaca konfiguracijaDobavljaca = new KonfigDobavljaca();

            try
            {
                using (KrolerContext db = new KrolerContext())
                {
                    konfiguracijaDobavljaca = db.KonfigDobavljaca
                        .Where(d => d.Id == supplierId)
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetKonfigDobavljaca()\r\n" + e.Message);
            }

            return konfiguracijaDobavljaca;
        }


        public KonfigDobavljaca GetSingleSupplierConfigurationByName(string supplierName)
        {
            KonfigDobavljaca konfiguracijaDobavljaca = new KonfigDobavljaca();

            if (string.IsNullOrEmpty(supplierName)) return null;            

            try
            {
                using (KrolerContext db = new KrolerContext())
                {
                    konfiguracijaDobavljaca = db.KonfigDobavljaca
                        .Where(d => d.Naziv.Equals(supplierName))
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetKonfigDobavljaca()\r\n" + e.Message);
            }

            return konfiguracijaDobavljaca;
        }



        public List<KonfigDobavljaca> GetAllSupplierConfigurations()
        {
            List<KonfigDobavljaca> konfiguracijeDobavljaca = new List<KonfigDobavljaca>();

            using (KrolerContext db = new KrolerContext())
            {
                konfiguracijeDobavljaca = db.KonfigDobavljaca.ToList();
            }

            return konfiguracijeDobavljaca;
        }


        public List<DARTIKLI> GetDARTIKLI()
        {
            List<DARTIKLI> dartikli = new List<DARTIKLI>();

            // TO DO

            return dartikli;
        }


        public bool SaveSupplierConfigs(KonfigDobavljaca konfigDobavljaca)
        {
            if (konfigDobavljaca != null)
            {

                using (KrolerContext db = new KrolerContext())
                {
                    try
                    {
                        db.Entry(konfigDobavljaca).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }               
                }
            }

            else return false;

        }

    }
}

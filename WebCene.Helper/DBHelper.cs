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



        /** Konfiguracije dobavljača */
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
            return false;
        }


        /** Marže dobavaljača */
        public List<MarzeDobavljaca> GetSupplierMarginsBySupplierId(int supplierId)
        {
            List<MarzeDobavljaca> marzeDobavljaca = new List<MarzeDobavljaca>();

            if (supplierId > 0)
            {
                try
                {
                    using (KrolerContext db = new KrolerContext())
                    {
                        marzeDobavljaca = db.MarzeDobavljaca.Where(x => x.IdDobavljaca == supplierId).ToList();
                        return marzeDobavljaca;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }


        public List<MarzeDobavljaca> GetSupplierMarginsBySupplierName(string supplierName)
        {

            if (string.IsNullOrEmpty(supplierName)) return null;

            int supplierId = GetSingleSupplierConfigurationByName(supplierName).Id;
            List<MarzeDobavljaca> marzeDobavljaca = new List<MarzeDobavljaca>();

            if (supplierId > 0)
            {
                try
                {
                    using (KrolerContext db = new KrolerContext())
                    {
                        marzeDobavljaca = db.MarzeDobavljaca.Where(x => x.IdDobavljaca == supplierId).ToList();
                        return marzeDobavljaca;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

       
        public MarzeDobavljaca GetSingleSupplierMarginByMarginId(int marzaDobavljacaId)
        {
            if (marzaDobavljacaId == 0) return null;

            MarzeDobavljaca marzaDobavljaca = new MarzeDobavljaca();

            try
            {
                using (KrolerContext db = new KrolerContext())
                {
                    marzaDobavljaca = db.MarzeDobavljaca.Where(x => x.Id == marzaDobavljacaId).FirstOrDefault();

                    return marzaDobavljaca;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool SaveSupplierMargin(MarzeDobavljaca marzaDobavljaca)
        {
            if (marzaDobavljaca != null)
            {
                MarzeDobavljaca tempMarzaDobavljaca = new MarzeDobavljaca();

                // I
                using (KrolerContext db = new KrolerContext())
                {
                    try
                    {
                        tempMarzaDobavljaca = db.MarzeDobavljaca.Where(x => x.Id == marzaDobavljaca.Id).FirstOrDefault();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                // II
                if (tempMarzaDobavljaca != null)
                {
                    tempMarzaDobavljaca = marzaDobavljaca;
                }

                // III
                using (KrolerContext db = new KrolerContext())
                {
                    db.Entry(tempMarzaDobavljaca).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }


        public bool CreateSupplierMargin(MarzeDobavljaca marzaDobavljaca)
        {
            if (marzaDobavljaca != null)
            {
                using (KrolerContext db = new KrolerContext())
                {
                    try
                    {
                        db.Entry(marzaDobavljaca).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }


        public bool DeleteSupplierMargin(MarzeDobavljaca marzaDobavljaca)
        {
            if (marzaDobavljaca != null)
            {
                try
                {
                    using (KrolerContext db = new KrolerContext())
                    {
                        db.Entry(marzaDobavljaca).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();

                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }              
            }
            return false;
        }


        /** DARTIKLI */

        public List<DARTIKLI> GetDARTIKLI()
        {
            List<DARTIKLI> dartikli = new List<DARTIKLI>();

            // TO DO

            return dartikli;
        }


       

    }
}

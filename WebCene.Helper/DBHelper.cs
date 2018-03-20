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
        public KonfigDobavljaca GetKonfigDobavljaca(int id)
        {
            KonfigDobavljaca konfigDobavljaca = new KonfigDobavljaca();

            try
            {
                using (KrolerContext db = new KrolerContext())
                {
                    konfigDobavljaca = db.KonfigDobavljaca
                        .Where(d => d.Id == id)
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetKonfigDobavljaca()\r\n" + e.Message);
            }

            return konfigDobavljaca;
        } 
           

        public List<KonfigDobavljaca> GetKonfigDobavljacaList()
        {
            List<KonfigDobavljaca> listaKonfigDobavljaca = new List<KonfigDobavljaca>();

            using (KrolerContext db = new KrolerContext())
            {
                listaKonfigDobavljaca = db.KonfigDobavljaca.ToList();
            }

            return listaKonfigDobavljaca;
        }





    }
}

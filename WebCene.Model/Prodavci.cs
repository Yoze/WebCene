namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("infoekon_Bane.Prodavci")]
    public partial class Prodavci : INotifyPropertyChanged
    {

        public Prodavci()
        {
            KrolStavke = new HashSet<KrolStavke>();
        }
        
        private string _NazivProdavca;
        private string _SajtProdavca;
        private string _EponudaId;
        
        public int Id { get; set; }

        [StringLength(50)]
        public string NazivProdavca
        {
            get { return _NazivProdavca; }
            set
            {
                if (value != _NazivProdavca)
                {
                    _NazivProdavca = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(150)]
        public string SajtProdavca
        {
            get { return _SajtProdavca; }
            set
            {
                if (value != _SajtProdavca)
                {
                    _SajtProdavca = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(20)]        
        public string EponudaId
        {
            get { return _EponudaId; }
            set
            {
                if (value != _EponudaId)
                {
                    _EponudaId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public virtual ICollection<KrolStavke> KrolStavke { get; set; }

        /* INotifyPropertyChanged */
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

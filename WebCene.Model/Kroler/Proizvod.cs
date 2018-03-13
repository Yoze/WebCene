namespace WebCene.Model.Kroler
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("infoekon_Bane.Proizvod")]
    public partial class Proizvod : INotifyPropertyChanged
    {

        public Proizvod()
        {
            KrolStavke = new HashSet<KrolStavke>();
        }

        private int _Id;
        private string _ElSifraProizvoda;
        private string _ElEAN;
        private string _Naziv;
        private string _ElKat;
        private string _Brend;
        private string _Dobavljac;
        private string _ePonudaURL;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        
        [Required]
        [StringLength(8)]
        public string ElSifraProizvoda
        {
            get { return _ElSifraProizvoda; }
            set
            {
                if (value != _ElSifraProizvoda)
                {
                    _ElSifraProizvoda = value;
                    NotifyPropertyChanged();
                }
            }

        }

        [StringLength(20)]
        public string ElEAN
        {
            get { return _ElEAN; }
            set
            {
                if (value != _ElEAN)
                {
                    _ElEAN = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(40)]
        public string Naziv
        {
            get { return _Naziv; }
            set
            {
                if (value != _Naziv)
                {
                    _Naziv = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(20)]
        public string ElKat {
            get { return _ElKat; }
            set {
                if (value != _ElKat)
                {
                    _ElKat = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(50)]
        public string Brend {
            get { return _Brend; }
            set {
                if (value != _Brend)
                {
                    _Brend = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(50)]
        public string Dobavljac {
            get {return _Dobavljac; }
            set {
                if (value != _Dobavljac)
                {
                    _Dobavljac = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [StringLength(250)]
        public string ePonudaURL
        {
            get { return _ePonudaURL; }
            set {
                if (value != _ePonudaURL)
                {
                    _ePonudaURL = value;
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

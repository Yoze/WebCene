namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("infoekon_Bane.viewKrolStavke")]
    public partial class viewKrolStavke //:INotifyPropertyChanged
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string NazivProdavca { get; set; }

        public decimal? Cena { get; set; }



        //// INotifyPropertyChanged Interfejs
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}

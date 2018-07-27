namespace duzceSozluk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sikayet")]
    public partial class Sikayet
    {
        public int sikayetID { get; set; }

        public int? entryID { get; set; }

        public int? kullaniciID { get; set; }

        public DateTime? sikayet_tarihi { get; set; }

        public int? sikayetTurID { get; set; }

        [Column(TypeName = "text")]
        public string aciklama { get; set; }

        public bool? durum { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual SikayetTur SikayetTur { get; set; }
    }
}

namespace duzceSozluk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Begeni")]
    public partial class Begeni
    {
        public int begeniID { get; set; }

        public int? kullaniciID { get; set; }

        public int? entryID { get; set; }

        public DateTime? begeni_tarihi { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Entry Entry1 { get; set; }

        public virtual Entry Entry2 { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Kullanici Kullanici1 { get; set; }
    }
}

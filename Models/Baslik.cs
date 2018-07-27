namespace duzceSozluk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baslik")]
    public partial class Baslik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Baslik()
        {
            Entry = new HashSet<Entry>();
        }

        public int baslikID { get; set; }

        [Column("baslik")]
        [StringLength(100)]
        public string baslik { get; set; }

        public DateTime? olusturma_tarihi { get; set; }

        public bool? onay { get; set; }

        public int? olusturanID { get; set; }

        public int? turID { get; set; }

        [StringLength(200)]
        public string resim { get; set; }

        public virtual BaslikTur BaslikTur { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entry { get; set; }
    }
}

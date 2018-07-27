namespace duzceSozluk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entry")]
    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            Begeni = new HashSet<Begeni>();
            Begeni1 = new HashSet<Begeni>();
            Begeni2 = new HashSet<Begeni>();
            Sikayet = new HashSet<Sikayet>();
        }

        public int entryID { get; set; }

        public int? kullaniciID { get; set; }

        [Column(TypeName = "text")]
        public string icerik { get; set; }

        public DateTime? olusturma_tarihi { get; set; }

        public int? baslikID { get; set; }

        public bool? onay { get; set; }

        public int? alintiID { get; set; }

        [StringLength(200)]
        public string resim { get; set; }

        public virtual Baslik Baslik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Begeni> Begeni { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Begeni> Begeni1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Begeni> Begeni2 { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sikayet> Sikayet { get; set; }
    }
}

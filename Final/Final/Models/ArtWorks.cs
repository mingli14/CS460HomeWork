namespace Final.Views.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ArtWorks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArtWorks()
        {
            Classifications = new HashSet<Classifications>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int ArtistID { get; set; }

        public virtual Artists Artists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classifications> Classifications { get; set; }
    }
}

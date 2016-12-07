namespace Final.Views.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Classifications
    {
        public int ID { get; set; }

        public int ArtWorkID { get; set; }

        public int GenreID { get; set; }

        public virtual ArtWorks ArtWorks { get; set; }

        public virtual Genres Genres { get; set; }
    }
}

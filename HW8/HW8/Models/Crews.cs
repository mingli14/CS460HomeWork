namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Crews
    {
        public int ID { get; set; }

        public decimal Booty { get; set; }

        public int PirateID { get; set; }

        public int ShipID { get; set; }

        public virtual Pirates Pirates { get; set; }

        public virtual Ships Ships { get; set; }
    }
}

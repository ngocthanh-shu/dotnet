namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checkout")]
    public partial class Checkout
    {
        public int id { get; set; }

        public int? cartId { get; set; }

        public int? status { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [Column(TypeName = "ntext")]
        public string message { get; set; }

        public DateTime? datebegin { get; set; }
    }
}

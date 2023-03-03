namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        public int id { get; set; }

        public string name { get; set; }

        public double? price { get; set; }

        public string img { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public double? rate { get; set; }

        [StringLength(50)]
        public string tag { get; set; }

        public int? quantity { get; set; }

        public int? nquantity { get; set; }

        public int? status { get; set; }

        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }

        public int? categoryid { get; set; }

        public virtual category category { get; set; }
    }
}

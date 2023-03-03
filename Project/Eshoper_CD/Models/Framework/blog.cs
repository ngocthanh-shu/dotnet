namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blog")]
    public partial class blog
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(30)]
        public string img { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public string link { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }
    }
}

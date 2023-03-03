namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slide")]
    public partial class slide
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public string link { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }
    }
}

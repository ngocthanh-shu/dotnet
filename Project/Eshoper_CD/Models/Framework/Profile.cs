namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string username { get; set; }

        [StringLength(50)]
        public string fname { get; set; }

        [StringLength(50)]
        public string lname { get; set; }

        public int? gender { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(50)]
        public string phonenumber { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string postalcode { get; set; }

        [Column(TypeName = "ntext")]
        public string aboutme { get; set; }

        public string link { get; set; }

        [StringLength(50)]
        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? order { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }

        public virtual Account Account { get; set; }
    }
}

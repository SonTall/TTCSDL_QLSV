namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("showStudent")]
    public partial class showStudent
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string filecode { get; set; }

        [StringLength(30)]
        public string lastname { get; set; }

        [StringLength(30)]
        public string firstname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateofbirth { get; set; }

        public short? sex { get; set; }

        [StringLength(255)]
        public string placeofbirth { get; set; }

        [StringLength(255)]
        public string permanenaddress { get; set; }

        [StringLength(50)]
        public string nation { get; set; }

        [StringLength(50)]
        public string nationality { get; set; }

        [StringLength(50)]
        public string religion { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(12)]
        public string idcardnumber { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(50)]
        public string nameclass { get; set; }
    }
}

namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("showRelative")]
    public partial class showRelative
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateofbirth { get; set; }

        [StringLength(255)]
        public string workplace { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string placeofbirth { get; set; }

        [StringLength(50)]
        public string relationship { get; set; }

        [StringLength(30)]
        public string lastnamestudent { get; set; }

        [StringLength(30)]
        public string firstnamestudent { get; set; }
    }
}

namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("showChangeClass")]
    public partial class showChangeClass
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(30)]
        public string firstname { get; set; }

        [StringLength(30)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string oldclassname { get; set; }

        [StringLength(50)]
        public string newclassname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? daychange { get; set; }
    }
}

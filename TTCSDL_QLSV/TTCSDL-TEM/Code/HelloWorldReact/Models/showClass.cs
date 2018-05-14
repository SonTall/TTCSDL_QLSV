namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("showClass")]
    public partial class showClass
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string batchname { get; set; }

        [StringLength(50)]
        public string majorname { get; set; }

        [StringLength(50)]
        public string levelname { get; set; }
    }
}

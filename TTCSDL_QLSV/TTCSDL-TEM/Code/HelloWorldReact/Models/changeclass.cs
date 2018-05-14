namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("changeclass")]
    public partial class changeclass
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(10)]
        public string studentcode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? daychange { get; set; }

        [StringLength(10)]
        public string oldclasscode { get; set; }

        [StringLength(10)]
        public string newclasscode { get; set; }

        public virtual _class _class { get; set; }

        public virtual _class class1 { get; set; }

        public virtual student student { get; set; }
    }
}

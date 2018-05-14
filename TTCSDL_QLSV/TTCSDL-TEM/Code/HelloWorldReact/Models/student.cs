namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("student")]
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            changeclasses = new HashSet<changeclass>();
            relatives = new HashSet<relative>();
        }

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

        [StringLength(10)]
        public string classcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<changeclass> changeclasses { get; set; }

        public virtual _class _class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<relative> relatives { get; set; }
    }

    class StudentList
    {
        DBConnection db;
        public StudentList()
        {
            db = new DBConnection();
        }

        public List<student> ListAll()
        {
            dbSV db = new dbSV();
            return db.students.Where(x => x.code != "").ToList(); //Lấy danh sách batch. Giống với bên class
                                                                   // return db.relatives.ToList(); //Lấy danh sách batch. Giống với bên class
        }
    }
}

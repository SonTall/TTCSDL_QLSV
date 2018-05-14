namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("level")]
    public partial class level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public level()
        {
            classes = new HashSet<_class>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_class> classes { get; set; }
    }
    class LevelList
    {
        DBConnection db;
        public LevelList()
        {
            db = new DBConnection();
        }
        public List<level> ListAll()
        {
            dbSV db = new dbSV();
            return db.levels.Where(x => x.name != "").ToList();
        }

        //public string addClass(_class cl)
        //{
        //    string mess = "";
        //    SqlConnection con = db.getConnection();
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("addclass", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(new SqlParameter("@name", cl.name.Trim()));
        //    cmd.Parameters.Add(new SqlParameter("@levelcode", cl.levelcode.Trim()));
        //    cmd.Parameters.Add(new SqlParameter("@batchcode", cl.batchcode.Trim()));
        //    cmd.Parameters.Add(new SqlParameter("@majorcode", cl.majorcode.Trim()));
        //    int res = cmd.ExecuteNonQuery();
        //    if (res == 0)
        //    {
        //        mess = "Thêm thất bại";
        //    }
        //    else
        //    {
        //        mess = "Thêm thành công:" + cl.name;
        //    }
        //    con.Close();
        //    return mess;
        //}
    }
}

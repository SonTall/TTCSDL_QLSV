namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("major")]
    public partial class major
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public major()
        {
            classes = new HashSet<_class>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(10)]
        public string facilitycode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_class> classes { get; set; }

        public virtual facility facility { get; set; }
    }

    class MajorList
    {
        DBConnection db;
        public MajorList()
        {
            db = new DBConnection();
        }

        public List<relative> ListAll()
        {
            dbSV db = new dbSV();
            return db.relatives.Where(x => x.name != "").ToList(); //Lấy danh sách batch. Giống với bên class
                                                                   // return db.relatives.ToList(); //Lấy danh sách batch. Giống với bên class
        }

        public string Insert(major obj)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("addmajor", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.name;
            //cmd.Parameters.Add("@dateofbirth", SqlDbType.DateTime).Value = obj.dateofbirth;
            //cmd.Parameters.Add("@workplace", SqlDbType.NVarChar).Value = obj.name;
            //cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = obj.address;
            //cmd.Parameters.Add("@placeofbirth", SqlDbType.NVarChar).Value = obj.placeofbirth;
            //cmd.Parameters.Add("@relationship", SqlDbType.NVarChar).Value = obj.relationship;
            //cmd.Parameters.Add("@studentcode", SqlDbType.VarChar).Value = obj.studentcode;
            //cmd.Parameters.Add("@lockdate", SqlDbType.DateTime).Value = obj.LOCKDATE;
            if (cmd.ExecuteNonQuery() == 0)
            {
                mess = "Thêm thất bại";
            }
            else
            {
                mess = "Thêm thành công:" + obj.name;
            }
            con.Close();
            return mess;
        }
    }
}

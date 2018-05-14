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

    [Table("facility")]
    public partial class facility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public facility()
        {
            majors = new HashSet<major>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<major> majors { get; set; }
    }
    class FacilityList
    {
        DBConnection db;
        public FacilityList()
        {
            db = new DBConnection();
        }

        public List<facility> ListAll()
        {
            dbSV db = new dbSV();
            return db.facilities.Where(x => x.name != "").ToList(); //Lấy danh sách batch. Giống với bên class
                                                                // return db.relatives.ToList(); //Lấy danh sách batch. Giống với bên class
        }

        public List<facility> getData(string code = "", string name = "")
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("seachFacility", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            cmd.Parameters.Add(new SqlParameter("@name", name.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<facility> list = new List<facility>();
            facility tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new facility();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.name = ds.Rows[i]["name"].ToString();

                list.Add(tmC);
            }
            con.Close();
            return list;
        }
    }
}

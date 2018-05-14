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

        public List<major> ListAll()
        {
            dbSV db = new dbSV();
            return db.majors.Where(x => x.name != "").ToList(); //Lấy danh sách batch. Giống với bên class
                                                                   // return db.relatives.ToList(); //Lấy danh sách batch. Giống với bên class
        }

        public List<showMajor> getData(string code = null, string name = null)
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("seachMajor", con);
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            if (code == null) code = "";
            if (name == null) name = "";
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            cmd.Parameters.Add(new SqlParameter("@name", name.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<showMajor> list = new List<showMajor>();
            showMajor tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new showMajor();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.name = ds.Rows[i]["name"].ToString();
                tmC.facilityname = ds.Rows[i]["facilityname"].ToString();
                list.Add(tmC);
            }
            con.Close();
            return list;
        }

        public string Insert(major obj)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("addmajor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = obj.code;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.name;
            cmd.Parameters.Add("@facilitycode", SqlDbType.VarChar).Value = obj.facilitycode;
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


        public string UpdateMajor(string code, major obj)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("updatemajor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            cmd.Parameters.Add("@newcode", SqlDbType.VarChar).Value = obj.code;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.name;
            cmd.Parameters.Add("@facilitycode", SqlDbType.VarChar).Value = obj.facilitycode;
            if (cmd.ExecuteNonQuery() == 0)
            {
                mess = "Sửa thất bại";
            }
            else
            {
                mess = "Sửa thành công:" + obj.name;
            }
            con.Close();
            return mess;
        }

        public string DeleteMajorByCode(string code)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("delMajor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            if (cmd.ExecuteNonQuery() == 0)
            {
                mess = "Xóa thất bại";
            }
            else
            {
                mess = "Xóa thành công:";
            }
            con.Close();
            return mess;
        }

        public major GetMajorByCode(string code)
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("seachCodeMajor", con);
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            major tmC = new major();
            tmC.code = ds.Rows[0]["code"].ToString();
            tmC.name = ds.Rows[0]["name"].ToString();
            tmC.facilitycode = ds.Rows[0]["facilitycode"].ToString();
            //Chuyển dataTable thành dạng List
            con.Close();
            return tmC;
        }

        public List<showMajor> GetMajor(string code = null, string name = null) //Lấy danh sách lớp đưa vào dạng list
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("searchMajor", con);
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            cmd.Parameters.Add(new SqlParameter("@name", name.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<showMajor> lMajor = new List<showMajor>();
            showMajor tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new showMajor();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.name = ds.Rows[i]["name"].ToString();
                tmC.facilityname = ds.Rows[i]["facilityname"].ToString();
                lMajor.Add(tmC);
            }
            con.Close();
            return lMajor;
        }
    }
}

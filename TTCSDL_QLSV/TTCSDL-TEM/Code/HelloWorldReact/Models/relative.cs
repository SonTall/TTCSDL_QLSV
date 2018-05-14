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

    [Table("relative")]
    public partial class relative
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

        [StringLength(10)]
        public string studentcode { get; set; }

        public virtual student student { get; set; }
    }

    class RelativeList
    {
        DBConnection db;
        public RelativeList()
        {
            db = new DBConnection();
        }

        public List<relative> ListAll()
        {
            dbSV db = new dbSV();
            return db.relatives.Where(x => x.name != "").ToList(); //Lấy danh sách batch. Giống với bên class
                                                                   // return db.relatives.ToList(); //Lấy danh sách batch. Giống với bên class
        }

        public string Insert(relative obj)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("addrelative", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.name;
            cmd.Parameters.Add("@dateofbirth", SqlDbType.DateTime).Value = obj.dateofbirth;
            cmd.Parameters.Add("@workplace", SqlDbType.NVarChar).Value = obj.name;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = obj.address;
            cmd.Parameters.Add("@placeofbirth", SqlDbType.NVarChar).Value = obj.placeofbirth;
            cmd.Parameters.Add("@relationship", SqlDbType.NVarChar).Value = obj.relationship;
            cmd.Parameters.Add("@studentcode", SqlDbType.VarChar).Value = obj.studentcode;
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

        public string UpdateRelative(string code, relative obj)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("updaterelative", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = obj.code;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.name;
            cmd.Parameters.Add("@dateofbirth", SqlDbType.DateTime).Value = obj.dateofbirth;
            cmd.Parameters.Add("@workplace", SqlDbType.NVarChar).Value = obj.workplace;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = obj.address;
            cmd.Parameters.Add("@placeofbirth", SqlDbType.NVarChar).Value = obj.placeofbirth;
            cmd.Parameters.Add("@relationship", SqlDbType.NVarChar).Value = obj.relationship;
            cmd.Parameters.Add("@studentcode", SqlDbType.VarChar).Value = obj.studentcode;
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

        public string DeleteRelativeByCode(string code)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("delRelativeByCode", con);
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

        public relative GetRelativeByCode(string code)
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("seachCodeRelative", con);
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            relative tmC = new relative();
            tmC.code = ds.Rows[0]["code"].ToString();
            tmC.name = ds.Rows[0]["name"].ToString();
            tmC.dateofbirth = Convert.ToDateTime(ds.Rows[0]["dateofbirth"]);
            tmC.workplace = ds.Rows[0]["workplace"].ToString();
            tmC.address = ds.Rows[0]["address"].ToString();
            tmC.placeofbirth = ds.Rows[0]["placeofbirth"].ToString();
            tmC.relationship = ds.Rows[0]["relationship"].ToString();
            tmC.studentcode = ds.Rows[0]["studentcode"].ToString();
            //Chuyển dataTable thành dạng List
            con.Close();
            return tmC;
        }

        public List<showRelative> GetRelative(string code = null, string name = null, string codest = null) //Lấy danh sách lớp đưa vào dạng list
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("seachRelative", con);
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            if (code == null) code = "";
            if (name == null) name = "";
            if (codest == null) codest = "";
            cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            cmd.Parameters.Add(new SqlParameter("@name", name.Trim()));
            cmd.Parameters.Add(new SqlParameter("@codest", codest.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<showRelative> lRelative = new List<showRelative>();
            showRelative tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new showRelative();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.name = ds.Rows[i]["name"].ToString();
                tmC.dateofbirth = Convert.ToDateTime(ds.Rows[i]["dateofbirth"]);
                tmC.workplace = ds.Rows[i]["workplace"].ToString();
                tmC.address = ds.Rows[i]["address"].ToString();
                tmC.placeofbirth = ds.Rows[i]["placeofbirth"].ToString();
                tmC.relationship = ds.Rows[i]["relationship"].ToString();
                tmC.lastnamestudent = ds.Rows[i]["lastnamestudent"].ToString();
                tmC.firstnamestudent = ds.Rows[i]["firstnamestudent"].ToString();
                lRelative.Add(tmC);
            }
            con.Close();
            return lRelative;
        }
    }
}

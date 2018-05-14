namespace HelloWorldReact.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    //Phần này định nghĩa database
    [Table("class")]
    public partial class _class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public _class()
        {
            changeclasses = new HashSet<changeclass>();
            changeclasses1 = new HashSet<changeclass>();
            students = new HashSet<student>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(10)]
        public string batchcode { get; set; }

        [StringLength(10)]
        public string levelcode { get; set; }

        [StringLength(10)]
        public string majorcode { get; set; }

        public virtual batch batch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<changeclass> changeclasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<changeclass> changeclasses1 { get; set; }

        public virtual level level { get; set; }

        public virtual major major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student> students { get; set; }
    }
    //Hàm xử lý database
    class ClassList{
        DBConnection db;
        public ClassList()
        {
            db = new DBConnection(); //Trong models có class kết nối db
        }
        public List<_class> getClass(string code) //Lấy danh sách lớp đưa vào dạng list
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from class",con);
            DataTable ds = new DataTable();
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<_class> lClass = new List<_class>();
            _class tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new _class();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.name = ds.Rows[i]["name"].ToString();
                tmC.batchcode = ds.Rows[i]["batchcode"].ToString();
                tmC.majorcode = ds.Rows[i]["majorcode"].ToString();
                tmC.levelcode = ds.Rows[i]["levelcode"].ToString();
                lClass.Add(tmC);
            }
            con.Close();
            return lClass;
        }
        //Hàm thêm lớp học
        public string addClass(_class cl)
        {
            string mess = "";
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("addclass", con); //Sử dụng proc addclass đã tạo trong SQL sever
            cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            cmd.Parameters.Add(new SqlParameter("@code", cl.code.Trim()));  //Hàm gán giá trị lấy từ đối tượng vào giá trị khai báo trong proc
            cmd.Parameters.Add(new SqlParameter("@name", cl.name.Trim()));  //@code ... là các giá trị khai báo trong proc
            cmd.Parameters.Add(new SqlParameter("@levelcode", cl.levelcode.Trim()));
            cmd.Parameters.Add(new SqlParameter("@batchcode", cl.batchcode.Trim()));
            cmd.Parameters.Add(new SqlParameter("@majorcode", cl.majorcode.Trim()));
            int res = cmd.ExecuteNonQuery();//Thực hiện câu lệnh. trả về số rows thực hiện thành công
            if (res == 0)
            {
                mess = "Thêm thất bại";
            }
            else
            {
                mess = "Thêm thành công:" + cl.name;
            }
            con.Close();
            return mess;
        }

    
    }
}

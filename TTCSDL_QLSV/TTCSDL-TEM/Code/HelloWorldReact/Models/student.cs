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
        public List<student> ListAll(string code = null, string name = null) //Lấy danh sách lớp đưa vào dạng list
        {
            SqlConnection con = db.getConnection();
            con.Open();
            //Sử dụng proc addclass đã tạo trong SQL sever
            SqlCommand cmd = new SqlCommand("SELECT * from student", con);
            //cmd.CommandType = CommandType.StoredProcedure; //Xác định khai báo trên là proc nằm trong StoredProcedure trong SQL
            //cmd.Parameters.Add(new SqlParameter("@code", code.Trim()));
            //cmd.Parameters.Add(new SqlParameter("@name", name.Trim()));
            DataTable ds = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds); //Ds lớp lưu đưới dạng dataTable
            List<student> lStudent = new List<student>();
            student tmC;
            //Chuyển dataTable thành dạng List
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                tmC = new student();
                tmC.code = ds.Rows[i]["code"].ToString();
                tmC.filecode = ds.Rows[i]["filecode"].ToString();
                tmC.firstname = ds.Rows[i]["firstname"].ToString();
                tmC.lastname = ds.Rows[i]["lastname"].ToString();
                tmC.dateofbirth = Convert.ToDateTime(ds.Rows[i]["dateofbirth"].ToString());
                tmC.sex = Convert.ToInt16(ds.Rows[i]["sex"].ToString());
                tmC.placeofbirth = ds.Rows[i]["placeofbirth"].ToString();
                tmC.permanenaddress = ds.Rows[i]["permanenaddress"].ToString();
                tmC.nation = ds.Rows[i]["nation"].ToString();
                tmC.nationality = ds.Rows[i]["nationality"].ToString();
                tmC.religion = ds.Rows[i]["religion"].ToString();
                tmC.email = ds.Rows[i]["email"].ToString();
                tmC.phone = ds.Rows[i]["phone"].ToString();
                tmC.idcardnumber = ds.Rows[i]["idcardnumber"].ToString();
                tmC.note = ds.Rows[i]["note"].ToString();
                tmC.classcode = ds.Rows[i]["classcode"].ToString();


                lStudent.Add(tmC);
            }
            con.Close();
            return lStudent;
        }


        }
    }

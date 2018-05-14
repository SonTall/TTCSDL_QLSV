using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceQLSV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string strQuery = @"Data Source=DESKTOP-NJTFCU0;Initial Catalog=TTCSDL;Integrated Security=True";
        public string InsertStudent(student st)
        {
            string mess="";
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("addstudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@filecode", st.Filecode.Trim()));
            cmd.Parameters.Add(new SqlParameter("@lastname", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@firstname", st.Firstname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@dateofbirth", st.Dateofbirth));
            cmd.Parameters.Add(new SqlParameter("@sex", st.Sex));
            cmd.Parameters.Add(new SqlParameter("@placeofbirth", st.Placeofbirth.Trim()));
            cmd.Parameters.Add(new SqlParameter("@permanenaddress", st.Permanenaddress.Trim()));
            cmd.Parameters.Add(new SqlParameter("@nation", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@nationality", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@religion", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@email", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@phone", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@idcardnumber", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@note", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@classcode", st.Lastname.Trim()));
            int res = cmd.ExecuteNonQuery();
            if(res == 0)
            {
                mess = "Thêm thất bại";
            }
            else
            {
                mess = "Thêm thành công:" + st.Firstname;
            }
            con.Close();
            return mess;
        }

        public List<student> SelectStudent()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("addstudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            List<student> ls = new List<student>();
            foreach (DataRow item in ds.Rows)
            {
                student st1 = new student(item);
                ls.Add(st1);
            }
            con.Close();
            return ls;
        }

        public bool Deletestudent(int code)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delStudentByCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@code", code));
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res == 0) return false;
            else return true;
        }

        public string UpdateStudent(student st)
        {
            string mess = "";
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("updatestudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@code", st.Code.Trim()));
            cmd.Parameters.Add(new SqlParameter("@filecode", st.Filecode.Trim()));
            cmd.Parameters.Add(new SqlParameter("@lastname", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@firstname", st.Firstname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@dateofbirth", st.Dateofbirth));
            cmd.Parameters.Add(new SqlParameter("@sex", st.Sex));
            cmd.Parameters.Add(new SqlParameter("@placeofbirth", st.Placeofbirth.Trim()));
            cmd.Parameters.Add(new SqlParameter("@permanenaddress", st.Permanenaddress.Trim()));
            cmd.Parameters.Add(new SqlParameter("@nation", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@nationality", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@religion", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@email", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@phone", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@idcardnumber", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@note", st.Lastname.Trim()));
            cmd.Parameters.Add(new SqlParameter("@classcode", st.Lastname.Trim()));
            int res = cmd.ExecuteNonQuery();
            if(res == 0)
            {
                mess = "Cập nhật không thành công";
            }
            else
            {
                mess = "Cập nhật thành công";
            }
            con.Close();
            return mess;
        }
    }
        
}

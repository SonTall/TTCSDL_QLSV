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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Làm việc với bảng student
        [OperationContract]
        string InsertStudent(student st);

        [OperationContract]
        List<student> SelectStudent();

        [OperationContract]
        bool Deletestudent(int code);

        [OperationContract]
        string UpdateStudent(student st);

        ////Làm việc với bảng facility
        //[OperationContract]
        //string InsertFacility(facility fc);
        //[OperationContract]
        //List<facility> SelectFacility();
        //[OperationContract]
        //bool DeleteFacility(facility fc);
        //[OperationContract]
        //string UpdateFacility(facility fc);
        ////Làm việc với bảng batch
        //[OperationContract]
        //string InsertBatch(batch b);
        //[OperationContract]
        //List<batch> SelectBatch();
        //[OperationContract]
        //bool DeleteBatch(batch b);
        //[OperationContract]
        //string UpdateBatch(batch b);

        ////Làm việc với bảng level
        //[OperationContract]
        //string InsertLevel(level lv);
        //[OperationContract]
        //List<level> SelectLevel();
        //[OperationContract]
        //bool DeleteLevel(level lv);
        //[OperationContract]
        //string UpdateLevel(level lv);

        ////Lmaf việc với bảng major
        //[OperationContract]
        //string InsertMajor(major mj);
        //[OperationContract]
        //List<major> SelectMajor();
        //[OperationContract]
        //bool DeleteMajor(major mj);
        //[OperationContract]
        //string UpdateMajor(major mj);

        ////Làm việc với bảng class
        //[OperationContract]
        //string InsertClass(classs cl);
        //[OperationContract]
        //List<classs> SelectClass();
        //[OperationContract]
        //bool DeleteClass(classs cl);
        //[OperationContract]
        //string UpdateClass(classs cl);

        ////Làm việc với bảng relative
        //[OperationContract]
        //string InsertRelative(relative rl);
        //[OperationContract]
        //List<relative> SelectRelative();
        //[OperationContract]
        //bool DeleteRelative(relative rl);
        //[OperationContract]
        //string UpdateRelative(relative rl);

        ////Làm việc với bảng changeclass
        //[OperationContract]
        //string InsertChangeClass(changeclass cc);
        //[OperationContract]
        //List<changeclass> SelectChangeClass();
        //[OperationContract]
        //bool DeleteChangeClass(changeclass cc);
        //[OperationContract]
        //string UpdateChangeClass(changeclass cc);
        
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class facility{
        string code;
        string name;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }

        public facility(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
        }
    }
    [DataContract]
    public class batch
    {
        string code;
        string name;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        public batch(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
        }
    }
    [DataContract]
    public class level
    {
        string code;
        string name;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        public level(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
        }
    }
    [DataContract]
    public class major
    {
        string code;
        string name;
        string facilitycode;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Facilitycode { get => facilitycode; set => facilitycode = value; }
        public major(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
            this.Facilitycode = row["facilitycode"].ToString();
        }
    }
    [DataContract]
    public class classs
    {
        string code;
        string name;
        string batchcode;
        string majorcode;
        string levelcode;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Batchcode { get => batchcode; set => batchcode = value; }
        [DataMember]
        public string Majorcode { get => majorcode; set => majorcode = value; }
        [DataMember]
        public string Levelcode { get => levelcode; set => levelcode = value; }
        public classs(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
            this.Batchcode = row["batchcode"].ToString();
            this.Majorcode = row["majorcode"].ToString();
            this.Levelcode = row["levelcode"].ToString();
        }
    }
    [DataContract]
    public class relative
    {
        string code;
        string name;
        DateTime dateofbirth;
        string workplace;
        string address;
        string placeofbirth;
        string relationship;
        string studentcode;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        [DataMember]
        public string Workplace { get => workplace; set => workplace = value; }
        [DataMember]
        public string Address { get => address; set => address = value; }
        [DataMember]
        public string Placeofbirth { get => placeofbirth; set => placeofbirth = value; }
        [DataMember]
        public string Relationship { get => relationship; set => relationship = value; }
        [DataMember]
        public string Studentcode { get => studentcode; set => studentcode = value; }
        public relative(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Name = row["name"].ToString();
            this.Dateofbirth = DateTime.Parse(row["dateofbirth"].ToString());
            this.Workplace = row["workplace"].ToString();
            this.Address = row["address"].ToString();
            this.Placeofbirth = row["placeofbirth"].ToString();
            this.Relationship = row["relationship"].ToString();
            this.Studentcode = row["studentcode"].ToString();
        }
    }
    [DataContract]
    public class student
    {
        string code;
        string filecode;
        string lastname;
        string firstname;
        DateTime dateofbirth;
        int sex;
        string placeofbirth;
        string permanenaddress;
        string nation;
        string nationality;
        string religion;
        string email;
        string phone;
        string idcardnumber;
        string note;
        string classcode;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Filecode { get => filecode; set => filecode = value; }
        [DataMember]
        public string Lastname { get => lastname; set => lastname = value; }
        [DataMember]
        public string Firstname { get => firstname; set => firstname = value; }
        [DataMember]
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        [DataMember]
        public int Sex { get => sex; set => sex = value; }
        [DataMember]
        public string Placeofbirth { get => placeofbirth; set => placeofbirth = value; }
        [DataMember]
        public string Permanenaddress { get => permanenaddress; set => permanenaddress = value; }
        [DataMember]
        public string Nation { get => nation; set => nation = value; }
        [DataMember]
        public string Nationality { get => nationality; set => nationality = value; }
        [DataMember]
        public string Religion { get => religion; set => religion = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public string Phone { get => phone; set => phone = value; }
        [DataMember]
        public string Idcardnumber { get => idcardnumber; set => idcardnumber = value; }
        [DataMember]
        public string Note { get => note; set => note = value; }
        [DataMember]
        public string Classcode { get => classcode; set => classcode = value; }
        public student(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Filecode = row["filecode"].ToString();
            this.Lastname = row["lastname"].ToString();
            this.Firstname = row["firstname"].ToString();
            this.Dateofbirth = DateTime.Parse(row["dateofbirth"].ToString());
            this.Sex = Int32.Parse(row["sex"].ToString());
            this.Placeofbirth = row["placeofbirth"].ToString();
            this.Permanenaddress = row["permanenaddress"].ToString();
            this.Nation = row["nation"].ToString();
            this.Nationality = row["nationality"].ToString();
            this.Religion = row["religion"].ToString();
            this.Email = row["email"].ToString();
            this.Phone = row["phone"].ToString();
            this.Idcardnumber = row["idcardnumber"].ToString();
            this.Note = row["note"].ToString();
            this.Classcode = row["classcode"].ToString();
        }
    }
    [DataContract]
    public class changeclass
    {
        string code;
        string studentcode;
        DateTime daychange;
        string oldclasscode;
        string newclasscode;
        [DataMember]
        public string Code { get => code; set => code = value; }
        [DataMember]
        public string Studentcode { get => studentcode; set => studentcode = value; }
        [DataMember]
        public DateTime Daychange { get => daychange; set => daychange = value; }
        [DataMember]
        public string Oldclasscode { get => oldclasscode; set => oldclasscode = value; }
        [DataMember]
        public string Newclasscode { get => newclasscode; set => newclasscode = value; }
        public changeclass(DataRow row)
        {
            this.Code = row["code"].ToString();
            this.Studentcode = row["studentcode"].ToString();
            this.Oldclasscode = row["oldclasscode"].ToString();
            this.Newclasscode = row["newclasscode"].ToString();
            this.Daychange = DateTime.Parse(row["daychange"].ToString());
        }
    }
}

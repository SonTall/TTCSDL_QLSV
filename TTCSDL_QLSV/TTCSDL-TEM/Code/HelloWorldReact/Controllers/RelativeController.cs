using HelloWorldReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldReact.Controllers
{
    public class RelativeController : Controller
    {
        // GET: Relative
        public ActionResult Index()
        {
            RelativeList relativeList = new RelativeList();
            var obj = relativeList.ListAll();
            return View(obj);
        }

        public ActionResult Create()
        {
            //dbSV dbSV = new dbSV();
            StudentList studentList = new StudentList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            List<student> obj = studentList.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            //var obj = dbSV.students.ToList();
            ViewBag.studentCode = new SelectList(obj, "code", "name"); //Đưa viewBag vào view
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(_class cl)
        {
            //Phải khởi tạo lại viewBag mới lấy được dữ liệu
            BatchList Batchlist = new BatchList();
            LevelList Levellist = new LevelList();
            List<batch> obj = Batchlist.ListAll();
            List<level> obj1 = Levellist.ListAll();
            ViewBag.batchCode = new SelectList(obj, "code", "name");
            ViewBag.levelCode = new SelectList(obj1, "code", "name");
            try
            {
                // TODO: Add insert logic here
                ClassList Classlist = new ClassList();
                Classlist.addClass(cl); //Gọi đến hàm addClass trong class ClassList trong models
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
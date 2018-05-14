using HelloWorldReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldReact.Controllers
{
    public class RelativeController : Controller
    {
        // GET: Relative
        public ActionResult Index(string code, string name, string codest)
        {
            RelativeList relativeList = new RelativeList();
            //var obj = relativeList.GetRelative(id, name, idst);
            var obj = relativeList.GetRelative(code, name, codest);
            return View(obj);
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    KhachHang khachHang = db.KhachHangs.Find(id);
        //    if (khachHang == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(khachHang);
        //}

        public ActionResult Create()
        {
            StudentList studentList = new StudentList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            List<student> obj = studentList.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            ViewBag.studentCode = new SelectList(obj, "code", "code"); //Đưa viewBag vào view
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(relative cl)
        {
            StudentList studentList = new StudentList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            List<student> obj = studentList.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            ViewBag.studentCode = new SelectList(obj, "code", "code"); //Đưa viewBag vào view
            try
            {
                // TODO: Add insert logic here
                RelativeList relativeList = new RelativeList();
                relativeList.Insert(cl); //Gọi đến hàm addClass trong class ClassList trong models
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            RelativeList relativeList = new RelativeList();
            relative _relative = relativeList.GetRelativeByCode(id);

            StudentList studentList = new StudentList();
            
           
            var obj = studentList.ListAll();
            ViewBag.studentCode = new SelectList(obj, "code", "code", _relative.studentcode);
           
            return View(_relative);
        }

        [HttpPost]
        public ActionResult Edit(string id, relative cl)
        {
            StudentList studentList = new StudentList();
            var obj = studentList.ListAll();
            ViewBag.studentCode = new SelectList(obj, "code", "code");
            try
            {
                // TODO: Add insert logic here
                RelativeList relativeList = new RelativeList();
                relativeList.UpdateRelative(id, cl); //Gọi đến hàm addClass trong class ClassList trong models
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            RelativeList relativeList = new RelativeList();
            relativeList.DeleteRelativeByCode(id);
            return RedirectToAction("Index");
        }
    }
}
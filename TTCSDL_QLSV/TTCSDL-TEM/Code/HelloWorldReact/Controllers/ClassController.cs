using HelloWorldReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldReact.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            ClassList Classlist = new ClassList();
            List<_class> obj = Classlist.getClass(string.Empty);
            return View(obj);
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Class/Create
        public ActionResult Create()
        {

            BatchList Batchlist = new BatchList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            LevelList Levellist = new LevelList();
            List<batch> obj = Batchlist.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            List<level> obj1 = Levellist.ListAll();
            ViewBag.batchCode = new SelectList(obj, "code", "name"); //Đưa viewBag vào view
            ViewBag.levelCode = new SelectList(obj1, "code", "name");
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

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

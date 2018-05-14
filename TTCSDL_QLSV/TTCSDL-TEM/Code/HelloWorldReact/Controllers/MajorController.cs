using HelloWorldReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldReact.Controllers
{
    public class MajorController : Controller
    {
        // GET: Major
        public ActionResult Index(string id, string name)
        {
            MajorList majorList = new MajorList();
            var obj = majorList.getData(id, name);
            return View(obj);
        }

        public ActionResult Create()
        {
            FacilityList facilityList = new FacilityList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            var obj = facilityList.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            ViewBag.facilityCode = new SelectList(obj, "code", "name"); //Đưa viewBag vào view
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(major cl)
        {
            FacilityList facilityList = new FacilityList(); //Khởi tạo biếm có giá trị là class được khai báo trong models/batch
            var obj = facilityList.ListAll(); //Gọi hàm listall khai báo trong class trong models lấy ra danh sách batch
            ViewBag.facilityCode = new SelectList(obj, "code", "name"); //Đưa viewBag vào view
            //try
            //{
                // TODO: Add insert logic here
                MajorList majorList = new MajorList();
                majorList.Insert(cl); //Gọi đến hàm addClass trong class ClassList trong models
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        public ActionResult Edit(string id)
        {
            MajorList majorList = new MajorList();
            major _majorList = majorList.GetMajorByCode(id);

            FacilityList facilityList = new FacilityList();


            var obj = facilityList.ListAll();
            ViewBag.facilityCode = new SelectList(obj, "code", "name", _majorList.facilitycode);

            return View(_majorList);
        }

        [HttpPost]
        public ActionResult Edit(string id, major cl)
        {
            FacilityList facilityList = new FacilityList();


            var obj = facilityList.ListAll();
            ViewBag.facilityCode = new SelectList(obj, "code", "name");
            //try
            //{
                // TODO: Add insert logic here
                MajorList majorList = new MajorList();
                majorList.UpdateMajor(id, cl); //Gọi đến hàm addClass trong class ClassList trong models
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        public ActionResult Delete(string id)
        {
            MajorList majorList = new MajorList();
            majorList.DeleteMajorByCode(id);
            return RedirectToAction("Index");
        }
    }
}
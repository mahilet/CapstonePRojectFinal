using JeffriesDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahaletWebsiteMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentsService service = new StudentsService();
            List<Student> students = service.GetAll();
            return View(students);
          
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            StudentsService service = new StudentsService();
            Student student = service.Get(id);
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here
                StudentsService service = new StudentsService();
                Student student = new Student();
                //{
                //    CourseId = int.Parse(collection[1]),
                //    LastName = collection[2],
                //    FirstName = collection[3],
                //    Campus = byte.Parse(collection[4]),
                //    Email = collection[5]

                //};

                student.CourseId = int.Parse(collection[1]);
                student.LastName = collection[2];
                student.FirstName = collection[3];
                student.Campus = byte.Parse(collection[4]);
                student.Email = collection[5];


                Student newStudent = service.Add(student);

                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {

            StudentsService service = new StudentsService();
            Student student = service.Get(id);

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                StudentsService service = new StudentsService();
                Student student = new Student()
                {
                    StudentId = id,
                    CourseId = Convert.ToInt32(collection["CourseId"]),
                    LastName = collection["LastName"],
                    FirstName = collection["FirstName"],
                    Campus = Convert.ToByte(collection["Campus"]),
                    Email = collection["Email"]
                };

                bool succeeded = service.Update(student);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            StudentsService service = new StudentsService();
            Student student = service.Get(id);
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                StudentsService service = new StudentsService();
                service.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

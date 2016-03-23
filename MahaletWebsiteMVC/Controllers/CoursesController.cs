using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeffriesDataLibrary;

namespace MahaletWebsiteMVC.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            CoursesService service = new CoursesService();
            List<Course> courses = service.GetAll();
            return View(courses);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            CoursesService service = new CoursesService();
            Course course = service.Get(id);
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CoursesService service = new CoursesService();

                Course course = new Course() {
                    Title = collection[1],
                    Description = collection[2]
                   
                };

                Course newCourse = service.Add(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            CoursesService service = new CoursesService();
            Course course = service.Get(id);

            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CoursesService service = new CoursesService();

                Course course = new Course() {
                    CourseId = id,
                    Title = collection[2],
                    Description = collection[3]
                };

                bool succeeded = service.Update(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            CoursesService service = new CoursesService();
            Course course = service.Get(id);

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CoursesService service = new CoursesService();
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

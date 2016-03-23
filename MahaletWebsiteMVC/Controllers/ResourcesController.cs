using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JeffriesDataLibrary;
using System.Web.Mvc;


namespace MahaletWebsiteMVC.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        public ActionResult Index()
        {
            ResourcesService service = new ResourcesService();
            List<Resource> resources = service.GetAll();
            return View(resources);
            
        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            ResourcesService service = new ResourcesService();
            Resource resource = service.Get(id);
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
         
                ResourcesService service = new ResourcesService();
                Resource resource = new Resource() {
                   
                    CourseId = Convert.ToInt32(collection["CourseId"]),
                    FileName = collection["FileName"],
                    FileType = collection["FileType"],
                    FileBinary = new byte[0]
                };
                Resource newResource = service.Add(resource);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            ResourcesService service = new ResourcesService();
            Resource rsource = service.Get(id);
                 
            return View(rsource);
        }

        // POST: Resources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
                ResourcesService service = new ResourcesService();
                Resource resource = new Resource()
                {
                    ResourceId = id,
                    //CourseId = int.Parse(collection["CourseId"]),
                    CourseId = Convert.ToInt32(collection["CourseId"]),
                    FileName = collection["FileName"],
                    FileType = collection["FileType"],
                    //FileBinary =Convert.ToByte[](collection[4]),

                };

                bool succeeded = service.Update(resource);

                // TODO: Add update logic here

                return RedirectToAction("Index");
            
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            ResourcesService service = new ResourcesService();
            Resource resource = service.Get(id);
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ResourcesService service = new ResourcesService();
                service.Remove(id);

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

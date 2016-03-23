using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeffriesDataLibrary;

namespace MahaletWebsiteMVC.Controllers
{
    public class VBlogsController : Controller
    {
        // GET: VBlogs
        public ActionResult Index()
        {
            VBlogsService service = new VBlogsService();
            List<VBlog> vBlogs = service.GetAll();
            return View(vBlogs);
        }

        // GET: VBlogs/Details/5
        public ActionResult Details(int id)
        {
            VBlogsService service = new VBlogsService();
            VBlog vBlog = service.Get(id);
            return View(vBlog);

        }

        // GET: VBlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VBlogs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
              VBlogsService service = new VBlogsService();

                VBlog vBlog = new VBlog()
                {
                    Title = collection["Title"],
                    Description = collection["Description"],
                    FileName = collection["FileName"],
                    FileType = collection["FileType"],
                    FileBinary = new byte[0],
                    DatePosted = Convert.ToDateTime(collection["DatePosted"])
                };

                VBlog newVBlog = service.Add(vBlog);

                return RedirectToAction("Index");
          
        }

        // GET: VBlogs/Edit/5
        public ActionResult Edit(int id)
        {
            VBlogsService service = new VBlogsService();
            VBlog vBlog = service.Get(id);
            return View(vBlog);
        }

        // POST: VBlogs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                VBlogsService service = new VBlogsService();

                VBlog vBlog = new VBlog()
                {
                    VBlogId = Convert.ToInt32(collection["VBlogId"]),
                    Title = collection["Title"],
                    Description = collection["Description"],
                    FileName = collection["FileName"],
                    FileType = collection["FileType"],
                    FileBinary = new byte[0],
                    DatePosted = Convert.ToDateTime(collection["DatePosted"])

                };
                bool succeeded = service.Update(vBlog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VBlogs/Delete/5
        public ActionResult Delete(int id)
        {
            VBlogsService service = new VBlogsService();
            VBlog vBlog = service.Get(id);
            return View(vBlog);
        }

        // POST: VBlogs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                VBlogsService service = new VBlogsService();
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

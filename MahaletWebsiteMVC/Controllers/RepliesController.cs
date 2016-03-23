using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JeffriesDataLibrary;
using System.Web.Mvc;


namespace MahaletWebsiteMVC.Controllers
{
       public class RepliesController : Controller
    {
        // GET: Replies
        public ActionResult Index()
        {
            RepliesService service = new RepliesService();
            List<Reply> replies = service.GetAll();
            return View(replies);
        }

        // GET: Replies/Details/5
        public ActionResult Details(int id)
        {
            RepliesService service = new RepliesService();
            Reply reply = service.Get(id);
            return View(reply);
        }

        // GET: Replies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Replies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
                RepliesService service = new RepliesService();

                Reply reply = new Reply()
                {

                    CommentId = Convert.ToInt32(collection["CommentId"]),
                    Name = collection["Name"],
                    Text = collection["Text"],
                    DateReplied = Convert.ToDateTime(collection["DateReplied"])

                };

                Reply newReply = service.Add(reply);

                return RedirectToAction("Index");
            
          
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int id)
        {
            RepliesService service = new RepliesService();
            Reply reply = service.Get(id);
            return View(reply);
        }

        // POST: Replies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                RepliesService service = new RepliesService();

                Reply reply = new Reply()
                {
                    ReplyId = Convert.ToInt32(collection["ReplyId"]),
                    CommentId = Convert.ToInt32(collection["CommentId"]),
                    Name = collection["Name"],
                    Text = collection["Text"],
                    DateReplied = Convert.ToDateTime(collection["DateReplied"])
                };

                bool succeeded = service.Update(reply);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    

        // GET: Replies/Delete/5
        public ActionResult Delete(int id)
        {
            RepliesService service = new RepliesService();
            Reply reply = service.Get(id);
            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                RepliesService service = new RepliesService();
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



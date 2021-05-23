using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdliyyeProduct.Models.Entity;

namespace EdliyyeProduct.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EdliyyeEntityEntities db = new EdliyyeEntityEntities();
        public ActionResult Index(string ara)
        {
            var model = db.Possts.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                model = db.Possts.Where(x => x.Title.Contains(ara)).ToList();
            }
            return View(model);
        }

        public ActionResult CommentPage(int id)
        {
            var model = db.Possts.Find(id);
            var cmp = db.Comments.Where(x => x.PostId == model.Id).ToList();
            return View(cmp);
        }
    }
}
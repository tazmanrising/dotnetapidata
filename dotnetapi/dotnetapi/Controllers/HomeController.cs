using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using dotnetapi.Data.Models;
using dotnetapi.Data;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace dotnetapi.Controllers
{
    public class HomeController : Controller
    {

        private DOCContext db = new DOCContext();

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var repo = new Repository();

            var tips = (from s in repo.GetTips()
                        select s);

            //var tips = (from s in db.tblTips
            //           .Where(d => d.@group == 2)   // supervisor = 2  , coordinator = 5
            //            select s);


            //Show the query 
            //ViewBag.itemType = tips;





            if (!String.IsNullOrEmpty(searchString))
            {
                tips = tips.Where(s => s.title.Contains(searchString)
                                       || s.body.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    tips = tips.OrderByDescending(s => s.title);
                    break;
                case "Date":
                    tips = tips.OrderBy(s => s.created);
                    break;
                case "date_desc":
                    tips = tips.OrderByDescending(s => s.created);
                    break;
                default:  // Name ascending 
                    tips = tips.OrderBy(s => s.updated);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var x = tips.Count();
            
            ViewBag.TotalCount = x.ToString();
            //ViewBag.TotalItemCount = y.ToString();
            return View(tips.ToPagedList(pageNumber, pageSize));

            //return View(tips.ToPagedList(1, pageSize));
           

        }


        public ActionResult AddComment(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            tblComments comments = new tblComments();

            comments.tblTipsId = id;

            return View(comments);
            

        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddComment(tblComments comment)
        // public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Student student)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    comment.created = DateTime.Now;

                    db.tblComments.Add(comment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }

            return View(comment);

        }



        public ActionResult GetComments(int id)
        {

            var repo = new Repository();
            var comments = (from s in repo.GetComments()
                        select s);

            //var comments = (from c in db.tblComments
            //                .Where(d => d.tblTipsId == id)   // supervisor = 2  , coordinator = 5
            //                select c);


            return PartialView("GetComments", comments);
        }




        public ActionResult GetAllComments()
        {

            var comments = (from c in db.tblComments
                      // .Where(d => d.@group == 2)   // supervisor = 2  , coordinator = 5
                        select c);

            return PartialView("AllComments", comments);
        }







        public ActionResult News()
        {




            return View(); 

        }


    }
}

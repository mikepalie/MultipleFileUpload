using MultipleFileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleFileUpload.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new Product());
        }

        [HttpPost]
        public ActionResult Save(Product product, HttpPostedFileBase[] photos)
        {
            if (photos != null)
            {
                List<string> files = new List<string>();
                foreach (var photo in photos)
                {
                    
                    photo.SaveAs(Server.MapPath("~/Content/Images/" + photo.FileName));
                    files.Add(photo.FileName);
                }
                product.Photos = files;
            }
            ViewBag.product = product;
            return View("Success");
        }





    }
}
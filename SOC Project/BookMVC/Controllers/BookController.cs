using BookMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<mvcBookModel> bkList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Book").Result;
            bkList = response.Content.ReadAsAsync<IEnumerable<mvcBookModel>>().Result;
            return View(bkList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new mvcBookModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Book/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcBookModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcBookModel bk)
        {
            
            
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Book", bk).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            
           
                 return RedirectToAction("Index");
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_RNWA.Models;

namespace MVC_RNWA.Controllers
{
    public class ProdController : Controller
    {
        // GET: Prod

        CrudImplementation ci = new CrudImplementation();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(ci.GetProd());
        }

        // GET: Prod/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prod/Create
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/Create
        [HttpPost]
        public ActionResult Create(CrudProp prodinsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ci.insertprod(prodinsert))
                    {
                        ViewBag.message = "Uspjesno dodan proizvod";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prod/Edit/5
        public ActionResult Edit(string id)
        {
            return View(ci.GetProd().Find(itemodel=>itemodel.productCode==id));
        }

        // POST: Prod/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CrudProp updateprod)
        {
            try
            {
                ci.editprod(updateprod);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prod/Delete/5
        public ActionResult Delete(string id)
        {
            ci.deleteprod(id);

            return RedirectToAction("Index");
        }

        // POST: Prod/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
